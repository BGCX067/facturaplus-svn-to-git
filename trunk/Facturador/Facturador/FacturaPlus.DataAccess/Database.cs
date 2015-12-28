using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using  System.Data.SqlClient;
using System.Collections;
using System.Collections.Specialized;



namespace FacturaPlus.DataAccess
{
  public  class Database
    {
      public DataRowView GetRowView(string Consulta)
        {
            return null;
        }
        public void QuickUpdate(string Tablename, NameValueCollection Parameters)
        {

        }

        public Database()
        {
        }
        
      public DataTable GetTable(string Consulta)
      {
          return null;
      }

      public DataTable GetTable(SqlCommand command)
      {
          return null;
      }

    }
}
