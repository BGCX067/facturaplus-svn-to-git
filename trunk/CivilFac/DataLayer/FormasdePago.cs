using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace DataLayer
{
    public class FormadePago
    {

        #region Propiedades

        private DataAcces ObjDataAcces;

        private int _PKFormadePagoId;
        private string _FormadePago;



        public int PKFormadePagoId
        {
            get { return _PKFormadePagoId; }
            set { _PKFormadePagoId = value; }
        }

        public string FormadePagoDesc
        {
            get { return _FormadePago; }
            set { _FormadePago = value; }
        }


        #endregion

        public FormadePago()
        {
            _PKFormadePagoId = -1;
            _FormadePago = "";

            ObjDataAcces = new DataAcces();
        }

        #region Eventos


        public List<FormadePago> Get(string Condiciones)
        {
            try
            {
                List<FormadePago> Listcompania = new List<FormadePago>();
                string consulta = " select " +
                                 " PKFormadePagoId" +
                                 " ,FormadePago" +
                                 " from TblFormadePago ";

                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    FormadePago ObjFormadePago = new FormadePago();
                    ObjFormadePago.PKFormadePagoId = Convert.ToInt32(datos[0]);
                    ObjFormadePago.FormadePagoDesc = Convert.ToString(datos[1]);

                    // Los agregamos a la lista
                    Listcompania.Add(ObjFormadePago);
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

        public FormadePago GetbyID(int id)
        {
            try
            {
                FormadePago ObjFormadePago = new FormadePago();
                string consulta = " select " +
                                 " PKFormadePagoId" +
                                 " ,FormadePago" +
                                 " from TblFormadePago " +
                                " where PkFormadePagoId=@PkFormadePagoId";

                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                cmd.Parameters.AddWithValue("@PkFormadePagoId", id);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    ObjFormadePago.PKFormadePagoId = Convert.ToInt32(datos[0]);
                    ObjFormadePago.FormadePagoDesc = Convert.ToString(datos[1]);

                    // Los agregamos a la lista
                }
                datos.Close();
                ObjDataAcces.Close();

                return ObjFormadePago;
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        public void Insert(FormadePago PFormadePago)
        {
            try
            {
                string StrSQl;
                if (existe(PFormadePago))
                {
                    StrSQl = " UPDATE TblFormadePago" +
                                  " SET " +
                                 " ,FormadePago=@FormadePago" +
                                  " WHERE PkFormadePagoId=@PkFormadePagoId";

                    var insertSQL = new SQLiteCommand(StrSQl, ObjDataAcces.Conexion);

                    insertSQL.Parameters.AddWithValue("@FormadePago", PFormadePago.FormadePagoDesc);
                    insertSQL.Parameters.AddWithValue("@PkFormadePagoId", PFormadePago.PKFormadePagoId);



                    ObjDataAcces.Open();
                    insertSQL.ExecuteNonQuery(); //Execute query
                    ObjDataAcces.Close();
                }
                else
                {
                    StrSQl = " INSERT INTO TblFormadePago" +
                                    " (FormadePago)" +
                                     " VALUES " +
                                    " (@FormadePago)";


                    var insertSQL = new SQLiteCommand(StrSQl, ObjDataAcces.Conexion);

                    insertSQL.Parameters.AddWithValue("@FKCompaniaId", PFormadePago.FormadePagoDesc);


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
                var insertSQL = new SQLiteCommand("Delete From TblFormadePago WHERE PkFormadePagoId=@PkFormadePagoId", ObjDataAcces.Conexion);

                insertSQL.Parameters.AddWithValue("@PkFormadePagoId", Id);
                ObjDataAcces.Open();
                insertSQL.ExecuteNonQuery(); //Execute query
                ObjDataAcces.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private bool existe(FormadePago PFormadePago)
        {
            try
            {
                FormadePago ObjFormadePago = new FormadePago();
                bool Resultado = false;

                ObjFormadePago = GetbyID(PFormadePago.PKFormadePagoId);
                if (ObjFormadePago != null)
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