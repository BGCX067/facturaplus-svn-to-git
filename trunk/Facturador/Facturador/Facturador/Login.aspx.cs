using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using FacturaPlusTools;

namespace Facturador
{
    public partial class Login : System.Web.UI.Page
    {
        private FacturadorEntities1 FContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            lblError.Text = "";
            //btnRegistrarse.Visible = false;
            //lblRegistrarse.Visible = false;
            lnkRecordarPassword.Visible = false;
            lblMensaje.Visible = false;

        }

       

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Crypt _crypt = new Crypt();

            FContext = new FacturadorEntities1();
            var ObjUsuario = new TblUsuario();
            string _password;
            _password = _crypt.MD5(txtpassword.Text);

            ObjUsuario = FContext.TblUsuarios.FirstOrDefault(Usuario => Usuario.CorreoElectronico == txtCoreoElectronico.Text && Usuario.Password == _password);

            if (ObjUsuario != null)
            {
                var ObjEmisor = FContext.TblEmisores.Single(emi => emi.PKEmisorId == ObjUsuario.FkEmisorId);
                Session["IdUsuario"] = ObjUsuario.PkUsuarioId;
                Session["IdEmisor"] = ObjEmisor.PKEmisorId;
                Session["Emisor"] = ObjEmisor;
                Session["Usuario"] = ObjUsuario;
                
                Response.Redirect("Desktop.aspx");
            }

            else
            {
                lnkRecordarPassword.Visible = true;
                btnRegistrarse.Visible = true;
                lblRegistrarse.Visible = true;
                lblMensaje.Visible = true;
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
        Response.Redirect("Registro.aspx");
        }

        protected void lnkRecordarPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecuperarPassword.aspx");
        }
    }
}