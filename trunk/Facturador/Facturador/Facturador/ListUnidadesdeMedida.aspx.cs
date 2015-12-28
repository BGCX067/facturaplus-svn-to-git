using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Facturador
{
    public partial class ListUnidadesdeMedida : System.Web.UI.Page
    {
        private FacturadorEntities1 FContext;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    Session["IdUnidaddeMedida"] = 1;
                    FillGrid();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al listar a las unidadades de Médida: " + ex.Message;
            }


        }
        private void FillGrid()
        {
            FContext = new FacturadorEntities1();

            var Unidades = from e in FContext.TblUnidadesMedidas
                           orderby e.PkUnidaddeMedidaId ascending 
                           select new { e.PkUnidaddeMedidaId, e.UnidaddeMedida };


            this.GdUnidadesdeMedida.DataSource = Unidades.ToList();
            this.GdUnidadesdeMedida.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmUnidadesdeMedida.aspx");
        }

        protected void GdUnidadesdeMedida_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {


                FContext = new FacturadorEntities1();
                var Unidad = new TblUnidadesMedida();
                int _IdUnidad = Convert.ToInt32(this.GdUnidadesdeMedida.DataKeys[e.RowIndex].Value);

                Unidad = FContext.TblUnidadesMedidas.Single(unidad =>unidad.PkUnidaddeMedidaId == _IdUnidad);

                FContext.TblUnidadesMedidas.DeleteObject(Unidad);

                FContext.SaveChanges();
                Response.Redirect("FrmUnidadesdeMedida.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Eliminar: " + ex.Message;
            }
        }

        protected void GdUnidadesdeMedida_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                Session["IdUnidaddeMedida"] = this.GdUnidadesdeMedida.DataKeys[e.NewEditIndex].Value;
                Response.Redirect("FrmUnidadesdeMedida.aspx");
            }

            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Seleccionar el Id: " + ex.Message;
            }
        }
    }
}