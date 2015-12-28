using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;


namespace Facturador
{
    
    public partial class ListArticulos : System.Web.UI.Page
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

            var Articulos = from e in FContext.TblArticulos
                           orderby e.PkArticuloId ascending
                            select new { e.PkArticuloId, e.Descripcion, e.ClaveInterna, e.CodigoBarras, e.PrecioUnitario };


            this.GdArticulos.DataSource = Articulos.ToList();
            this.GdArticulos.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmArticulos.aspx");
        }

        protected void GdArticulos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {


                FContext = new FacturadorEntities1();
                var _Articulo = new TblArticulo();
                int _ArticuloId = Convert.ToInt32(this.GdArticulos.DataKeys[e.RowIndex].Value);

                _Articulo = FContext.TblArticulos.Single(Articulo => Articulo.PkArticuloId == _ArticuloId);

                FContext.TblArticulos.DeleteObject(_Articulo);

                FContext.SaveChanges();
                Response.Redirect("ListArticulos.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Eliminar: " + ex.Message;
            }

        }

        protected void GdArticulos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                Session["IdArticulo"] = this.GdArticulos.DataKeys[e.NewEditIndex].Value;
                Response.Redirect("FrmArticulos.aspx");
            }

            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Seleccionar el Id: " + ex.Message;
            }
        }

    }
}