using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Facturador
{
    public partial class FrmUsuarios : System.Web.UI.Page
    {
        private FacturadorEntities1 FContext;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillValues();
            }
        }
        private void FillValues()
        {
            try
            {
                FContext = new FacturadorEntities1();

                if (Session["IdUsuario"] != null)
                {
                    ViewState["IdUsuario"] = Session["IdUsuario"];
                    Session["IdUsuario"] = null;
                    int _IdUsuario = Convert.ToInt32(ViewState["IdUsuario"]);

                    var usuario = (from e in FContext.TblUsuarios
                                  where e.PkUsuarioId == _IdUsuario
                                  select e).FirstOrDefault();

                    this.txtNombre.Text = usuario.Nombre;
                    this.txtPassword.Text = usuario.Password;
                    this.txtPuesto.Text = usuario.Puesto;
                    this.cmbRol.SelectedValue = usuario.Rol.ToString();
                    this.txtApellidos.Text = usuario.Apellidos;
                    this.chkBloqueado.Checked =Convert.ToBoolean( usuario.Bloqueado);
                    
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al cargar Los Valores " + ex.Message;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["IdUsuario"] == null)
                {
                    AddEmisor();
                }
                else
                {
                    EditEmisor();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar La Compania: " + ex.Message;
            }
        }

        private void AddEmisor()
        {

            try
            {
                FContext = new FacturadorEntities1();
                var usuario = new  TblUsuario();


                usuario.Nombre= this.txtNombre.Text;
                usuario.Password= this.txtPassword.Text;
                usuario.Puesto= this.txtPuesto.Text;
                usuario.Rol= Convert.ToInt32( this.cmbRol.SelectedValue);
                usuario.Apellidos= this.txtApellidos.Text ;
                usuario.Bloqueado = this.chkBloqueado.Checked ;
                
                FContext.AddToTblUsuarios(usuario);
                FContext.SaveChanges();
                Response.Redirect("ListUsuarios.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar La Compania: " + ex.Message;
            }

        }

        private void EditEmisor()
        {
            try
            {
                FContext = new FacturadorEntities1();
                var usuario = new TblUsuario();
                int _idUsuario = Convert.ToInt32(ViewState["IdUsuario"]);

                usuario = FContext.TblUsuarios.Single(Usuario => Usuario.Username ==this.txtNombre.Text &&  usuario.Password== this.txtPassword.Text);

                usuario.Nombre = this.txtNombre.Text;
                usuario.Password = this.txtPassword.Text;
                usuario.Puesto = this.txtPuesto.Text;
                usuario.Rol = Convert.ToInt32(this.cmbRol.SelectedValue);
                usuario.Apellidos = this.txtApellidos.Text;
                usuario.Bloqueado = this.chkBloqueado.Checked;

                FContext.SaveChanges();
                Response.Redirect("ListUsuarios.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar El Usuario: " + ex.Message;
            }

        }
    }
}