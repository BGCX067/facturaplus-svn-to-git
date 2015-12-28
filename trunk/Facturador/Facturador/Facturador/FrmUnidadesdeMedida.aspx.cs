using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Facturador
{
    public partial class FrmUnidadesdeMedida : System.Web.UI.Page
    {
        private FacturadorEntities1 FContext;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillValues();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["IdUnidad"] == null)
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
                lblError.Text = "Ha Ocurrido un Error Al guardar La unidad: " + ex.Message;
            }
        }

        private void FillValues()
        {
            try
            {
                FContext = new FacturadorEntities1();

                if (Session["IdUnidad"] != null)
                {
                    ViewState["IdUnidad"] = Session["IdUnidad"];
                    Session["IdUnidad"] = null;
                    int _idUnidad = Convert.ToInt32(ViewState["IdUnidad"]);

                    var unidad = (from e in FContext.TblUnidadesMedidas
                                  where e.PkUnidaddeMedidaId == _idUnidad
                                  select e).FirstOrDefault();

                    this.txtUnidaddeMedida.Text = unidad.UnidaddeMedida;
                    
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
                var unidad = new TblUnidadesMedida();

                unidad.UnidaddeMedida = this.txtUnidaddeMedida.Text;
               
                FContext.AddToTblUnidadesMedidas(unidad);

                FContext.SaveChanges();
                Response.Redirect("ListUnidadesdeMedida.aspx");
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
                var unidad = new TblUnidadesMedida();
                int _idUnidad = Convert.ToInt32(ViewState["IdUnidad"]);

                unidad = FContext.TblUnidadesMedidas.Single(Unidad => Unidad.PkUnidaddeMedidaId == _idUnidad);

                unidad.UnidaddeMedida = this.txtUnidaddeMedida.Text;
                
                FContext.SaveChanges();
                Response.Redirect("ListUnidadesdeMedida.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar La Compania: " + ex.Message;
            }

        }
    }
}