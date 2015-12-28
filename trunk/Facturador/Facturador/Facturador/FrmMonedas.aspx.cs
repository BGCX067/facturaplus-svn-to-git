using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;



namespace Facturador
{
    public partial class FrmMonedas : System.Web.UI.Page
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
                   if (ViewState["IdMoneda"]==null)
                {
                AddMonedas();
                }
                else
                {
                    EditMonedas();
                }
            }
             catch (Exception ex )
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar La Moneda: " + ex.Message;
            }
        }

        private void FillValues()
        {
            try
            {
                FContext = new FacturadorEntities1();

                if (Session["IdMoneda"] != null)
                {
                    ViewState["IdMoneda"] = Session["IdMoneda"];
                    Session["IdMoneda"] = null;
                    int _IdMoneda = Convert.ToInt32(ViewState["IdMoneda"]);

                    var moneda = (from e in FContext.TblMonedas
                                  where e.PkMonedaId == _IdMoneda
                                  select e).FirstOrDefault();

                    this.txtMonenda.Text = moneda.Moneda;
                    this.txtPrefijo.Text = moneda.Prefijo;
                    this.txtSigno.Text = moneda.Simbolo;
                    this.txtTipodeCambio.Text = moneda.TipoCambio.ToString();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar La Compania: " + ex.Message;
            }
        }

        private void AddMonedas()
        {
           
            try
            {
                FContext = new FacturadorEntities1();
                 var moneda = new TblMoneda();

               moneda.Moneda= this.txtMonenda.Text;
               moneda.Prefijo   =  this.txtPrefijo.Text;
               moneda.Simbolo  =   this.txtSigno.Text;
               moneda.TipoCambio= Convert.ToDecimal(this.txtTipodeCambio.Text);
                FContext.AddToTblMonedas(moneda);
              
                FContext.SaveChanges();
                Response.Redirect("listMonedas.aspx");
            }
            catch (Exception ex )
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar La Compania: " + ex.Message;
            }
           
        }

        private void EditMonedas()
        {
           
           
            try
            {
                FContext = new FacturadorEntities1();
                var moneda = new TblMoneda();
                  int _IdMoneda = Convert.ToInt32(ViewState["IdMoneda"]);
               
                moneda = FContext.TblMonedas.Single(Moneda => Moneda.PkMonedaId == _IdMoneda);

               moneda.PkMonedaId =Convert.ToInt32( Session["IdMoneda"]);
               moneda.Moneda= this.txtMonenda.Text;
               moneda.Prefijo   =  this.txtPrefijo.Text;
               moneda.Simbolo  =   this.txtSigno.Text;
               moneda.TipoCambio= Convert.ToDecimal(this.txtTipodeCambio.Text);
                
                FContext.SaveChanges();
                Response.Redirect("listEmisores.aspx");
            }
            catch (Exception ex )
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar La Compania: " + ex.Message;
            }
           
        }
    }


}