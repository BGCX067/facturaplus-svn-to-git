using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;

namespace DataLayer
{
    public class Articulo
    {

        #region Propiedades

        private DataAcces ObjDataAcces;

       private int _PKArticuloId;
        private int _FKCompaniaId;
        private string _Descripcion;
        private string _ClaveInterna;
        private string _CodigoBarras;
        private decimal _PrecioUnitario;
        private bool _ManejaIVA;
        private int _FKImpuesto1;
        private int _FKImpuesto2;
        private int _FKImpuesto3;
        private int _FKUnidaddeMedidaId;
        private int _FKFamiliaId;
        private bool _ActivoSN;


        public int PKArticuloId
        {
            get { return _PKArticuloId; }
            set { _PKArticuloId = value; }
        }

        public int FKCompaniaId
        {
            get { return _FKCompaniaId; }
            set { _FKCompaniaId = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public string ClaveInterna
        {
            get { return _ClaveInterna; }
            set { _ClaveInterna = value; }
        }

        public string CodigoBarras
        {
            get { return _CodigoBarras; }
            set { _CodigoBarras = value; }
        }

        public decimal PrecioUnitario
        {
            get { return _PrecioUnitario; }
            set { _PrecioUnitario = value; }
        }

        public bool ManejaIVA
        {
            get { return _ManejaIVA; }
            set { _ManejaIVA = value; }
        }

        public int FKImpuesto1
        {
            get { return _FKImpuesto1; }
            set { _FKImpuesto1 = value; }
        }

        public int FKImpuesto2
        {
            get { return _FKImpuesto2; }
            set { _FKImpuesto2 = value; }
        }

        public int FKImpuesto3
        {
            get { return _FKImpuesto3; }
            set { _FKImpuesto3 = value; }
        }

        public int FKUnidaddeMedidaId
        {
            get { return _FKUnidaddeMedidaId; }
            set { _FKUnidaddeMedidaId = value; }
        }

        public int FKFamiliaId
        {
            get { return _FKFamiliaId; }
            set { _FKFamiliaId = value; }
        }

        public bool ActivoSN
        {
            get { return _ActivoSN; }
            set { _ActivoSN = value; }
        }

        #endregion

        public Articulo()
        {
            _PKArticuloId=-1;
            _FKCompaniaId=-1;
            _Descripcion="";
            _ClaveInterna="";
            _CodigoBarras="";
            _PrecioUnitario=0;
            _ManejaIVA=false;
            _FKImpuesto1=-1;
            _FKImpuesto2=-1;
            _FKImpuesto3=-1;
            _FKUnidaddeMedidaId=-1;
            _FKFamiliaId=-1;
            _ActivoSN=false;

            ObjDataAcces = new DataAcces();
        }

        #region Eventos


        public List<Articulo> Get(string Condiciones)
        {
            try
            {
                List<Articulo> Listcompania = new List<Articulo>();
                string consulta =" select " +
                                 " PKArticuloId"+
                                 " ,FKCompaniaId"+
                                 " ,Descripcion"+
                                 " ,ClaveInterna"+
                                 " ,CodigoBarras"+
                                 " ,PrecioUnitario"+
                                 " ,ManejaIVA"+
                                 " ,FKImpuesto1"+
                                 " ,FKImpuesto2"+
                                 " ,FKImpuesto3"+
                                 " ,FKUnidaddeMedidaId"+
                                 " ,FKFamiliaId"+
                                 " ,ActivoSN"+
                                 " from TblArticulos ";

                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    Articulo ObjArticulo = new Articulo();
                    ObjArticulo.PKArticuloId = Convert.ToInt32(datos[0]);
                    ObjArticulo.FKCompaniaId = Convert.ToInt32(datos[1]);
                    ObjArticulo.Descripcion = Convert.ToString(datos[2]);
                    ObjArticulo.ClaveInterna = Convert.ToString(datos[3]);
                    ObjArticulo.CodigoBarras = Convert.ToString(datos[4]);
                    ObjArticulo.PrecioUnitario = Convert.ToDecimal(datos[5]);
                    ObjArticulo.ManejaIVA = Convert.ToBoolean(datos[6]);
                    ObjArticulo.FKImpuesto1 = Convert.ToInt32(datos[7]);
                    ObjArticulo.FKImpuesto2 = Convert.ToInt32(datos[8]);
                    ObjArticulo.FKImpuesto3 = Convert.ToInt32(datos[9]);
                    ObjArticulo.FKUnidaddeMedidaId = Convert.ToInt32(datos[10]);
                    ObjArticulo.FKFamiliaId = Convert.ToInt32(datos[11]);
                    ObjArticulo.ActivoSN = Convert.ToBoolean(datos[12]);
                    // Los agregamos a la lista
                    Listcompania.Add(ObjArticulo);
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

        public Articulo GetbyID(int id)
        {
            try
            {
                Articulo ObjArticulo = new Articulo();
                string consulta = " select " +
                                 " PKArticuloId" +
                                 " ,FKCompaniaId" +
                                 " ,Descripcion" +
                                 " ,ClaveInterna" +
                                 " ,CodigoBarras" +
                                 " ,PrecioUnitario" +
                                 " ,ManejaIVA" +
                                 " ,FKImpuesto1" +
                                 " ,FKImpuesto2" +
                                 " ,FKImpuesto3" +
                                 " ,FKUnidaddeMedidaId" +
                                 " ,FKFamiliaId" +
                                 " ,ActivoSN" +
                                " from TblArticulos " +
                                " where PkArticuloId=@PkArticuloId";

                SQLiteCommand cmd = new SQLiteCommand(consulta, ObjDataAcces.Conexion);
                cmd.Parameters.AddWithValue("@PkArticuloId", id);
                ObjDataAcces.Open();
                SQLiteDataReader datos = cmd.ExecuteReader();

                // Leemos los datos de forma repetitiva
                while (datos.Read())
                {
                    ObjArticulo.PKArticuloId = Convert.ToInt32(datos[0]);
                    ObjArticulo.FKCompaniaId = Convert.ToInt32(datos[1]);
                    ObjArticulo.Descripcion = Convert.ToString(datos[2]);
                    ObjArticulo.ClaveInterna = Convert.ToString(datos[3]);
                    ObjArticulo.CodigoBarras = Convert.ToString(datos[4]);
                    ObjArticulo.PrecioUnitario = Convert.ToDecimal(datos[5]);
                    ObjArticulo.ManejaIVA = Convert.ToBoolean(datos[6]);
                    ObjArticulo.FKImpuesto1 = Convert.ToInt32(datos[7]);
                    ObjArticulo.FKImpuesto2 = Convert.ToInt32(datos[8]);
                    ObjArticulo.FKImpuesto3 = Convert.ToInt32(datos[9]);
                    ObjArticulo.FKUnidaddeMedidaId = Convert.ToInt32(datos[10]);
                    ObjArticulo.FKFamiliaId = Convert.ToInt32(datos[11]);
                    ObjArticulo.ActivoSN = Convert.ToBoolean(datos[12]);
                    // Los agregamos a la lista
                }
                datos.Close();
                ObjDataAcces.Close();

                return ObjArticulo;
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        public void Insert(Articulo PArticulo)
        {
            try
            {
                string StrSQl;
                if (existe(PArticulo))
                {
                    StrSQl = " UPDATE TblArticulos" +
                                  " SET " +
                                 " ,FKCompaniaId=@FKCompaniaId" +
                                 " ,Descripcion=@Descripcion" +
                                 " ,ClaveInterna=@ClaveInterna" +
                                 " ,CodigoBarras=@CodigoBarras" +
                                 " ,PrecioUnitario=@PrecioUnitario" +
                                 " ,ManejaIVA=@ManejaIVA" +
                                 " ,FKImpuesto1=@FKImpuesto1" +
                                 " ,FKImpuesto2=@FKImpuesto2" +
                                 " ,FKImpuesto3=@FKImpuesto3" +
                                 " ,FKUnidaddeMedidaId=@FKUnidaddeMedidaId" +
                                 " ,FKFamiliaId=@FKFamiliaId" +
                                 " ,ActivoSN=@ActivoSN" +
                                  " WHERE PkArticuloId=@PkArticuloId";

                    var insertSQL = new SQLiteCommand(StrSQl, ObjDataAcces.Conexion);

                    insertSQL.Parameters.AddWithValue("@FKCompaniaId", PArticulo.FKCompaniaId);
                    insertSQL.Parameters.AddWithValue("@Descripcion", PArticulo.Descripcion);
                    insertSQL.Parameters.AddWithValue("@ClaveInterna", PArticulo.ClaveInterna);
                    insertSQL.Parameters.AddWithValue("@CodigoBarras", PArticulo.CodigoBarras);
                    insertSQL.Parameters.AddWithValue("@PrecioUnitario",Convert.ToString(PArticulo.PrecioUnitario));
                    insertSQL.Parameters.AddWithValue("@ManejaIVA",Convert.ToInt16(PArticulo.ManejaIVA));
                    insertSQL.Parameters.AddWithValue("@FKImpuesto1", PArticulo.FKImpuesto1);
                    insertSQL.Parameters.AddWithValue("@FKImpuesto2", PArticulo.FKImpuesto2);
                    insertSQL.Parameters.AddWithValue("@FKImpuesto3", PArticulo.FKImpuesto3);
                    insertSQL.Parameters.AddWithValue("@FKUnidaddeMedidaId", PArticulo.FKUnidaddeMedidaId);
                    insertSQL.Parameters.AddWithValue("@FKFamiliaId", PArticulo.FKFamiliaId);
                    insertSQL.Parameters.AddWithValue("@ActivoSN", Convert.ToInt16(PArticulo.ActivoSN));
                    insertSQL.Parameters.AddWithValue("@PkArticuloId", PArticulo.PKArticuloId);
                   

                    ObjDataAcces.Open();
                    insertSQL.ExecuteNonQuery(); //Execute query
                    ObjDataAcces.Close();
                }
                else
                {
                    StrSQl = " INSERT INTO TblArticulos" +
                                    " (FKCompaniaId" +
                                    " ,Descripcion" +
                                    " ,ClaveInterna" +
                                    " ,CodigoBarras" +
                                    " ,PrecioUnitario" +
                                    " ,ManejaIVA" +
                                    " ,FKImpuesto1" +
                                    " ,FKImpuesto2" +
                                    " ,FKImpuesto3" +
                                    " ,FKUnidaddeMedidaId" +
                                    " ,FKFamiliaId" +
                                    " ,ActivoSN)" +
                                   "VALUES " +
                                    " (@FKCompaniaId" +
                                    " ,@Descripcion" +
                                    " ,@ClaveInterna" +
                                    " ,@CodigoBarras" +
                                    " ,@PrecioUnitario" +
                                    " ,@ManejaIVA" +
                                    " ,@FKImpuesto1" +
                                    " ,@FKImpuesto2" +
                                    " ,@FKImpuesto3" +
                                    " ,@FKUnidaddeMedidaId" +
                                    " ,@FKFamiliaId" +
                                    " ,@ActivoSN)";

                    var insertSQL = new SQLiteCommand(StrSQl, ObjDataAcces.Conexion);

                    insertSQL.Parameters.AddWithValue("@FKCompaniaId", PArticulo.FKCompaniaId);
                    insertSQL.Parameters.AddWithValue("@Descripcion", PArticulo.Descripcion);
                    insertSQL.Parameters.AddWithValue("@ClaveInterna", PArticulo.ClaveInterna);
                    insertSQL.Parameters.AddWithValue("@CodigoBarras", PArticulo.CodigoBarras);
                    insertSQL.Parameters.AddWithValue("@PrecioUnitario", Convert.ToString(PArticulo.PrecioUnitario));
                    insertSQL.Parameters.AddWithValue("@ManejaIVA", Convert.ToInt16(PArticulo.ManejaIVA));
                    insertSQL.Parameters.AddWithValue("@FKImpuesto1", PArticulo.FKImpuesto1);
                    insertSQL.Parameters.AddWithValue("@FKImpuesto2", PArticulo.FKImpuesto2);
                    insertSQL.Parameters.AddWithValue("@FKImpuesto3", PArticulo.FKImpuesto3);
                    insertSQL.Parameters.AddWithValue("@FKUnidaddeMedidaId", PArticulo.FKUnidaddeMedidaId);
                    insertSQL.Parameters.AddWithValue("@FKFamiliaId", PArticulo.FKFamiliaId);
                    insertSQL.Parameters.AddWithValue("@ActivoSN", Convert.ToInt16(PArticulo.ActivoSN));

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
                var insertSQL = new SQLiteCommand("Delete From TblArticulos WHERE PkArticuloId=@PkArticuloId", ObjDataAcces.Conexion);

                insertSQL.Parameters.AddWithValue("@PkArticuloId", Id);
                ObjDataAcces.Open();
                insertSQL.ExecuteNonQuery(); //Execute query
                ObjDataAcces.Close();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }

        private bool existe(Articulo PArticulo)
        {
            try
            {
                Articulo ObjArticulo = new Articulo();
                bool Resultado = false;

                ObjArticulo = GetbyID(PArticulo.PKArticuloId);
                if (ObjArticulo != null)
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