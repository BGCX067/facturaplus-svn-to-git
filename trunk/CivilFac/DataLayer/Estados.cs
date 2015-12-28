using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace DataLayer
{
    public class Estado
    {

        #region Propiedades

        private DataAcces ObjDataAcces;

        private int _PKEstadoId;
        private string _Estado;
        


        public int PKEstadoId
        {
            get { return _PKEstadoId; }
            set { _PKEstadoId = value; }
        }

        public string EstadoNombre
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        
        #endregion

        public Estado()
        {
            _PKEstadoId = -1;
            _Estado = "";
            
            ObjDataAcces = new DataAcces();
        }

        #region Eventos


        public List<Estado> Get(string Condiciones)
        {
            try
            {
                List<Estado> Listcompania = new List<Estado>();
                string consulta = " select " +
                                 " PKEstadoId" +
                                 " ,estado" +
                                 " from TblEstados ";

                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    Estado ObjEstado = new Estado();
                    ObjEstado.PKEstadoId = Convert.ToInt32(datos[0]);
                    ObjEstado.EstadoNombre = Convert.ToString(datos[1]);
                   
                    // Los agregamos a la lista
                    Listcompania.Add(ObjEstado);
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

        public Estado GetbyID(int id)
        {
            try
            {
                Estado ObjEstado = new Estado();
                string consulta = " select " +
                                 " PKEstadoId" +
                                 " ,estado" +
                                 " from TblEstados " +
                                " where PkEstadoId=@PkEstadoId";

                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                cmd.Parameters.AddWithValue("@PkEstadoId", id);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    ObjEstado.PKEstadoId = Convert.ToInt32(datos[0]);
                    ObjEstado.EstadoNombre = Convert.ToString(datos[1]);
                   
                    // Los agregamos a la lista
                }
                datos.Close();
                ObjDataAcces.Close();

                return ObjEstado;
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        public void Insert(Estado PEstado)
        {
            try
            {
                string StrSQl;
                if (existe(PEstado))
                {
                    StrSQl = " UPDATE TblEstados" +
                                  " SET " +
                                 " ,estado=@estado" +
                                  " WHERE PkEstadoId=@PkEstadoId";

                    var insertSQL = new SQLiteCommand(StrSQl, ObjDataAcces.Conexion);

                    insertSQL.Parameters.AddWithValue("@estado", PEstado.EstadoNombre);
                    insertSQL.Parameters.AddWithValue("@PkEstadoId", PEstado.PKEstadoId);
                


                    ObjDataAcces.Open();
                    insertSQL.ExecuteNonQuery(); //Execute query
                    ObjDataAcces.Close();
                }
                else
                {
                    StrSQl = " INSERT INTO TblEstados" +
                                    " (estado)" +
                                     " VALUES " +
                                    " (@estado)";
                                    

                    var insertSQL = new SQLiteCommand(StrSQl, ObjDataAcces.Conexion);

                    insertSQL.Parameters.AddWithValue("@FKCompaniaId", PEstado.EstadoNombre);
                   

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
                var insertSQL = new SQLiteCommand("Delete From TblEstados WHERE PkEstadoId=@PkEstadoId", ObjDataAcces.Conexion);

                insertSQL.Parameters.AddWithValue("@PkEstadoId", Id);
                ObjDataAcces.Open();
                insertSQL.ExecuteNonQuery(); //Execute query
                ObjDataAcces.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private bool existe(Estado PEstado)
        {
            try
            {
                Estado ObjEstado = new Estado();
                bool Resultado = false;

                ObjEstado = GetbyID(PEstado.PKEstadoId);
                if (ObjEstado != null)
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