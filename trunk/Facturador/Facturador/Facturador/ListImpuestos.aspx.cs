using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;


namespace Facturador
{
    public partial class ListImpuestos : System.Web.UI.Page
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

            var impuesto = from e in FContext.TblImpuestos
                           orderby e.Impuesto descending
                           select new { e.Impuesto, e.Tasa, e.TblTipoImpuesto.TipoImpuesto  };


            this.GdImpuestos.DataSource = impuesto.ToList();
            this.GdImpuestos.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmEmisores.aspx");
        }

        protected void gdEmisores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {


                FContext = new FacturadorEntities1();
                var impuesto = new TblImpuesto();
                int _idImpuesto = Convert.ToInt32(this.GdImpuestos.DataKeys[e.RowIndex].Value);

                impuesto = FContext.TblImpuestos.Single(Impuesto => Impuesto.PkImpuestoId == _idImpuesto);

                FContext.TblImpuestos.DeleteObject(impuesto);

                FContext.SaveChanges();
                Response.Redirect("ListImpuestos.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Eliminar: " + ex.Message;
            }
        }

        protected void gdEmisores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                Session["IdImpuesto"] = this.GdImpuestos.DataKeys[e.NewEditIndex].Value;
                Response.Redirect("ListImpuestos.aspx");
            }

            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Seleccionar el Id: " + ex.Message;
            }

        }


    }
}