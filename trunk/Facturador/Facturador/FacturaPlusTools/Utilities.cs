using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FacturaPlusTools
{
   public  static class Utilities
    {
        public static void creaCarpetaClientes(string strRFC, string AddresDireccion)
        {

            System.IO.Directory.CreateDirectory(AddresDireccion + @"\clientes\" + strRFC);
            System.IO.Directory.CreateDirectory(AddresDireccion + @"\clientes\" + strRFC + @"\xml");
            System.IO.Directory.CreateDirectory(AddresDireccion + @"\clientes\" + strRFC + @"\pdf");
            System.IO.Directory.CreateDirectory(AddresDireccion + @"\clientes\" + strRFC + @"\reportes");
 
        
        }

        public static string GetServerFolder(String strRFC)
        {
        return HttpContext.Current.Server.MapPath("~/clientes") + @"\" + strRFC + @"\";
        }

    }
}
