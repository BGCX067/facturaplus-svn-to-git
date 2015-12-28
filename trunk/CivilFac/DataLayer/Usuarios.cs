using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace DataLayer
{
    public class Usuario
    {

        #region Propiedades

        private DataAcces ObjDataAcces;

        private int _PKUsuarioId;
        private int _FKCompaniaId;
        private string _Nombre;
        private string _Apellidos;
        private string _Puesto;
        private string _Rol;
        private string _Password;
        private int _Bloqueado;


        public int PKUsuarioId
        {
            get { return _PKUsuarioId; }
            set { _PKUsuarioId = value; }
        }

        public int FKCompaniaId
        {
            get { return _FKCompaniaId; }
            set { _FKCompaniaId = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }

       

        public string Puesto
        {
            get { return _Puesto; }
            set { _Puesto = value; }
        }

        public string Rol
        {
            get { return _Rol; }
            set { _Rol = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public bool Bloqueado
        {
            get { return Convert.ToBoolean( _Bloqueado); }
            set
            {
                if (value = true)
                    _Bloqueado = 1;
                else
                    _Bloqueado = 0;
            }
        }

        #endregion

        public Usuario()
        {
        _PKUsuarioId=-1;
        _FKCompaniaId=-1;
        _Nombre="";
        _Apellidos="";
        _Puesto="";
        _Rol="";
        _Password="";
        _Bloqueado=-1;

        ObjDataAcces = new DataAcces();
        }

        #region Eventos


        public List<Usuario> Get(string Condiciones)
        {
            try
            {
                List<Usuario> ListUsuario = new List<Usuario>();
                StringBuilder consulta = new StringBuilder();
                consulta.Append(" select ");
                consulta.Append(" PkUsuarioId,");
                consulta.Append(" ,FKCompaniaId");
                consulta.Append(" ,Nombre");
                consulta.Append(" ,Apellidos");
                consulta.Append(" ,Puesto");
                consulta.Append(" ,Rol");
                consulta.Append(" ,Password");
                consulta.Append(" ,Bloqueado");
                consulta.Append(" from tblUsuarios ");

                SQLiteCommand cmd = new SQLiteCommand(consulta.ToString(), ObjDataAcces.Conexion);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    Usuario ObjUsuario = new Usuario();
                    ObjUsuario._PKUsuarioId = Convert.ToInt32(datos[0]);
                    ObjUsuario._FKCompaniaId = Convert.ToInt32(datos[1]);
                    ObjUsuario._Nombre = Convert.ToString(datos[2]);
                    ObjUsuario._Apellidos = Convert.ToString(datos[3]);
                    ObjUsuario._Puesto = Convert.ToString(datos[4]);
                    ObjUsuario._Rol = Convert.ToString(datos[5]);
                    ObjUsuario._Password = Convert.ToString(datos[6]);
                    ObjUsuario._Bloqueado = Convert.ToInt16(datos[7]);
                    
                    // Los agregamos a la lista
                    ListUsuario.Add(ObjUsuario);
                }
                datos.Close();
                ObjDataAcces.Close();

                return ListUsuario;
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        public Usuario GetbyID(int id)
        {
            try
            {
                Usuario ObjUsuario = new Usuario();
                StringBuilder consulta = new StringBuilder();
                consulta.Append(" select ");
                consulta.Append(" PkUsuarioId,");
                consulta.Append(" ,FKCompaniaId");
                consulta.Append(" ,Nombre");
                consulta.Append(" ,Apellidos");
                consulta.Append(" ,Puesto");
                consulta.Append(" ,Rol");
                consulta.Append(" ,Password");
                consulta.Append(" ,Bloqueado");
                consulta.Append(" from tblUsuarios ");
                consulta.Append(" where PkUsuarioId=@PkUsuarioId");

                SQLiteCommand cmd = new SQLiteCommand(consulta.ToString(), ObjDataAcces.Conexion);
                cmd.Parameters.AddWithValue("@PkUsuarioId", id);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    ObjUsuario._PKUsuarioId = Convert.ToInt32(datos[0]);
                    ObjUsuario._FKCompaniaId = Convert.ToInt32(datos[1]);
                    ObjUsuario._Nombre = Convert.ToString(datos[2]);
                    ObjUsuario._Apellidos = Convert.ToString(datos[3]);
                    ObjUsuario._Puesto = Convert.ToString(datos[4]);
                    ObjUsuario._Rol = Convert.ToString(datos[5]);
                    ObjUsuario._Password = Convert.ToString(datos[6]);
                    ObjUsuario._Bloqueado = Convert.ToInt16(datos[7]);
                    // Los agregamos a la lista
                }
                datos.Close();
                ObjDataAcces.Close();

                return ObjUsuario;
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        public void Insert(Usuario PUsuario)
        {
            try
            {
               
                if (existe(PUsuario))
                {
                    StringBuilder consulta = new StringBuilder();
                    consulta.Append(" UPDATE TblUsuarios ");
                    consulta.Append(" SET ");
                    consulta.Append(" ,FKCompaniaId=@FKCompaniaId");
                    consulta.Append(" ,Nombre=@Nombre");
                    consulta.Append(" ,Apellidos=@Apellidos");
                    consulta.Append(" ,Puesto=@Puesto");
                    consulta.Append(" ,Rol=@Rol");
                    consulta.Append(" ,Password=@Password");
                    consulta.Append(" ,Bloqueado=@Bloqueado");
                    consulta.Append(" from tblUsuarios ");
                    consulta.Append(" where PkUsuarioId=@PkUsuarioId");

                    var insertSQL = new SQLiteCommand(consulta.ToString(), ObjDataAcces.Conexion);

                    insertSQL.Parameters.AddWithValue("@FKCompaniaId", PUsuario._FKCompaniaId);
                    insertSQL.Parameters.AddWithValue("@Nombre", PUsuario._Nombre);
                    insertSQL.Parameters.AddWithValue("@Apellidos", PUsuario._Apellidos);
                    insertSQL.Parameters.AddWithValue("@Puesto", PUsuario._Puesto);
                    insertSQL.Parameters.AddWithValue("@Rol", PUsuario._Rol);
                    insertSQL.Parameters.AddWithValue("@Password", PUsuario._Password);
                    insertSQL.Parameters.AddWithValue("@Bloqueado", PUsuario._Bloqueado);
                    insertSQL.Parameters.AddWithValue("@PkUsuarioId", PUsuario._PKUsuarioId);

                    ObjDataAcces.Open();
                    insertSQL.ExecuteNonQuery(); //Execute query
                    ObjDataAcces.Close();
                }
                else
                {
                  
                    StringBuilder consulta = new StringBuilder();
                    consulta.Append(" insert into  TblUsuarios ");
                    consulta.Append(" ( FKCompaniaId");
                    consulta.Append(" ,Nombre");
                    consulta.Append(" ,Apellidos");
                    consulta.Append(" ,Puesto");
                    consulta.Append(" ,Rol");
                    consulta.Append(" ,Password");
                    consulta.Append(" ,Bloqueado )");
                    consulta.Append(" VALUES ");
                    consulta.Append(" ( @FKCompaniaId");
                    consulta.Append(" ,@Nombre");
                    consulta.Append(" ,@Apellidos");
                    consulta.Append(" ,@Puesto");
                    consulta.Append(" ,@Rol");
                    consulta.Append(" ,@Password");
                    consulta.Append(" ,@Bloqueado )");


                    var insertSQL = new SQLiteCommand(consulta.ToString(), ObjDataAcces.Conexion);

                    insertSQL.Parameters.AddWithValue("@FKCompaniaId", PUsuario._FKCompaniaId);
                    insertSQL.Parameters.AddWithValue("@Nombre", PUsuario._Nombre);
                    insertSQL.Parameters.AddWithValue("@Apellidos", PUsuario._Apellidos);
                    insertSQL.Parameters.AddWithValue("@Puesto", PUsuario._Puesto);
                    insertSQL.Parameters.AddWithValue("@Rol", PUsuario._Rol);
                    insertSQL.Parameters.AddWithValue("@Password", PUsuario._Password);
                    insertSQL.Parameters.AddWithValue("@Bloqueado", PUsuario._Bloqueado);
                    insertSQL.Parameters.AddWithValue("@PkUsuarioId", PUsuario._PKUsuarioId);

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
                var insertSQL = new SQLiteCommand("Delete From TblUsuarios WHERE PkUsuarioId=@PkUsuarioId", ObjDataAcces.Conexion);

                insertSQL.Parameters.AddWithValue("@PkUsuarioId", Id);
                ObjDataAcces.Open();
                insertSQL.ExecuteNonQuery(); //Execute query
                ObjDataAcces.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private bool existe(Usuario PUsuario)
        {
            try
            {
                Usuario ObjUsuario = new Usuario();
                bool Resultado = false;

                ObjUsuario = GetbyID(PUsuario._PKUsuarioId);
                if (ObjUsuario != null)
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


//string SQL = "SELECT count(ifnull(PKUsuarioId)+1) FROM TblUsuario ;";

//SQLiteCommand cmd = new SQLiteCommand(SQL, Conexion);

//Conexion.Open();
//object result = cmd.ExecuteScalar();
//int PKUsuarioId = Convert.ToInt32(result);
//Conexion.Close();