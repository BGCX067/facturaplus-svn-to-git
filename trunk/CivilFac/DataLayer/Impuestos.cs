using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace DataLayer
{
   public class Impuesto
    {
       private DataAcces ObjDataAcces;
       
        private int _PKImpuestoId;
        private string _Impuesto;
        private int _Tasa;

        public int PKImpuestoId
        {
            get { return _PKImpuestoId; }
            set { _PKImpuestoId = value; }
        }

        public string DescImpuesto
        {
            get { return _Impuesto; }
            set { _Impuesto = value; }
        }

        public int Tasa
        {
            get { return _Tasa; }
            set { _Tasa = value; }
        }

        public Impuesto()
        {
           
            _PKImpuestoId = -1;
            _Impuesto = "";
            _Tasa = 0;
            ObjDataAcces = new DataAcces();
        }

        public  List<Impuesto> Get(string Condiciones)
        {
            try
            {
                List<Impuesto> ListImpuestos = new List<Impuesto>();
                string consulta = "select * from TblImpuestos";
                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    Impuesto ObjImpuestos = new Impuesto();

                    ObjImpuestos.PKImpuestoId = Convert.ToInt32(datos[0]);
                    ObjImpuestos.DescImpuesto = Convert.ToString(datos[1]);
                    ObjImpuestos.Tasa = Convert.ToInt32(datos[2]);
                    // Los agregamos a la lista
                    ListImpuestos.Add(ObjImpuestos);
                }
                datos.Close();
                ObjDataAcces.Close();

                return ListImpuestos;
            }
            catch (Exception)
            {
                throw;
            }
        }

         public  Impuesto GetbyID(int id)
        {
            try
            {
                Impuesto ObjImpuestos = new Impuesto();

                string consulta = "select * from Tblimpuestos where PKImpuestoid=@PKImpuestoId ";
                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                cmd.Parameters.AddWithValue("@PKImpuestoId", id);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();
                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {

                    ObjImpuestos.PKImpuestoId = Convert.ToInt32(datos[0]);
                    ObjImpuestos.DescImpuesto = Convert.ToString(datos[1]);
                    ObjImpuestos.Tasa = Convert.ToInt32(datos[2]);
                    // Los agregamos a la lista

                }
                datos.Close();
                ObjDataAcces.Close();

                return ObjImpuestos;
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        public void Insert(Impuesto Pimpuesto)
         {
             try
             {
                 if (existe(Pimpuesto))
                 {
                     var insertSQL = new SQLiteCommand(" UPDATE Tblimpuestos SET  Impuesto=@Impuesto, Tasa=@Tasa " +
                                                        " WHERE PKImpuestoId=@PKImpuestoId", ObjDataAcces.Conexion);

                     insertSQL.Parameters.AddWithValue("@Impuesto", Pimpuesto.DescImpuesto);
                     insertSQL.Parameters.AddWithValue("@Tasa", Pimpuesto.Tasa);
                     insertSQL.Parameters.AddWithValue("@PKImpuestoId", Pimpuesto.PKImpuestoId);
                     ObjDataAcces.Open();
                     insertSQL.ExecuteNonQuery(); //Execute query
                     ObjDataAcces.Close();
                 }
                 else
                 {
                     var insertSQL = new SQLiteCommand("INSERT INTO Tblimpuestos (Impuesto, Tasa)" +
                                                        " VALUES (@Impuesto, @Tasa)", ObjDataAcces.Conexion);

                     insertSQL.Parameters.AddWithValue("@Impuesto", Pimpuesto.DescImpuesto);
                     insertSQL.Parameters.AddWithValue("@Tasa", Pimpuesto.Tasa);
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
                var insertSQL = new SQLiteCommand("Delete From Tblimpuestos WHERE PKImpuestoId=@PKImpuestoId", ObjDataAcces.Conexion);

                insertSQL.Parameters.AddWithValue("@PKImpuestoId", Id);
                ObjDataAcces.Open();
                insertSQL.ExecuteNonQuery(); //Execute query
                ObjDataAcces.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
        
        private bool existe(Impuesto Pimpuesto)
        {
            try
            {
                Impuesto ObjImpuesto = new Impuesto();
                bool Resultado = false;

                ObjImpuesto = GetbyID(Pimpuesto.PKImpuestoId);
                if (ObjImpuesto != null)
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


//string SQL = "SELECT count(ifnull(PKImpuestoId)+1) FROM Tblimpuestos ;";

//SQLiteCommand cmd = new SQLiteCommand(SQL, Conexion);

//Conexion.Open();
//object result = cmd.ExecuteScalar();
//int PKImpuestoId = Convert.ToInt32(result);
//Conexion.Close();