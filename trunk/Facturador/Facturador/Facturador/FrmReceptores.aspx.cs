using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Facturador
{
    public partial class FrmReceptores : System.Web.UI.Page
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

                 if (Session["IdReceptor"] != null)
                {
                    ViewState["IdReceptor"] = Session["IdReceptor"];
                    Session["IdReceptor"] = null;

                    int _IdReceptor = Convert.ToInt32(ViewState["IdReceptor"]);

                    var receptor  = (from e in FContext.TblReceptores
                                   where e.PkReceptorId == _IdReceptor
                                    select e).FirstOrDefault();

                    this.txtRFC.Text = receptor.Rfc;
                    this.txtRazonSocial.Text = receptor.RazonSocial;
                    this.txtNoExterior.Text = receptor.NoExterior;
                    this.txtNoInterior.Text = receptor.NoInterior;
                    this.txtCalle.Text = receptor.Calle;
                    this.txtColonia.Text = receptor.Colonia;
                    this.txtReferencia.Text = receptor.Referencia;
                    this.txtLocalidad.Text = receptor.Localidad;
                    this.txtEstado.Text = receptor.Estado;
                    this.txtMunicipio.Text = receptor.Municipio;
                    this.txtCP.Text = receptor.CP;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar el Receptor: " + ex.Message;
            }

            }


     private void AddEmisor()
     {

         try
         {
             FContext = new FacturadorEntities1();
             var Receptor = new TblReceptore();

             Receptor.FkEmisorId = Convert.ToInt32(Session["IdReceptor"]);
             Receptor.Rfc = this.txtRFC.Text;
             Receptor.RazonSocial = this.txtRazonSocial.Text;
             Receptor.NoExterior = this.txtNoExterior.Text;
             Receptor.NoInterior = this.txtNoInterior.Text;
             Receptor.Calle = this.txtCalle.Text;
             Receptor.Colonia = this.txtColonia.Text;
             Receptor.Referencia = this.txtReferencia.Text;
             Receptor.Localidad = this.txtLocalidad.Text;
             Receptor.Estado = this.txtEstado.Text;
             Receptor.Municipio = this.txtMunicipio.Text;
             Receptor.CP = this.txtCP.Text;
             FContext.AddToTblReceptores(Receptor);

             FContext.SaveChanges();
             Response.Redirect("ListReceptores.aspx");
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
             var Receptor = new TblReceptore();
             int _IdReceptor = Convert.ToInt32(ViewState["IdReceptor"]);

             Receptor = FContext.TblReceptores.Single(receptor => receptor.PkReceptorId == _IdReceptor);

             Receptor.PkReceptorId = Convert.ToInt32(Session["IdReceptor"]);
             Receptor.Rfc = this.txtRFC.Text;
             Receptor.RazonSocial = this.txtRazonSocial.Text;
             Receptor.NoExterior = this.txtNoExterior.Text;
             Receptor.NoInterior = this.txtNoInterior.Text;
             Receptor.Calle = this.txtCalle.Text;
             Receptor.Colonia = this.txtColonia.Text;
             Receptor.Referencia = this.txtReferencia.Text;
             Receptor.Localidad = this.txtLocalidad.Text;
             Receptor.Estado = this.txtEstado.Text;
             Receptor.Municipio = this.txtMunicipio.Text;
             Receptor.CP = this.txtCP.Text;

             FContext.SaveChanges();
             Response.Redirect("ListReceptores.aspx");
         }
         catch (Exception ex)
         {
             lblError.Text = "Ha Ocurrido un Error Al guardar La Compania: " + ex.Message;
         }

     }

          
        }
}