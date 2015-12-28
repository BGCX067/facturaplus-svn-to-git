using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;


namespace Facturador
{
    public partial class ListMonedas : System.Web.UI.Page
    {
        private FacturadorEntities1 FContext;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Session["IdMoneda"] = 1;
                    FillGrid();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al listar las Monedas: " + ex.Message;
            }
        }

        private void FillGrid()
        {
            FContext = new FacturadorEntities1();

            var monedas = from e in FContext.TblMonedas
                           orderby e.Moneda descending
                           select new { e.Moneda,e.TipoCambio, e.Prefijo , e.Simbolo, e.PkMonedaId };


            this.GdMonendas.DataSource = monedas.ToList();
            this.GdMonendas.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmMonedas.aspx");
        }

        protected void GdMonedas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {


                FContext = new FacturadorEntities1();
                var moneda = new TblMoneda();
                int _idMoneda = Convert.ToInt32(this.GdMonendas.DataKeys[e.RowIndex].Value);

                moneda = FContext.TblMonedas.Single(Moneda => Moneda.PkMonedaId == _idMoneda);

                FContext.TblMonedas.DeleteObject(moneda);

                FContext.SaveChanges();
                Response.Redirect("FrmMonedas.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Eliminar: " + ex.Message;
            }

        }

        protected void GdMonedas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                Session["IdMonenda"] = this.GdMonendas.DataKeys[e.NewEditIndex].Value;
                Response.Redirect("FrmMonedas.aspx");
            }

            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Seleccionar el Id: " + ex.Message;
            }
        }
    }
}