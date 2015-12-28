using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Facturador
{
    public partial class ListMetodosdePago : System.Web.UI.Page
    {
        private FacturadorEntities1 FContext;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {

                    FillGrid();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al listar los Métodos de Pago: " + ex.Message;
            }
        }

        private void FillGrid()
        {
            FContext = new FacturadorEntities1();

            var MetodosdePago = from e in FContext.TblMetododePagoes
                               orderby e.PkMetododePagoId ascending
                               select new { e.PkMetododePagoId, e.MetododePago };


            this.GdMetodosdePago.DataSource = MetodosdePago.ToList();
            this.GdMetodosdePago.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmMetodosdePago.aspx");
        }

        protected void GdMetodosdePago_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {


                FContext = new FacturadorEntities1();
                var metododepago = new TblMetododePago();
                int _IdMetododePago = Convert.ToInt32(this.GdMetodosdePago.DataKeys[e.RowIndex].Value);

                metododepago = FContext.TblMetododePagoes.Single(MetododePago => MetododePago.PkMetododePagoId == _IdMetododePago);

                FContext.TblMetododePagoes.DeleteObject(metododepago);

                FContext.SaveChanges();
                Response.Redirect("ListMetodosdePago.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Eliminar: " + ex.Message;
            }
        }

        protected void GdMetodosdePago_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                Session["IdMetododePago"] = this.GdMetodosdePago.DataKeys[e.NewEditIndex].Value;
                Response.Redirect("FrmMetodosdePago.aspx");
            }

            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Seleccionar el Id: " + ex.Message;
            }
        }


    }
}