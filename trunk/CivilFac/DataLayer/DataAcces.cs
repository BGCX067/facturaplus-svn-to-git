using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
namespace DataLayer
{
    public class DataAcces
    {
        private string RutaAplicacion = @Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["PathpDB"]);
        private SQLiteConnection _Conexion;

        public SQLiteConnection Conexion
        {
            get { return _Conexion; }
        }

        public void Open()
        {
            _Conexion.Open();
        }
        public void Close()
        {
            _Conexion.Close();
        }
        public  DataAcces()
        { 
          _Conexion = new SQLiteConnection(@"Data Source=" + System.Configuration.ConfigurationManager.AppSettings["PathpDB"] + ";Version=3;New=False;Compress=True;");
        }
    }
}
