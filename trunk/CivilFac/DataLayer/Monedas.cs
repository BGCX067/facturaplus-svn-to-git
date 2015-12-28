using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace DataLayer
{
    public class Moneda
    {
        private DataAcces ObjDataAcces;

        private int _PKMonedaId;
        private string _DescMoneda;
        private string _TipoCambio;
        private string _Prefijo;
        private string _Simbolo;

        public int PKMonedaId
        {
            get { return _PKMonedaId; }
            set { _PKMonedaId = value; }
        }

        public string DescMoneda
        {
            get { return _DescMoneda; }
            set { _DescMoneda = value; }
        }

        public decimal  TipoCambio
        {
            get { return System.Convert.ToDecimal(_TipoCambio); }
            set { _TipoCambio = System.Convert.ToString(value); }
        }

        public string Prefijo
        {
            get { return _Prefijo; }
            set { _Prefijo = value; }
        }

        public string Simbolo
        {
            get { return _Simbolo; }
            set { _Simbolo = value; }
        }


        public Moneda()
        {
        _PKMonedaId=-1;
        _DescMoneda = "";
        _TipoCambio="1";
        _Prefijo="";
        _Simbolo="";
            ObjDataAcces = new DataAcces();
        }

        public List<Moneda> Get(string Condiciones)
        {
            try
            {
                List<Moneda> ListMonedas = new List<Moneda>();
                string consulta = "select * from TblMonedas";
                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    Moneda ObjMonedas = new Moneda();

                    ObjMonedas._PKMonedaId = Convert.ToInt32(datos[0]);
                    ObjMonedas._DescMoneda = Convert.ToString(datos[1]);
                    ObjMonedas._TipoCambio = Convert.ToString(datos[2]);
                    ObjMonedas._Prefijo = Convert.ToString(datos[3]);
                    ObjMonedas._Simbolo = Convert.ToString(datos[4]);

                    // Los agregamos a la lista
                    ListMonedas.Add(ObjMonedas);
                }
                datos.Close();
                ObjDataAcces.Close();

                return ListMonedas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Moneda GetbyID(int id)
        {
            try
            {
                Moneda ObjMonedas = new Moneda();

                string consulta = "select * from TblMonedas where PKMonedaid=@PKMonedaId ";
                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                cmd.Parameters.AddWithValue("@PKMonedaId", id);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();
                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {

                    ObjMonedas._PKMonedaId = Convert.ToInt32(datos[0]);
                    ObjMonedas._DescMoneda = Convert.ToString(datos[1]);
                    ObjMonedas._TipoCambio = Convert.ToString(datos[2]);
                    ObjMonedas._Prefijo = Convert.ToString(datos[3]);
                    ObjMonedas._Simbolo = Convert.ToString(datos[4]);
                    // Los agregamos a la lista

                }
                datos.Close();
                ObjDataAcces.Close();

                return ObjMonedas;
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        public void Insert(Moneda PMoneda)
        {
            try
            {
                if (existe(PMoneda))
                {
                    var insertSQL = new SQLiteCommand(" UPDATE TblMonedas " +
                                                      "SET  " +
                                                      "Moneda=@Moneda " +
                                                      ",TipoCambio=@TipoCambio " +
                                                      ",Prefijo=@Prefijo " +
                                                      ",Simbolo=@Simbolo " +
                                                       " WHERE PKMonedaId=@PKMonedaId", ObjDataAcces.Conexion);

                    insertSQL.Parameters.AddWithValue("@Moneda", PMoneda._DescMoneda);
                    insertSQL.Parameters.AddWithValue("@TipoCambio", PMoneda._TipoCambio);
                    insertSQL.Parameters.AddWithValue("@Prefijo", PMoneda._Prefijo);
                    insertSQL.Parameters.AddWithValue("@Simbolo", PMoneda._Simbolo);
                    insertSQL.Parameters.AddWithValue("@PKMonedaId", PMoneda._PKMonedaId);
                    ObjDataAcces.Open();
                    insertSQL.ExecuteNonQuery(); //Execute query
                    ObjDataAcces.Close();
                }
                else
                {
                    var insertSQL = new SQLiteCommand("INSERT INTO TblMonedas " +
                                                      "(Moneda, " +
                                                      "TipoCambio," +
                                                      "Prefijo," +
                                                      "Simbolo)" +
                                                       " VALUES " +
                                                      "(@Moneda, " +
                                                      "@TipoCambio," +
                                                      "@Prefijo," +
                                                      "@Simbolo)" ,
                                                      ObjDataAcces.Conexion);

                    insertSQL.Parameters.AddWithValue("@Moneda", PMoneda._DescMoneda);
                    insertSQL.Parameters.AddWithValue("@TipoCambio", PMoneda._TipoCambio);
                    insertSQL.Parameters.AddWithValue("@Prefijo", PMoneda._Prefijo);
                    insertSQL.Parameters.AddWithValue("@Simbolo", PMoneda._Simbolo);
                    insertSQL.Parameters.AddWithValue("@PKMonedaId", PMoneda._PKMonedaId);
                    ObjDataAcces.Open();
                    insertSQL.ExecuteNonQuery(); //Execute query
                    ObjDataAcces.Close();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Delete(Int32 Id)
        {
            try
            {
                var insertSQL = new SQLiteCommand("Delete From TblMonedas WHERE PKMonedaId=@PKMonedaId", ObjDataAcces.Conexion);

                insertSQL.Parameters.AddWithValue("@PKMonedaId", Id);
                ObjDataAcces.Open();
                insertSQL.ExecuteNonQuery(); //Execute query
                ObjDataAcces.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private bool existe(Moneda PMoneda)
        {
            try
            {
                Moneda ObjMoneda = new Moneda();
                bool Resultado = false;

                ObjMoneda = GetbyID(PMoneda._PKMonedaId);
                if (ObjMoneda != null)
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
    }
}


//string SQL = "SELECT count(ifnull(PKMonedaId)+1) FROM TblMonedas ;";

//SQLiteCommand cmd = new SQLiteCommand(SQL, Conexion);

//Conexion.Open();
//object result = cmd.ExecuteScalar();
//int PKMonedaId = Convert.ToInt32(result);
//Conexion.Close();