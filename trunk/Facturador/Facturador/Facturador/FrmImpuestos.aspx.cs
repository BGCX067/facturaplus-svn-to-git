using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;


namespace Facturador
{
    public partial class FrmImpuestos : System.Web.UI.Page
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

                if (Session["IdImpuesto"] != null)
                {
                    ViewState["IdImpuesto"] = Session["IdImpuesto"];
                    Session["IdImpuesto"] = null;

                    int _IdImpuesto = Convert.ToInt32(ViewState["IdImpuesto"]);

                    var impuesto = (from e in FContext.TblImpuestos
                                    where e.PkImpuestoId == _IdImpuesto
                                  select e).FirstOrDefault();

                    this.txtImpuesto.Text = impuesto.Impuesto;
                    this.txtTasa.Text = impuesto.Tasa.ToString();
                    this.ddtipoImpuesto.SelectedValue = impuesto.FkTipoImpuestoId.ToString();
                   
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
                var impuesto = new TblImpuesto();

              impuesto.Impuesto= this.txtImpuesto.Text;
              impuesto.Tasa=  Convert.ToDecimal( this.txtTasa.Text);
              impuesto.FkTipoImpuestoId= Convert.ToInt32( this.ddtipoImpuesto.SelectedValue);

                FContext.TblImpuestos.AddObject(impuesto);
                Response.Redirect("ListImpuestos.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar El Impuesto: " + ex.Message;
            }

        }

        private void EditEmisor()
        {


            try
            {
                FContext = new FacturadorEntities1();
                var impuesto = new TblImpuesto();
                int _idImpuesto = Convert.ToInt32(ViewState["IdImpuesto"]);

                impuesto = FContext.TblImpuestos.Single(Impuesto => Impuesto.PkImpuestoId == _idImpuesto);

                impuesto.Impuesto = this.txtImpuesto.Text;
                impuesto.Tasa = Convert.ToDecimal(this.txtTasa.Text);
                impuesto.FkTipoImpuestoId = Convert.ToInt32(this.ddtipoImpuesto.SelectedValue);

                FContext.SaveChanges();
                Response.Redirect("listImpuestos.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar La Compania: " + ex.Message;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["IdImpuesto"] == null)
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
                lblError.Text = "Ha Ocurrido un Error Al guardar El Impuesto: " + ex.Message;
            }
        }
    }
}