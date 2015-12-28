using System.Security.Cryptography.X509Certificates;
using System.IO;
using CryptoSysPKI;
using System;
using System.Collections.Specialized;
using System.Text;
using System.Xml;
using System.Data;
using FacturaPlus.DataAccess;
using FacturaPlusTools;
namespace Factura.Core
{
    public class Certificado
    {

        public X509Certificate2 certificado;
        private int _EmisorId;
        // private string  _LlavePublica;
        private string _LlavePrivada;
        private string _RutaLlavePrivada;
        private string _PswdLlavePrivada;
        private Database db = new Database();
        private string _Base64;

        private string _selloDigital;
        public string RutaLlavePrivada

        {
            get { return _RutaLlavePrivada; }
            set { _RutaLlavePrivada = value; }
        }

        public string LlavePrivada
        {
            get { return _LlavePrivada; }
            set { _LlavePrivada = value; }
        }

        public bool EsVigente
        {
            get
            {
                if (certificado.NotBefore < DateTime.Now && certificado.NotAfter > DateTime.Now)
                { return true; }
                else
                { return false; }

            }
        }

        public string NumeroCertificado
        {
            get { return Encoding.UTF8.GetString(Cnv.FromHex(certificado.GetSerialNumberString())); }
        }
        ///<summary>
        /// Checa la correspondencia de la llave privada con el certificado
        /// </summary>
        /// <returns>True-Si se registró correctamente.</returns>
        /// <remarks></remarks>  
        public bool CorrespondeLlave
        {
            get
            {
                if (Rsa.KeyMatch(_LlavePrivada, certificado.PublicKey.ToString()) != 0)
                { return true; }
                else
                { return false; }

            }
        }

        public string CertBase64
        {
            get { return _Base64; }

        }


        public Certificado(string strCertPath)
        {
            if (File.Exists(strCertPath))
            {
                try
                {
                    certificado = new X509Certificate2(strCertPath);
                    _Base64 = Convert.ToBase64String(certificado.GetRawCertData());
                    _Base64 = CryptoSysPKI.X509.ReadStringFromFile(strCertPath);
                }
                catch (Exception ex) { }
            }

            else
            { }

        }


       



        #region Validaciones CFDI
        private DataRow _certificadoLCO;

        public void CargarCertificadoDesdeCadenaBase64(string cadena)
        {
            byte[] contenido = Convert.FromBase64String(cadena);
            certificado = new X509Certificate2();
            certificado.Import(contenido);
            _Base64 = Convert.ToBase64String(certificado.GetRawCertData());
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = "SELECT * FROM LcoCertificados WHERE UPPER(NoCertificado) = UPPER(@noCertificado)";
            cmd.Parameters.AddWithValue("noCertificado", Encoding.UTF8.GetString(Cnv.FromHex(certificado.SerialNumber)));
            DataTable tabla = db.GetTable(cmd);
            if (tabla.Rows.Count > 0)
                _certificadoLCO = tabla.Rows[0];
        }

        public bool CompararRFCCertificado(string rfc)
        {
            return certificado.SubjectName.Format(false).ToUpper().Contains(rfc.ToUpper());
        }

        public bool VerificarFechaEmisionComprobanteVigenciaCertificado(DateTime fechaComprobante)
        {
            return (fechaComprobante.CompareTo(certificado.NotBefore) >= 0 && fechaComprobante.CompareTo(certificado.NotAfter) <= 0);
        }

        public bool ComprobarRFCEmisorListadoLCO(string rfc)
        {
            return (_certificadoLCO != null && _certificadoLCO["RFCEmisor"].ToString().ToUpper() == rfc.ToUpper());
        }

        public bool VerificarCertificadoRevocadoListadoLCO()
        {
            if (_certificadoLCO != null)
            {
                if (_certificadoLCO["EstatusCertificado"].ToString().ToUpper() == "R" | _certificadoLCO["EstatusCertificado"].ToString().ToUpper() == "C")
                    return true;
            }
            return false;
        }

        public bool VerificarSituacionFiscalContribuyente()
        {
            if (_certificadoLCO != null)
            {
                return Convert.ToBoolean(_certificadoLCO["validezobligaciones"]);
            }
            return false;
        }


        public bool VerificarSelloComprobante(string cadenaOriginal, string sello)
        {
            return VerificarSelloComprobante(cadenaOriginal, sello, HashAlgorithm.Sha1);
        }

        public bool VerificarSelloComprobante(string cadenaOriginal, string sello, HashAlgorithm algoritmo)
        {
            byte[] digest = Hash.BytesFromBytes(Encoding.UTF8.GetBytes(cadenaOriginal), algoritmo);
            StringBuilder llavePublica = Rsa.GetPublicKeyFromCert(Convert.ToBase64String(Convert.FromBase64String(_Base64)));
            if (llavePublica.Length == 0)
                return false;
            byte[] sellado = System.Convert.FromBase64String(sello);
            if (sellado.Length != Rsa.KeyBytes(llavePublica.ToString()))
                return false;
            sellado = Rsa.RawPublic(sellado, llavePublica.ToString());
            if (sellado.Length == 0)
                return false;
            sellado = Rsa.DecodeDigestForSignature(sellado);
            if (sellado.Length == 0)
                return false;
            return (String.Compare(Cnv.ToHex(sellado), Cnv.ToHex(digest), true) == 0);
        }

        public bool VerificarCertificadoSAT()
        {
            /*
             Descripción durante las pruebas de cómo viene la entidad certificadora del certificado, para obtener el dato de la entidad certificadora del SAT
             certificado.IssuerName.Format(true) => CN=A.C. de pruebas\r\nO=Servicio de Administración Tributaria\r\nOU=Administración de Seguridad de la Información\r\nE=asisnet@pruebas.sat.gob.mx\r\nSTREET=\"Av. Hidalgo 77, Col. Guerrero\"\r\nPostalCode=06300\r\nC=MX\r\nS=Distrito Federal\r\nL=Coyoacán\r\nOID.2.5.4.45=SAT970701NN3\r\nOID.1.2.840.113549.1.9.2=Responsable: Héctor Ornelas Arciga\r\n
             la posición 1 al realizar un split con "\r\n" => O=Servicio de Administración Tributaria
             la posición 1 al realizar un split con "=" => Servicio de Administración Tributaria
            */
            string[] entidad = certificado.IssuerName.Format(true).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            string entidadCertificadora = entidad[1].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries)[entidad[1].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries).Length - 1];
            return (String.Compare(entidadCertificadora.ToUpper(), "SERVICIO DE ADMINISTRACIÓN TRIBUTARIA", true) == 0);
        }

        public bool VerificarTipoDeCertificado()
        {
            /*
            Revisa que el tipo de certificado sea un CSD
            */

            if (certificado.Subject.ToString().Contains("OU="))
            { return true; }
            else
            { return false; }

        }


        /// <summary>
        /// Función que servirá para obtener el hash que solicita el SAT en sus servicios
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns>Devuelve el hash de la cadena especifiada</returns>
        /// <remarks>Cambiar únicamente esta función, ya que para durante las pruebas el SAT aun no especificó que información va.</remarks>
        public string ObtenerHash(string cadena)
        {
            return Hash.HexFromBytes(Encoding.UTF8.GetBytes(cadena), HashAlgorithm.Sha1);
        }
        #endregion

        public Certificado(int intEmisorId)
        {
            _EmisorId = intEmisorId;
            Database db;
            db = new Database();
            string strQuery;
            string strCertificado;
            DataRowView drCert;


            strQuery = "SELECT Certificado, LlavePrivada, PswdLlave FROM Emisor WHERE pkEmisorId= " + intEmisorId.ToString();
            drCert = db.GetRowView(strQuery);
            strCertificado = drCert["Certificado"].ToString();
            _LlavePrivada = drCert["LlavePrivada"].ToString();
            _PswdLlavePrivada = drCert["PswdLlave"].ToString();

            certificado = new X509Certificate2(Convert.FromBase64String(strCertificado));
            _Base64 = Convert.ToBase64String(certificado.GetRawCertData());

        }

        public Certificado()
        { }

        ///<summary>
        /// Guarda el string del certificado en base de datos en la tabla Emisor
        /// </summary>
        /// <returns>True-Si se registró correctamente.</returns>
        /// <remarks></remarks>   
        public bool RegistrarCert()
        {
            Database db;
            db = new Database();

            NameValueCollection values = new NameValueCollection();
            String strCertificado;

            strCertificado = _Base64;

            values.Add("pkEmisorId", _EmisorId.ToString());
            values.Add("Certificado", strCertificado);

            db.QuickUpdate("Emisor", values);

            return true;

        }

        ///<summary>
        ///Carga la llave privada a la clase
        /// </summary>
        /// <returns>True-si se cargó correctamente.</returns>
        /// <remarks></remarks>  
        public bool CargarLlavePrivada(string strRutaLlave, string strPassword)
        {

            _LlavePrivada = Rsa.ReadEncPrivateKey(strRutaLlave, strPassword).ToString();

            _LlavePrivada = Rsa.ToXMLString(_LlavePrivada, Rsa.XmlOptions.ForceRSAKeyValue);

            if (_LlavePrivada != "")
            { return true; }
            else
            { return false; }
        }

        public string ObtenerLlavePrivadaXml()
        {
            return Rsa.ToXMLString(_LlavePrivada, Rsa.XmlOptions.ForceRSAKeyValue);
        }

        public string SellarCadena(string cadena, string idComprobante)
        {
            string sello = "";
            sello = SellarCadena(cadena);
            NameValueCollection values = new NameValueCollection();

            db = new Database();
            values.Add("pkComprobanteId", idComprobante);
            db.QuickUpdate("Comprobante", values);
            return sello;
        }


        public string SellarCadena(string cadena)
        {
            //StringBuilder  sbPrivateKey ;
            //sbPrivateKey= new StringBuilder();
            HashAlgorithm hashAlgo;
            byte[] abDigest;
            byte[] abBlock;
            System.Text.UTF8Encoding encod;
            encod = new System.Text.UTF8Encoding();
            int nBlockLen;
            string strBase64;

            //cadena = Encoding.UTF8.GetString(System.Text.Encoding.Default.GetBytes(cadena));
            hashAlgo = HashAlgorithm.Sha1;

            abDigest = Hash.BytesFromBytes(encod.GetBytes(cadena), hashAlgo);

            if (abDigest.Length <= 0)
            {
                throw new Exception("Error de encripcion");
            }

            // sbPrivateKey = CryptoSysPKI.Rsa.ReadEncPrivateKey(_RutaLlavePrivada, _PswdLlavePrivada);

            // 2.2 Encode the digest ready for signing with `Encoded Message for Signature' block using PKCS#1 v1.5 method
            nBlockLen = Rsa.KeyBytes(_LlavePrivada);
            abBlock = Rsa.EncodeDigestForSignature(nBlockLen, abDigest, hashAlgo);

            if (abBlock.Length == 0)
            { throw new Exception("ERROR con Rsa.EncodeDigestForSignature"); }


            // 2.3 Sign using the RSA private key
            abBlock = Rsa.RawPrivate(abBlock, _LlavePrivada);


            // 3. Convert to base64 and output result
            strBase64 = System.Convert.ToBase64String(abBlock);

            return strBase64;

        }

        public string SellarCadena(string cadena, string strRutaLlave, string strPswdLlave)
        {
            StringBuilder sbPrivateKey;
            sbPrivateKey = new StringBuilder();
            HashAlgorithm hashAlgo;
            byte[] abDigest;
            byte[] abBlock;
            System.Text.UTF8Encoding encod;
            encod = new System.Text.UTF8Encoding();
            int nBlockLen;
            string strBase64;

            //cadena = Encoding.UTF8.GetString(System.Text.Encoding.Default.GetBytes(cadena));
            hashAlgo = HashAlgorithm.Sha1;

            abDigest = Hash.BytesFromBytes(encod.GetBytes(cadena), hashAlgo);

            if (abDigest.Length <= 0)
            {
                throw new Exception("Error de encripcion");
            }

            sbPrivateKey = CryptoSysPKI.Rsa.ReadEncPrivateKey(strRutaLlave, strPswdLlave);

            // 2.2 Encode the digest ready for signing with `Encoded Message for Signature' block using PKCS#1 v1.5 method
            nBlockLen = Rsa.KeyBytes(sbPrivateKey.ToString());
            abBlock = Rsa.EncodeDigestForSignature(nBlockLen, abDigest, hashAlgo);

            if (abBlock.Length == 0)
            { throw new Exception("ERROR con Rsa.EncodeDigestForSignature"); }


            // 2.3 Sign using the RSA private key
            abBlock = Rsa.RawPrivate(abBlock, sbPrivateKey.ToString());


            // 3. Convert to base64 and output result
            strBase64 = System.Convert.ToBase64String(abBlock);

            return strBase64;

        }

        public XmlDocument SellarXML(XmlDocument XmlBase)
        {
            Comprobante CFDI;
            XmlNode nodoComprobante;

            CFDI = new Comprobante();
            CFDI.ObtenerDatosComprobanteXML(XmlBase.OuterXml);
            CFDI.CrearCadenaOriginal();

            _selloDigital = SellarCadena(CFDI.CadenaOriginal);

            nodoComprobante = XmlBase.GetElementsByTagName("cfdi:Comprobante")[0];
            nodoComprobante.Attributes["sello"].Value = _selloDigital;
            nodoComprobante.Attributes["certificado"].Value = _Base64;
            nodoComprobante.Attributes["noCertificado"].Value = Encoding.UTF8.GetString(Cnv.FromHex(certificado.GetSerialNumberString()));

            return XmlBase;
        } //public XmlDocument SellarXML

        ///<summary>
        /// Crea el Objeto Certificado a partir del un string que representa el certificado
        /// </summary>
        /// <remarks></remarks>  
        public void FromBase64(string CertBase64)
        {
            byte[] byteCert;

            byteCert = UTF8Encoding.UTF8.GetBytes(CertBase64);
            certificado = new X509Certificate2(byteCert);
            _Base64 = CertBase64;

        }


        ///<summary>
        /// Crea el Xml sellado a partir del xml base
        /// </summary>
        /// <returns>El sello generado. Si hay error regresa el mensaje de error</returns>
        /// <remarks></remarks>  
        public string SellarXML(string strRutaXmlBase, string strRutaXmlSellado, string strRutaLlave, string strPswdLlave)
        {

            _RutaLlavePrivada = strRutaLlave;
            _PswdLlavePrivada = strPswdLlave;


            //Verifica que exista el archivo base.
            if (!File.Exists(strRutaXmlBase))
            {
                return "Error: No se pudo accesar a la ruta: " + strRutaXmlBase;
            }

            XmlDocument XmlBase;
            XmlBase = new XmlDocument();

            try
            {
                XmlBase.Load(strRutaXmlBase);
            }
            catch (Exception e)
            { return "Error: No se pudo cargar el archivo: " + strRutaXmlBase + " / " + e.Message; }


            XmlDocument XmlSellado;
            XmlSellado = new XmlDocument();

            _selloDigital = "";//se inicia la variable donde se guarda el sello
            XmlSellado = SellarXML(XmlBase);

            try
            {
                XmlTextWriter xw = new XmlTextWriter(strRutaXmlSellado, Encoding.UTF8);
                xw.Formatting = Formatting.Indented;
                XmlSellado.Save(xw);
            }
            catch { return "Error: No se pudo escribir el archivo: " + strRutaXmlSellado; }

            File.Delete(strRutaXmlBase);

            return _selloDigital;

        } //public XmlDocument SellarXML


        public bool GuardarLlavePrivada()
        {

            if (_EmisorId.ToString() != "" & _LlavePrivada != "")
            {
                Database db = new Database();
                NameValueCollection nvalue = new NameValueCollection();

                nvalue.Add("pkEmisorId", _EmisorId.ToString());
                nvalue.Add("LlavePrivada", _LlavePrivada);

                db.QuickUpdate("Emisor", nvalue);
                return true;

            }
            else
            {
                return false;
            }



        }//GuardarLlavePrivada

    }// public class Certificado
}//namespace CFD
