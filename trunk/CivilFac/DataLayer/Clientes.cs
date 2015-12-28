using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace DataLayer
{
    public class cliente    
    {

        #region Propiedades

        private DataAcces ObjDataAcces;

        private int _PkClienteId;
        private int _FKCompaniaId;
        private string _RazonSocial; 
        private string _Rfc; 
        private string _TipoEmisor; 
        private string _Calle; 
        private string _NoExterior; 
        private string _NoInterior; 
        private string _Colonia; 
        private string _Localidad; 
        private string _Referencia; 
        private string _Municipio; 
        private string _Estado; 
        private string _CorreoElectronico;
        private string _CP; 

        public int PkClienteId
        {
            get { return _PkClienteId; }
            set { _PkClienteId = value; }
        }

        public int FKCompaniaId
        {
            get { return _FKCompaniaId; }
            set { _FKCompaniaId = value; }
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

        public string TipoEmisor
        {
            get { return _TipoEmisor; }
            set { _TipoEmisor = value; }
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
        public string Referencia
        {
            get { return _Referencia; }
            set { _Referencia = value; }
        }

        public string Municipio
        {
            get { return _Municipio; }
            set { _Municipio = value; }
        }

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        public string CorreoElectronico
        {
            get { return _CorreoElectronico; }
            set { _CorreoElectronico = value; }
        }
        public string CP
        {
            get { return _CP; }
            set { _CP = value; }
        }

        #endregion

        public cliente()
        {
            _PkClienteId=-1;
            _FKCompaniaId=-1;
            _RazonSocial=""; 
            _Rfc=""; 
            _TipoEmisor=""; 
            _Calle=""; 
            _NoExterior=""; 
            _NoInterior=""; 
            _Colonia=""; 
            _Localidad=""; 
            _Referencia=""; 
            _Municipio=""; 
            _Estado=""; 
            _CorreoElectronico="";
            _CP=""; 

            ObjDataAcces = new DataAcces();
        }

        #region Eventos


        public List<cliente> Get(string Condiciones)
        {
            try
            {
                List<cliente> Listcompania = new List<cliente>();
                string consulta = " select " +
                                 " PkClienteId," +
                                 " FKCompaniaId,"+
                                 " RazonSocial,"+
                                 " Rfc,"+
                                 " TipoEmisor, "+
                                 " Calle, "+
                                 " NoExterior, "+
                                 " NoInterior," +
                                 " Colonia, "+
                                 " Localidad, "+
                                 " Referencia," +
                                 " Municipio," +
                                 " Estado, "+
                                 " CorreoElectronico,"+
                                 " CP "+
                                 " from TblClientes ";

                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    cliente ObjCliente = new cliente();
                    ObjCliente.PkClienteId = Convert.ToInt32(datos[0]);
                    ObjCliente.FKCompaniaId = Convert.ToInt32(datos[1]);
                    ObjCliente.RazonSocial = Convert.ToString(datos[2]);
                    ObjCliente.Rfc = Convert.ToString(datos[3]);
                    ObjCliente.Calle = Convert.ToString(datos[4]);
                    ObjCliente.Calle = Convert.ToString(datos[5]);
                    ObjCliente.NoExterior = Convert.ToString(datos[6]);
                    ObjCliente.NoInterior = Convert.ToString(datos[7]);
                    ObjCliente.Colonia = Convert.ToString(datos[8]);
                    ObjCliente.Localidad = Convert.ToString(datos[9]);
                    ObjCliente.Referencia = Convert.ToString(datos[10]);
                    ObjCliente.Municipio = Convert.ToString(datos[11]);
                    ObjCliente.Estado = Convert.ToString(datos[12]);
                    ObjCliente.CorreoElectronico = Convert.ToString(datos[13]);
                    ObjCliente.CP = Convert.ToString(datos[14]);
                    // Los agregamos a la lista
                    Listcompania.Add(ObjCliente);
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

        public cliente GetbyID(int id)
        {
            try
            {
                cliente ObjCliente = new cliente();
                string consulta = " select " +
                                  " PkClienteId," +
                                  " FKCompaniaId," +
                                  " RazonSocial," +
                                  " Rfc," +
                                  " TipoEmisor, " +
                                  " Calle, " +
                                  " NoExterior, " +
                                  " NoInterior," +
                                  " Colonia, " +
                                  " Localidad, " +
                                  " Referencia," +
                                  " Municipio," +
                                  " Estado, " +
                                  " CorreoElectronico," +
                                  " CP " +
                                " from TblClientes "+
                                " where PkClienteId=@PkClienteId";

                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                cmd.Parameters.AddWithValue("@PkClienteId", id);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    ObjCliente.PkClienteId = Convert.ToInt32(datos[0]);
                    ObjCliente.FKCompaniaId = Convert.ToInt32(datos[1]);
                    ObjCliente.RazonSocial = Convert.ToString(datos[2]);
                    ObjCliente.Rfc = Convert.ToString(datos[3]);
                    ObjCliente.Calle = Convert.ToString(datos[4]);
                    ObjCliente.Calle = Convert.ToString(datos[5]);
                    ObjCliente.NoExterior = Convert.ToString(datos[6]);
                    ObjCliente.NoInterior = Convert.ToString(datos[7]);
                    ObjCliente.Colonia = Convert.ToString(datos[8]);
                    ObjCliente.Localidad = Convert.ToString(datos[9]);
                    ObjCliente.Referencia = Convert.ToString(datos[10]);
                    ObjCliente.Municipio = Convert.ToString(datos[11]);
                    ObjCliente.Estado = Convert.ToString(datos[12]);
                    ObjCliente.CorreoElectronico = Convert.ToString(datos[13]);
                    ObjCliente.CP = Convert.ToString(datos[14]);
                    // Los agregamos a la lista
                }
                datos.Close();
                ObjDataAcces.Close();

                return ObjCliente;
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        public void Insert(cliente PCliente)
        {
            try
            {
                string StrSQl;
                if (existe(PCliente))
                {
                    StrSQl = " UPDATE TblClientes" +
                                  " SET " +
                                  " FKCompaniaId=@FKCompaniaId," +
                                  " RazonSocial=@RazonSocial," +
                                  " Rfc=@Rfc," +
                                  " TipoEmisor=@TipoEmisor, " +
                                  " Calle=@Calle, " +
                                  " NoExterior=@NoExterior, " +
                                  " NoInterior=@NoInterior," +
                                  " Colonia=@Colonia, " +
                                  " Localidad=@Localidad, " +
                                  " Referencia=@Referencia," +
                                  " Municipio=@Municipio," +
                                  " Estado=@Estado, " +
                                  " CorreoElectronico=@CorreoElectronico," +
                                  " CP=@CP " +
                                  " WHERE PkClienteId=@PkClienteId";

                    var insertSQL = new SQLiteCommand(StrSQl, ObjDataAcces.Conexion);

                    insertSQL.Parameters.AddWithValue("@FKCompaniaId", PCliente.RazonSocial);
                    insertSQL.Parameters.AddWithValue("@RazonSocial", PCliente.RazonSocial);
                    insertSQL.Parameters.AddWithValue("@Rfc", PCliente.Rfc);
                    insertSQL.Parameters.AddWithValue("@Calle", PCliente.Calle);
                    insertSQL.Parameters.AddWithValue("@NoExterior", PCliente.NoExterior);
                    insertSQL.Parameters.AddWithValue("@NoInterior", PCliente.NoInterior);
                    insertSQL.Parameters.AddWithValue("@Colonia", PCliente.Colonia);
                    insertSQL.Parameters.AddWithValue("@Localidad", PCliente.Localidad);
                    insertSQL.Parameters.AddWithValue("@MReferencia", PCliente.Referencia);
                    insertSQL.Parameters.AddWithValue("@Municipio", PCliente.Municipio);
                    insertSQL.Parameters.AddWithValue("@Estado", PCliente.Estado);
                    insertSQL.Parameters.AddWithValue("@CorreoElectronico", PCliente.CorreoElectronico);
                    insertSQL.Parameters.AddWithValue("@CP", PCliente.CP);
                    insertSQL.Parameters.AddWithValue("@PkClienteId", PCliente.PkClienteId);

                    ObjDataAcces.Open();
                    insertSQL.ExecuteNonQuery(); //Execute query
                    ObjDataAcces.Close();
                }
                else
                {
                    StrSQl = " INSERT INTO TblClientes" +
                                    " (FKCompaniaId,"+
                                    " RazonSocial,"+
                                    " Rfc,"+
                                    " TipoEmisor, "+
                                    " Calle, "+
                                    " NoExterior, "+
                                    " NoInterior," +
                                    " Colonia, "+
                                    " Localidad, "+
                                    " Referencia," +
                                    " Municipio," +
                                    " Estado, "+
                                    " CorreoElectronico,"+
                                    " CP ) "+
                                   "VALUES " +
                                 " (FKCompaniaId,"+
                                 " RazonSocial,"+
                                 " Rfc,"+
                                 " TipoEmisor, "+
                                 " Calle, "+
                                 " NoExterior, "+
                                 " NoInterior," +
                                 " Colonia, "+
                                 " Localidad, "+
                                 " Referencia," +
                                 " Municipio," +
                                 " Estado, "+
                                 " CorreoElectronico,"+
                                 " CP) ";

                    var insertSQL = new SQLiteCommand(StrSQl, ObjDataAcces.Conexion);

                    insertSQL.Parameters.AddWithValue("@FKCompaniaId", PCliente.RazonSocial);
                    insertSQL.Parameters.AddWithValue("@RazonSocial", PCliente.RazonSocial);
                    insertSQL.Parameters.AddWithValue("@Rfc", PCliente.Rfc);
                    insertSQL.Parameters.AddWithValue("@Calle", PCliente.Calle);
                    insertSQL.Parameters.AddWithValue("@NoExterior", PCliente.NoExterior);
                    insertSQL.Parameters.AddWithValue("@NoInterior", PCliente.NoInterior);
                    insertSQL.Parameters.AddWithValue("@Colonia", PCliente.Colonia);
                    insertSQL.Parameters.AddWithValue("@Localidad", PCliente.Localidad);
                    insertSQL.Parameters.AddWithValue("@MReferencia", PCliente.Referencia);
                    insertSQL.Parameters.AddWithValue("@Municipio", PCliente.Municipio);
                    insertSQL.Parameters.AddWithValue("@Estado", PCliente.Estado);
                    insertSQL.Parameters.AddWithValue("@CorreoElectronico", PCliente.CorreoElectronico);
                    insertSQL.Parameters.AddWithValue("@CP", PCliente.CP);

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
                var insertSQL = new SQLiteCommand("Delete From TblClientes WHERE PkClienteId=@PkClienteId", ObjDataAcces.Conexion);

                insertSQL.Parameters.AddWithValue("@PkClienteId", Id);
                ObjDataAcces.Open();
                insertSQL.ExecuteNonQuery(); //Execute query
                ObjDataAcces.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private bool existe(cliente PCliente)
        {
            try
            {
                cliente ObjCliente = new cliente();
                bool Resultado = false;

                ObjCliente = GetbyID(PCliente.PkClienteId);
                if (ObjCliente != null)
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