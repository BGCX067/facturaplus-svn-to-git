using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;


namespace Facturador
{
    public partial class ListUsuarios : System.Web.UI.Page
    {
        private FacturadorEntities1 FContext;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Session["ClienteId"] = 1;
                    FillGrid();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al listar a los Usuarios: " + ex.Message;
            }
           

        }

        protected void gdUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {


                FContext = new FacturadorEntities1();
                var Usuario = new TblUsuario();
                int _idUsuario = Convert.ToInt32(this.gdUsuarios.DataKeys[e.RowIndex].Value);

                Usuario = FContext.TblUsuarios.Single(usuario => usuario.PkUsuarioId == _idUsuario);

                FContext.TblUsuarios.DeleteObject(Usuario);

                FContext.SaveChanges();
                Response.Redirect("ListUsuarios.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Usuario: " + ex.Message;
            }
        

        }

        protected void gdUsuarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                Session["IdUsuario"] = this.gdUsuarios.DataKeys[e.NewEditIndex].Value;
                Response.Redirect("FrmUsuarios.aspx");
            }

            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Seleccionar el Id: " + ex.Message;
            }
        }
        private void FillGrid()
        {
            FContext = new FacturadorEntities1();

            var Usuarios = from e in FContext.TblUsuarios
                           orderby e.Nombre descending
                           select new { e.Nombre, e.Apellidos, e.Puesto, e.PkUsuarioId };


            this.gdUsuarios.DataSource = Usuarios.ToList();
            this.gdUsuarios.DataBind(); ;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmUsuarios.aspx");
        }
    }
}