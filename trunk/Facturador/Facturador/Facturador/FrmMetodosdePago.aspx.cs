using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Facturador
{
    public partial class FrmMetodosdePago : System.Web.UI.Page
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

                if (Session["IdMetododePago"] != null)
                {
                    ViewState["IdMetododePago"] = Session["IdMetododePago"];

                    Session["IdMetododePago"] = null;

                    int _IdMetododePago = Convert.ToInt32(ViewState["IdMetododePago"]);

                    var MetododePago = (from e in FContext.TblMetododePagoes
                                        where e.PkMetododePagoId == _IdMetododePago
                                       select e).FirstOrDefault();

                    this.txtMetododepago.Text = MetododePago.MetododePago.ToString();

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
                var MetododePago = new TblMetododePago();

                MetododePago.MetododePago = this.txtMetododepago.Text;

                FContext.AddToTblMetododePagoes(MetododePago);

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
                var MetododePago = new TblMetododePago();
                int _IdMetododePago = Convert.ToInt32(ViewState["IdMetododePago"]);

                MetododePago = FContext.TblMetododePagoes.Single(MP => MP.PkMetododePagoId == _IdMetododePago);

                MetododePago.MetododePago = this.txtMetododepago.Text;

                FContext.SaveChanges();
                Response.Redirect("ListMetodosdePago.aspx");
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
                if (ViewState["IdMetododePago"] == null)
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
                lblError.Text = "Ha Ocurrido un Error Al guardar el Método de Pago: " + ex.Message;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}