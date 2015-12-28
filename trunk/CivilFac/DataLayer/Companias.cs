using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace DataLayer
{
    public class Compania
    {
        
        #region Propiedades

        private DataAcces ObjDataAcces;

        private int _PKCompaniaId; 
        private string _RazonSocial; 
        private string _Rfc;
        private string _Calle;  
        private string _NoExterior;  
        private string _NoInterior;  
        private string _Colonia;  
        private string _Localidad;  
        private string _Municipio;  
        private int _Estado;   
        private string _CP;   
        private string _Certificado;  
        private string _NoCertificado;   
        private DateTime _FechaInicial;  
        private DateTime _FechaFinal;  
        private string _Logo;
        private string _PasswordCertificado;  
        private string _Regimen;
        private string _RegimenFiscal;  
        private string _RutaCertificado;
        private string _ImagenRFC;

        public int PKCompaniaId
        {
            get { return _PKCompaniaId; }
            set { _PKCompaniaId = value; }
        }

        public string RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }

        public string Rfc
        {
            get { return _Rfc; }
            set { _Rfc = value; }
        }

        public string Calle
        {
            get { return _Calle; }
            set { _Calle = value; }
        }

        public string NoExterior
        {
            get { return _NoExterior; }
            set { _NoExterior = value; }
        }

        public string NoInterior
        {
            get { return _NoInterior; }
            set { _NoInterior = value; }
        }

        public string Colonia
        {
            get { return _Colonia; }
            set { _Colonia = value; }
        }

        public string Localidad
        {
            get { return _Localidad; }
            set { _Localidad = value; }
        }

        public string Municipio
        {
            get { return _Municipio; }
            set { _Municipio = value; }
        }

        public int Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        public string CP
        {
            get { return _CP; }
            set { _CP = value; }
        }

        public string Certificado
        {
            get { return _Certificado; }
            set { _Certificado = value; }
        }

        public string NoCertificado
        {
            get { return _NoCertificado; }
            set { _NoCertificado = value; }
        }

        public DateTime FechaInicial
        {
            get { return _FechaInicial; }
            set { _FechaInicial = value; }
        }

        public DateTime FechaFinal
        {
            get { return _FechaFinal; }
            set { _FechaFinal = value; }
        }

        public string Logo
        {
            get { return _Logo; }
            set { _Logo = value; }
        }

        public string PasswordCertificado
        {
            get { return _PasswordCertificado; }
            set { _PasswordCertificado = value; }
        }

        public string Regimen
        {
            get { return _Regimen; }
            set { _Regimen = value; }
        }

        public string RegimenFiscal
        {
            get { return _RegimenFiscal; }
            set { _RegimenFiscal = value; }
        }


        public string RutaCertificado
        {
            get { return _RutaCertificado; }
            set { _RutaCertificado = value; }
        }

        public string ImagenRFC
        {
            get { return _ImagenRFC; }
            set { _ImagenRFC = value; }
        }

        #endregion

        public Compania()
        {

        _PKCompaniaId=-1; 
        _RazonSocial=""; 
        _Rfc="";
        _Calle="";  
        _NoExterior="";  
        _NoInterior="";  
        _Colonia="";  
        _Localidad="";  
        _Municipio="";  
        _Estado=-1;   
        _CP="";   
        _Certificado="";  
        _NoCertificado="";   
        _FechaInicial=DateTime.Now;
        _FechaFinal = DateTime.Now;  
        _Logo="";
        _PasswordCertificado="";  
        _Regimen="";
        _RegimenFiscal="";  
        _RutaCertificado="";
        _ImagenRFC="";

            ObjDataAcces = new DataAcces();
        }

        #region Eventos


        public List<Compania> Get(string Condiciones)
        {
            try
            {
                List<Compania> Listcompania = new List<Compania>();
                string consulta =" select "+
                                " PKCompaniaId "+ 
                                " ,RazonSocial "+
                                " ,Rfc "+
                                " ,Calle "+  
                                " ,NoExterior "+  
                                " ,Noerior "  +
                                " ,Colonia "  +
                                " ,Localidad " + 
                                " ,Municipio "  +
                                " ,Estado "   +
                                " ,CP "   +
                                " ,Certificado "+  
                                " ,NoCertificado "+   
                                " ,FechaInicial " +
                                " ,FechaFinal "  +
                                " ,Logo "+
                                " ,PasswordCertificado "+  
                                " ,Regimen "+
                                " ,RegimenFiscal "+ 
                                " ,RutaCertificado "+
                                " ,ImagenRFC "+
                                " from TblCompanias ";

                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    Compania ObjCompania = new Compania();

                    ObjCompania.PKCompaniaId = Convert.ToInt32(datos[0]);
                    ObjCompania.RazonSocial = Convert.ToString(datos[1]);
                    ObjCompania.Rfc = Convert.ToString(datos[2]);
                    ObjCompania.Calle = Convert.ToString(datos[3]);
                    ObjCompania.NoExterior = Convert.ToString(datos[4]);
                    ObjCompania.NoInterior = Convert.ToString(datos[5]);
                    ObjCompania.Colonia = Convert.ToString(datos[6]);
                    ObjCompania.Localidad = Convert.ToString(datos[7]);
                    ObjCompania.Municipio = Convert.ToString(datos[8]);
                    ObjCompania.Estado = Convert.ToInt32(datos[9]);
                    ObjCompania.CP = Convert.ToString(datos[10]);
                    ObjCompania.Certificado = Convert.ToString(datos[11]);
                    ObjCompania.NoCertificado = Convert.ToString(datos[12]);
                    ObjCompania.FechaInicial = Convert.ToDateTime(datos[13]);
                    ObjCompania.FechaFinal = Convert.ToDateTime(datos[14]);
                    ObjCompania.Logo = Convert.ToString(datos[15]);
                    ObjCompania.PasswordCertificado = Convert.ToString(datos[16]);
                    ObjCompania.Regimen = Convert.ToString(datos[17]);
                    ObjCompania.RegimenFiscal = Convert.ToString(datos[18]);
                    ObjCompania.RutaCertificado = Convert.ToString(datos[19]);
                    ObjCompania.ImagenRFC = Convert.ToString(datos[20]);
                    // Los agregamos a la lista
                    Listcompania.Add(ObjCompania);
                }
                datos.Close();
                ObjDataAcces.Close();

                return Listcompania;
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        public Compania GetbyID(int id)
        {
            try
            {
                Compania ObjCompania = new Compania();
                string consulta =" select "+
                                " PKCompaniaId "+ 
                                " ,RazonSocial "+
                                " ,Rfc "+
                                " ,Calle "+  
                                " ,NoExterior "+  
                                " ,Noerior "  +
                                " ,Colonia "  +
                                " ,Localidad " + 
                                " ,Municipio "  +
                                " ,Estado "   +
                                " ,CP "   +
                                " ,Certificado "+  
                                " ,NoCertificado "+   
                                " ,FechaInicial " +
                                " ,FechaFinal "  +
                                " ,Logo "+
                                " ,PasswordCertificado "+  
                                " ,Regimen "+
                                " ,RegimenFiscal "+ 
                                " ,RutaCertificado "+
                                " ,ImagenRFC "+
                                " from TblCompanias "+
                                " where PKCompaniaid=@PKCompaniaId";

                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                 cmd.Parameters.AddWithValue("@PKCompaniaId", id);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    ObjCompania.PKCompaniaId = Convert.ToInt32(datos[0]);
                    ObjCompania.RazonSocial = Convert.ToString(datos[1]);
                    ObjCompania.Rfc = Convert.ToString(datos[2]);
                    ObjCompania.Calle = Convert.ToString(datos[3]);
                    ObjCompania.NoExterior = Convert.ToString(datos[4]);
                    ObjCompania.NoInterior = Convert.ToString(datos[5]);
                    ObjCompania.Colonia = Convert.ToString(datos[6]);
                    ObjCompania.Localidad = Convert.ToString(datos[7]);
                    ObjCompania.Municipio = Convert.ToString(datos[8]);
                    ObjCompania.Estado = Convert.ToInt32(datos[9]);
                    ObjCompania.CP = Convert.ToString(datos[10]);
                    ObjCompania.Certificado = Convert.ToString(datos[11]);
                    ObjCompania.NoCertificado = Convert.ToString(datos[12]);
                    ObjCompania.FechaInicial = Convert.ToDateTime(datos[13]);
                    ObjCompania.FechaFinal = Convert.ToDateTime(datos[14]);
                    ObjCompania.Logo = Convert.ToString(datos[15]);
                    ObjCompania.PasswordCertificado = Convert.ToString(datos[16]);
                    ObjCompania.Regimen = Convert.ToString(datos[17]);
                    ObjCompania.RegimenFiscal = Convert.ToString(datos[18]);
                    ObjCompania.RutaCertificado = Convert.ToString(datos[19]);
                    ObjCompania.ImagenRFC = Convert.ToString(datos[20]);
                    // Los agregamos a la lista
                }
                datos.Close();
                ObjDataAcces.Close();

                return ObjCompania;
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        public void Insert(Compania PCompania)
        {
            try
            {
                string StrSQl;
                if (existe(PCompania))
                {
                    StrSQl = " UPDATE TblCompania" +
                                    " SET " +
                                    " RazonSocial=@RazonSocial " +
                                    " ,Rfc=@Rfc " +
                                    " ,Calle=@Calle " +
                                    " ,NoExterior=@NoExterior " +
                                    " ,NoInterior=@NoInterior " +
                                    " ,Colonia=@Colonia " +
                                    " ,Localidad=@Localidad " +
                                    " ,Municipio=@Municipio " +
                                    " ,Estado=@Estado " +
                                    " ,CP=@CP " +
                                    " ,Certificado=@Certificado " +
                                    " ,NoCertificado=@NoCertificado " +
                                    " ,FechaInicial=@FechaInicial " +
                                    " ,FechaFinal=@FechaFinal " +
                                    " ,Logo=@Logo " +
                                    " ,PasswordCertificado=@PasswordCertificado " +
                                    " ,Regimen=@Regimen " +
                                    " ,RegimenFiscal=@RegimenFiscal " +
                                    " ,RutaCertificado=@RutaCertificado " +
                                    " ,ImagenRFC=@ImagenRFC " +
                                  " WHERE PKCompaniaId=@PKCompaniaId";

                    var insertSQL = new SQLiteCommand(StrSQl, ObjDataAcces.Conexion);
                    insertSQL.Parameters.AddWithValue("@RazonSocial", PCompania.RazonSocial);
                    insertSQL.Parameters.AddWithValue("@Rfc", PCompania.Rfc);
                    insertSQL.Parameters.AddWithValue("@Calle", PCompania.Calle);
                    insertSQL.Parameters.AddWithValue("@NoExterior", PCompania.NoExterior);
                    insertSQL.Parameters.AddWithValue("@NoInterior", PCompania.NoInterior);
                    insertSQL.Parameters.AddWithValue("@Colonia", PCompania.Colonia);
                    insertSQL.Parameters.AddWithValue("@Localidad", PCompania.Localidad);
                    insertSQL.Parameters.AddWithValue("@Municipio", PCompania.Municipio);
                    insertSQL.Parameters.AddWithValue("@Estado", PCompania.Estado);
                    insertSQL.Parameters.AddWithValue("@CP", PCompania.CP);
                    insertSQL.Parameters.AddWithValue("@Certificado", PCompania.Certificado);
                    insertSQL.Parameters.AddWithValue("@NoCertificado", PCompania.NoCertificado);
                    insertSQL.Parameters.AddWithValue("@FechaInicial", PCompania.FechaInicial);
                    insertSQL.Parameters.AddWithValue("@FechaFinal", PCompania.FechaFinal);
                    insertSQL.Parameters.AddWithValue("@RegimenFiscal", PCompania.RegimenFiscal);
                    insertSQL.Parameters.AddWithValue("@Regimen", PCompania.Regimen);
                    insertSQL.Parameters.AddWithValue("@RegimenFiscal", PCompania.RegimenFiscal);
                    insertSQL.Parameters.AddWithValue("@RutaCertificado", PCompania.RutaCertificado);
                    insertSQL.Parameters.AddWithValue("@ImagenRFC", PCompania.ImagenRFC);
                    insertSQL.Parameters.AddWithValue("@PKCompaniaId", PCompania.PKCompaniaId);

                    ObjDataAcces.Open();
                    insertSQL.ExecuteNonQuery(); //Execute query
                    ObjDataAcces.Close();
                }
               else
                {
                     StrSQl = " INSERT INTO TblCompania" +
                                    " (RazonSocial" +
                                    " ,Rfc " +
                                    " ,Calle " +
                                    " ,NoExterior " +
                                    " ,NoInterior " +
                                    " ,Colonia " +
                                    " ,Localidad " +
                                    " ,Municipio " +
                                    " ,Estado " +
                                    " ,CP " +
                                    " ,Certificado " +
                                    " ,NoCertificado " +
                                    " ,FechaInicial " +
                                    " ,FechaFinal " +
                                    " ,Logo " +
                                    " ,PasswordCertificado " +
                                    " ,Regimen " +
                                    " ,RegimenFiscal " +
                                    " ,RutaCertificado" +
                                    " ,ImagenRFC ) " +
                                    "VALUES " +
                                     "(@RazonSocial " +
                                    " ,@Rfc " +
                                    " ,@Calle " +
                                    " ,@NoExterior " +
                                    " ,@NoInterior " +
                                    " ,@Colonia " +
                                    " ,@Localidad " +
                                    " ,@Municipio " +
                                    " ,@Estado " +
                                    " ,@CP " +
                                    " ,@Certificado " +
                                    " ,@NoCertificado " +
                                    " ,@FechaInicial " +
                                    " ,@FechaFinal " +
                                    " ,@Logo " +
                                    " ,@PasswordCertificado " +
                                    " ,@Regimen " +
                                    " ,@RegimenFiscal " +
                                    " ,@RutaCertificado " +
                                    " ,@ImagenRFC) ";

                     var insertSQL = new SQLiteCommand(StrSQl, ObjDataAcces.Conexion);
                     insertSQL.Parameters.AddWithValue("@RazonSocial", PCompania.RazonSocial);
                     insertSQL.Parameters.AddWithValue("@Rfc", PCompania.Rfc);
                     insertSQL.Parameters.AddWithValue("@Calle", PCompania.Calle);
                     insertSQL.Parameters.AddWithValue("@NoExterior", PCompania.NoExterior);
                     insertSQL.Parameters.AddWithValue("@NoInterior", PCompania.NoInterior);
                     insertSQL.Parameters.AddWithValue("@Colonia", PCompania.Colonia);
                     insertSQL.Parameters.AddWithValue("@Localidad", PCompania.Localidad);
                     insertSQL.Parameters.AddWithValue("@Municipio", PCompania.Municipio);
                     insertSQL.Parameters.AddWithValue("@Estado", PCompania.Estado);
                     insertSQL.Parameters.AddWithValue("@CP", PCompania.CP);
                     insertSQL.Parameters.AddWithValue("@Certificado", PCompania.Certificado);
                     insertSQL.Parameters.AddWithValue("@NoCertificado", PCompania.NoCertificado);
                     insertSQL.Parameters.AddWithValue("@FechaInicial", PCompania.FechaInicial);
                     insertSQL.Parameters.AddWithValue("@FechaFinal", PCompania.FechaFinal);
                     insertSQL.Parameters.AddWithValue("@RegimenFiscal", PCompania.RegimenFiscal);
                     insertSQL.Parameters.AddWithValue("@Regimen", PCompania.Regimen);
                     insertSQL.Parameters.AddWithValue("@RegimenFiscal", PCompania.RegimenFiscal);
                     insertSQL.Parameters.AddWithValue("@RutaCertificado", PCompania.RutaCertificado);
                     insertSQL.Parameters.AddWithValue("@ImagenRFC", PCompania.ImagenRFC);

                     ObjDataAcces.Open();
                     insertSQL.ExecuteNonQuery(); //Execute query
                     ObjDataAcces.Close();
                    }                        

                    
                
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        public void Delete(Int32 Id)
        {
            try
            {
                var insertSQL = new SQLiteCommand("Delete From TblCompania WHERE PKCompaniaId=@PKCompaniaId", ObjDataAcces.Conexion);

                insertSQL.Parameters.AddWithValue("@PKCompaniaId", Id);
                ObjDataAcces.Open();
                insertSQL.ExecuteNonQuery(); //Execute query
                ObjDataAcces.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private bool existe(Compania PCompania)
        {
            try
            {
                Compania ObjCompania = new Compania();
                bool Resultado = false;

                ObjCompania = GetbyID(PCompania.PKCompaniaId);
                if (ObjCompania != null)
                {
                    Resultado = true;
                }
                return Resultado;
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        #endregion
    }
}


//string SQL = "SELECT count(ifnull(PKCompaniaId)+1) FROM TblCompania ;";

//SQLiteCommand cmd = new SQLiteCommand(SQL, Conexion);

//Conexion.Open();
//object result = cmd.ExecuteScalar();
//int PKCompaniaId = Convert.ToInt32(result);
//Conexion.Close();