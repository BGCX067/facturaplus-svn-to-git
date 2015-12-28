using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Facturador
{
    public partial class ListReceptores : System.Web.UI.Page
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
                lblError.Text = "Ha Ocurrido un Error Al listar a las Compamías: " + ex.Message;
            }
        }

        private void FillGrid()
        {
            FContext = new FacturadorEntities1();

            var Receptores = from e in FContext.TblReceptores
                           orderby e.Rfc descending
                           select new { e.Rfc, e.RazonSocial,e.CorreoElectronico, e.PkReceptorId };


            this.GdReceptores.DataSource = Receptores.ToList();
            this.GdReceptores.DataBind();
        }

        protected void GdReceptores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {


                FContext = new FacturadorEntities1();
                var receptor = new TblReceptore();
                int _IdReceptor = Convert.ToInt32(this.GdReceptores.DataKeys[e.RowIndex].Value);

                receptor = FContext.TblReceptores.Single(Receptor => Receptor.PkReceptorId == _IdReceptor);

                FContext.TblReceptores.DeleteObject(receptor);

                FContext.SaveChanges();
                Response.Redirect("listReceptores.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Eliminar: " + ex.Message;
            }
        }

        protected void GdReceptores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                Session["IdReceptor"] = this.GdReceptores.DataKeys[e.NewEditIndex].Value;
                Response.Redirect("FrmReceptores.aspx");
            }

            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Seleccionar el Id: " + ex.Message;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}