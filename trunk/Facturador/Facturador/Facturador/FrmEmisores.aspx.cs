using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Factura.Core;
using FacturaPlusTools;
using System.IO;



namespace Facturador
{
    public partial class FrmEmisores : System.Web.UI.Page
    {
        private FacturadorEntities1 FContext;
        private Certificado _Certificado;
        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (!Page.IsPostBack)
            {
                FillValues();
            }

        }

        private void FillValues()

        {
            try
            {
                FContext = new FacturadorEntities1();

                 if (Session["idemisor"] != null)
                {
                    ViewState["idemisor"] = Session["idemisor"];
                    Session["idemisor"] = null;
                    int _idemisor = Convert.ToInt32(ViewState["idemisor"]);

                    var emisor  = (from e in FContext.TblEmisores
                                   where e.PKEmisorId == _idemisor
                                    select e).FirstOrDefault();
              
                    this.txtRFC.Text= emisor.Rfc;
                    this.txtRazonSocial.Text=emisor.RazonSocial;
                    this.txtNoExterior.Text = emisor.NoExterior ;
                    this.txtNoInterior.Text= emisor.NoInterior ;
                    this.txtCalle.Text= emisor.Calle;
                    this.txtColonia.Text= emisor.Colonia;
                    this.txtReferencia.Text= emisor.Referencia;
                    this.txtLocalidad.Text= emisor.Localidad;
                    this.txtEstado.Text = emisor.Estado;
                    this.txtMunicipio.Text= emisor.Municipio;
                    this.txtCP.Text =emisor.CP;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar La Compania: " + ex.Message;
            }
          
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                   if (ViewState["idemisor"]==null)
                {
                AddEmisor();
                }
                else
                {
                    EditEmisor();
                }
            }
             catch (Exception ex )
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar La Compania: " + ex.Message;
            }
            
        }

        private bool  ValidaCertificado ()
        {
            string strCertFilePath;
            string strKeyFilePath;

            if (ViewState["idemisor"] == null)
            {
                //var emisor = FContext.TblEmisores.FirstOrDefault(Emisor => Emisor.PKEmisorId == _idemisor);

                Utilities.creaCarpetaClientes(this.txtRFC.Text.ToUpper(), HttpContext.Current.Server.MapPath(""));

                if (fuCertificado.HasFile && fuLlave.HasFile && !string.IsNullOrEmpty(this.txtPassword.Text))
                {

                    //obtenemos la ruta donde se ha guardado 
                    strCertFilePath = Utilities.GetServerFolder(this.txtRFC.Text.ToUpper()) + "certificado.cer";
                    strKeyFilePath = Utilities.GetServerFolder(this.txtRFC.Text.ToUpper()) + "llave.key";

                    //eliminamos la ruta anterior
                    if (System.IO.File.Exists(strCertFilePath))
                        System.IO.File.Delete(strCertFilePath);

                    //
                    if (System.IO.File.Exists(strKeyFilePath))
                        System.IO.File.Delete(strKeyFilePath);

                    //guardamos la llave y el certificado
                    fuCertificado.SaveAs(strCertFilePath);
                    fuLlave.SaveAs(strKeyFilePath);

                     _Certificado = new Certificado(strKeyFilePath);

                    if (_Certificado.CargarLlavePrivada(strKeyFilePath, txtPassword.Text) == false)
                    {
                        lblError.Text = "Verifique que la contraseña corresponda a la llave privada";
                        return false;
                    }


                    //Validamos si el certificado es vigente
                    if (!_Certificado.EsVigente)
                    {
                        lblError.Text = "La fecha del Certificado no es vigente.";
                        return false;
                    }

                    //Validamos que corresponda la llave al certificado
                    if (!_Certificado.CorrespondeLlave)
                    {
                        lblError.Text = "El archivo de llave privada no corresponde al certificado. Favor de verificar los archivos.";
                        return false;
                    }


                    //Valida que el certificado pertenezca al campo RFC
                    if (txtPassword.Text != "Test123$")
                    {
                        //Se utiliza esta contraseña para poder bincar esta validación
                        String strSubject = _Certificado.certificado.Subject;

                        if (!strSubject.Contains(txtRFC.Text.Trim().ToUpper()))
                        {
                            lblError.Text= "El RFC no coincide con el del certificado. Favor de verificar la información.";
                            return false;
                        }

                    }

                    try
                    {
                        System.IO.File.Delete(strCertFilePath);
                    }
                    catch (Exception e)
                    {

                        throw e;
                    }

                }
            }
            return true;
        }


        private void AddEmisor()
        {
           
            try
            {
                FContext = new FacturadorEntities1();
                 var emisor = new TblEmisore();

                emisor.FkClienteId =Convert.ToInt32( Session["ClienteId"]);
                emisor.Rfc = this.txtRFC.Text;
                emisor.RazonSocial = this.txtRazonSocial.Text;
                emisor.NoExterior = this.txtNoExterior.Text;
                emisor.NoInterior = this.txtNoInterior.Text;
                emisor.Calle = this.txtCalle.Text;
                emisor.Colonia = this.txtColonia.Text;
                emisor.Referencia = this.txtReferencia.Text;
                emisor.Localidad = this.txtLocalidad.Text;
                emisor.Estado = this.txtEstado.Text;
                emisor.Municipio = this.txtMunicipio.Text;
                emisor.CP = this.txtCP.Text;
                if (fuLogo.HasFile)
                {
                    emisor.ImagenLogo = fuLogo.FileBytes;
                    emisor.NombreLogo = fuLogo.FileName;

                }
                

                FContext.AddToTblEmisores(emisor);
              
                FContext.SaveChanges();
                Response.Redirect("listEmisores.aspx");
            }
            catch (Exception ex )
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar La Compania: " + ex.Message;
            }
           
        }

        private void EditEmisor()
        {
           
           
            try
            {
                FContext = new FacturadorEntities1();
                var emisor = new TblEmisore();
                int _idemisor = Convert.ToInt32(ViewState["idemisor"]);
               
                emisor = FContext.TblEmisores.FirstOrDefault(Emisor => Emisor.PKEmisorId == _idemisor);

                emisor.FkClienteId =Convert.ToInt32( Session["ClienteId"]);
                emisor.Rfc = this.txtRFC.Text;
                emisor.RazonSocial = this.txtRazonSocial.Text;
                emisor.NoExterior = this.txtNoExterior.Text;
                emisor.NoInterior = this.txtNoInterior.Text;
                emisor.Calle = this.txtCalle.Text;
                emisor.Colonia = this.txtColonia.Text;
                emisor.Referencia = this.txtReferencia.Text;
                emisor.Localidad = this.txtLocalidad.Text;
                emisor.Estado = this.txtEstado.Text;
                emisor.Municipio = this.txtMunicipio.Text;
                emisor.CP = this.txtCP.Text;
                
                FContext.SaveChanges();
                Response.Redirect("listEmisores.aspx");
            }
            catch (Exception ex )
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar La Compania: " + ex.Message;
            }
           
        }

        }
    }
