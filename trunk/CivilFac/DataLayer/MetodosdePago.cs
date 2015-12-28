using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace DataLayer
{
    public class MetodoPago
    {

        #region Propiedades

        private DataAcces ObjDataAcces;

        private int _PKMetodoPagoId;
        private string _MetododePago;



        public int PKMetodoPagoId
        {
            get { return _PKMetodoPagoId; }
            set { _PKMetodoPagoId = value; }
        }

        public string MetododePago
        {
            get { return _MetododePago; }
            set { _MetododePago = value; }
        }


        #endregion

        public MetodoPago()
        {
            _PKMetodoPagoId = -1;
            _MetododePago = "";

            ObjDataAcces = new DataAcces();
        }

        #region Eventos


        public List<MetodoPago> Get(string Condiciones)
        {
            try
            {
                List<MetodoPago> Listcompania = new List<MetodoPago>();
                string consulta = " select " +
                                 " PKMetodoPagoId" +
                                 " ,MetododePago" +
                                 " from TblMetodoPago ";

                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    MetodoPago ObjMetodoPago = new MetodoPago();
                    ObjMetodoPago.PKMetodoPagoId = Convert.ToInt32(datos[0]);
                    ObjMetodoPago.MetododePago = Convert.ToString(datos[1]);

                    // Los agregamos a la lista
                    Listcompania.Add(ObjMetodoPago);
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

        public MetodoPago GetbyID(int id)
        {
            try
            {
                MetodoPago ObjMetodoPago = new MetodoPago();
                string consulta = " select " +
                                 " PKMetodoPagoId" +
                                 " ,MetododePago" +
                                 " from TblMetodoPago " +
                                " where PkMetodoPagoId=@PkMetodoPagoId";

                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                cmd.Parameters.AddWithValue("@PkMetodoPagoId", id);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    ObjMetodoPago.PKMetodoPagoId = Convert.ToInt32(datos[0]);
                    ObjMetodoPago.MetododePago = Convert.ToString(datos[1]);

                    // Los agregamos a la lista
                }
                datos.Close();
                ObjDataAcces.Close();

                return ObjMetodoPago;
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        public void Insert(MetodoPago PMetodoPago)
        {
            try
            {
                string StrSQl;
                if (existe(PMetodoPago))
                {
                    StrSQl = " UPDATE TblMetodoPago" +
                                  " SET " +
                                 " ,MetododePago=@MetododePago" +
                                  " WHERE PkMetodoPagoId=@PkMetodoPagoId";

                    var insertSQL = new SQLiteCommand(StrSQl, ObjDataAcces.Conexion);

                    insertSQL.Parameters.AddWithValue("@MetodoPago", PMetodoPago.MetododePago);
                    insertSQL.Parameters.AddWithValue("@PkMetodoPagoId", PMetodoPago.PKMetodoPagoId);



                    ObjDataAcces.Open();
                    insertSQL.ExecuteNonQuery(); //Execute query
                    ObjDataAcces.Close();
                }
                else
                {
                    StrSQl = " INSERT INTO TblMetodoPago" +
                                    " (MetododePago)" +
                                     " VALUES " +
                                    " (@MetododePago)";


                    var insertSQL = new SQLiteCommand(StrSQl, ObjDataAcces.Conexion);

                    insertSQL.Parameters.AddWithValue("@MetododePago", PMetodoPago.MetododePago);


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
                var insertSQL = new SQLiteCommand("Delete From TblMetodoPago WHERE PkMetodoPagoId=@PkMetodoPagoId", ObjDataAcces.Conexion);

                insertSQL.Parameters.AddWithValue("@PkMetodoPagoId", Id);
                ObjDataAcces.Open();
                insertSQL.ExecuteNonQuery(); //Execute query
                ObjDataAcces.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private bool existe(MetodoPago PMetodoPago)
        {
            try
            {
                MetodoPago ObjMetodoPago = new MetodoPago();
                bool Resultado = false;

                ObjMetodoPago = GetbyID(PMetodoPago.PKMetodoPagoId);
                if (ObjMetodoPago != null)
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