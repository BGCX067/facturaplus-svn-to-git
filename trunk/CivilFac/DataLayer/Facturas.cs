using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace DataLayer
{
    public class facturas
    {

        #region Propiedades

        private DataAcces ObjDataAcces;

        private int _PKUnidadMedidaId;
        private string _UnidaddeMedida;



        public int PKUnidadMedidaId
        {
            get { return _PKUnidadMedidaId; }
            set { _PKUnidadMedidaId = value; }
        }

        public string UnidaddeMedida
        {
            get { return _UnidaddeMedida; }
            set { _UnidaddeMedida = value; }
        }


        #endregion

        public UnidadesdeMedida()
        {
            _PKUnidadMedidaId = -1;
            _UnidaddeMedida = "";

            ObjDataAcces = new DataAcces();
        }

        #region Eventos


        public List<UnidadesdeMedida> Get(string Condiciones)
        {
            try
            {
                List<UnidadesdeMedida> ListUnidadesdeMedida = new List<UnidadesdeMedida>();
                string consulta = " select " +
                                 " PKUnidadMedidaId" +
                                 " ,UnidaddeMedida" +
                                 " from TblUnidadesMedida ";

                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    UnidadesdeMedida ObjUnidadMedida = new UnidadesdeMedida();
                    ObjUnidadMedida._PKUnidadMedidaId = Convert.ToInt32(datos[0]);
                    ObjUnidadMedida._UnidaddeMedida = Convert.ToString(datos[1]);

                    // Los agregamos a la lista
                    ListUnidadesdeMedida.Add(ObjUnidadMedida);
                }
                datos.Close();
                ObjDataAcces.Close();

                return ListUnidadesdeMedida;
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        public UnidadesdeMedida GetbyID(int id)
        {
            try
            {
                UnidadesdeMedida ObjUnidadMedida = new UnidadesdeMedida();
                string consulta = " select " +
                                 " PKUnidadMedidaId" +
                                 " ,UnidaddeMedida" +
                                 " from TblUnidadesMedida " +
                                " where PkUnidadMedidaId=@PkUnidadMedidaId";

                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                cmd.Parameters.AddWithValue("@PKUnidadMedidaId", id);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    ObjUnidadMedida._PKUnidadMedidaId = Convert.ToInt32(datos[0]);
                    ObjUnidadMedida._UnidaddeMedida = Convert.ToString(datos[1]);

                    // Los agregamos a la lista
                }
                datos.Close();
                ObjDataAcces.Close();

                return ObjUnidadMedida;
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        public void Insert(UnidadesdeMedida PUnidadMedida)
        {
            try
            {
                string StrSQl;
                if (existe(PUnidadMedida))
                {
                    StrSQl = " UPDATE TblUnidadMedidas" +
                                  " SET " +
                                 " UnidaddeMedida=@UnidaddeMedida" +
                                  " WHERE PKUnidadMedidaId=@PKUnidadMedidaId";

                    var insertSQL = new SQLiteCommand(StrSQl, ObjDataAcces.Conexion);

                    insertSQL.Parameters.AddWithValue("@UnidaddeMedida", PUnidadMedida._UnidaddeMedida);
                    insertSQL.Parameters.AddWithValue("@PKUnidadMedidaId", PUnidadMedida._PKUnidadMedidaId);



                    ObjDataAcces.Open();
                    insertSQL.ExecuteNonQuery(); //Execute query
                    ObjDataAcces.Close();
                }
                else
                {
                    StrSQl = " INSERT INTO TblUnidadesMedida" +
                                    " (UnidaddeMedida)" +
                                     " VALUES " +
                                    " (@UnidaddeMedida)";


                    var insertSQL = new SQLiteCommand(StrSQl, ObjDataAcces.Conexion);

                    insertSQL.Parameters.AddWithValue("@UnidaddeMedida", PUnidadMedida._UnidaddeMedida);


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
                var insertSQL = new SQLiteCommand("Delete From TblUnidadesMedida WHERE PKUnidadMedidaId=@PKUnidadMedidaId", ObjDataAcces.Conexion);

                insertSQL.Parameters.AddWithValue("@PKUnidadMedidaId", Id);
                ObjDataAcces.Open();
                insertSQL.ExecuteNonQuery(); //Execute query
                ObjDataAcces.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private bool existe(UnidadesdeMedida PUnidadMedida)
        {
            try
            {
                UnidadesdeMedida ObjUnidadMedida = new UnidadesdeMedida();
                bool Resultado = false;

                ObjUnidadMedida = GetbyID(PUnidadMedida._PKUnidadMedidaId);
                if (ObjUnidadMedida != null)
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