using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;


namespace Facturador
{
    public partial class FrmFormasdePago : System.Web.UI.Page
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
                if (ViewState["IdFormadepago"] == null)
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

                if (Session["IdFormadepago"] != null)
                {
                    ViewState["IdFormadepago"] = Session["IdFormadepago"];

                    Session["IdFormadepago"] = null;
                    
                    int _idFormadepago = Convert.ToInt32(ViewState["IdFormadepago"]);

                    var FormadePago = (from e in FContext.TblFormadePagoes
                                  where e.PkFormadePagoId == _idFormadepago
                                  select e).FirstOrDefault();

                    this.txtFormadePago.Text = FormadePago.PkFormadePagoId.ToString();

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
                var Formadepago = new TblFormadePago();

                Formadepago.FormadePago =   this.txtFormadePago.Text;

                FContext.AddToTblFormadePagoes(Formadepago);

                FContext.SaveChanges();
                Response.Redirect("ListFormasdePago.aspx");
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
                var FormadePago = new TblFormadePago();
                int _idFormadepago = Convert.ToInt32(ViewState["IdFormadepago"]);

                FormadePago = FContext.TblFormadePagoes.Single(FP => FP.PkFormadePagoId == _idFormadepago);

                FormadePago.FormadePago = this.txtFormadePago.Text;

                FContext.SaveChanges();
                Response.Redirect("ListFormasdePago.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar La Compania: " + ex.Message;
            }

        }
    }
}