using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;



namespace Facturador
{
    public partial class ListFormasdePago : System.Web.UI.Page
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
                lblError.Text = "Ha Ocurrido un Error Al listar a las Compamías: " + ex.Message;
            }

        }

        private void FillGrid()
        {
            FContext = new FacturadorEntities1();

            var formasdepago = from e in FContext.TblFormadePagoes
                           orderby e.PkFormadePagoId ascending 
                           select new { e.PkFormadePagoId, e.FormadePago};


            this.GdFormasdePago.DataSource = formasdepago.ToList();
            this.GdFormasdePago.DataBind();
        }

        protected void GdFormasdePago_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {


                FContext = new FacturadorEntities1();
                var formadepago = new TblFormadePago();
                int _idformadepago = Convert.ToInt32(this.GdFormasdePago.DataKeys[e.RowIndex].Value);

                formadepago = FContext.TblFormadePagoes.Single(Formadepago => Formadepago.PkFormadePagoId == _idformadepago);

                FContext.TblFormadePagoes.DeleteObject(formadepago);

                FContext.SaveChanges();
                Response.Redirect("ListFormasdePago.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Eliminar: " + ex.Message;
            }

        }

        protected void GdFormasdePago_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                Session["IdFormadepago"] = this.GdFormasdePago.DataKeys[e.NewEditIndex].Value;
                Response.Redirect("FrmFormasdePago.aspx");
            }

            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Seleccionar el Id: " + ex.Message;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmFormasdePago.aspx");
        }

    }
}