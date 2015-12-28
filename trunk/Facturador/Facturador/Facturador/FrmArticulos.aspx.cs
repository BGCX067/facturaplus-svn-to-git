using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;


namespace Facturador
{
    public partial class FrmArticulos : System.Web.UI.Page
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

                if (Session["IdArticulo"] != null)
                {
                    ViewState["IdArticulo"] = Session["IdArticulo"];
                    Session["IdArticulo"] = null;
                    int _idArticulo = Convert.ToInt32(ViewState["IdArticulo"]);

                    var Articulo = (from e in FContext.TblArticulos
                                  where e.PkArticuloId == _idArticulo
                                  select e).FirstOrDefault();

                    this.txtDescripción.Text = Articulo.Descripcion;
                    this.txtCodigodeBarras.Text = Articulo.CodigoBarras;
                    this.txtClaveInterna.Text = Articulo.ClaveInterna;
                    this.txtPrecioUnitario.Text = Articulo.PrecioUnitario.ToString();
                    this.chkCausaIva.Checked= Articulo.ManejaIVA;
                    this.ddImpuesto1.SelectedValue = Articulo.FkImpuesto1.ToString();
                    this.ddImpuesto2.SelectedValue = Articulo.FkImpuesto2.ToString();
                    this.ddImpuesto3.SelectedValue = Articulo.FkImpuesto3.ToString();
                    this.ddUnidaddemedida.SelectedValue =Articulo.FkUnidaddeMedidaId.ToString();
                    this.ddFamilia.SelectedValue = Articulo.FkFamiliaId.ToString();
                    this.chkActivo.Checked = Articulo.ActivoSN;
                }
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
                if (ViewState["idemisor"] == null)
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
                lblError.Text = "Ha Ocurrido un Error Al guardar La Compania: " + ex.Message;
            }
        }

        private void AddEmisor()
        {

            try
            {
                FContext = new FacturadorEntities1();
                var Articulo = new TblArticulo();

                Articulo.FkEmisorId = Convert.ToInt32(Session["IdEmisor"]);
                Articulo.Descripcion = this.txtDescripción.Text ;
                Articulo.CodigoBarras =  this.txtCodigodeBarras.Text ;
                Articulo.ClaveInterna =  this.txtClaveInterna.Text;
                Articulo.PrecioUnitario=Convert.ToDecimal(  this.txtPrecioUnitario.Text) ;
                Articulo.ManejaIVA=  this.chkCausaIva.Checked;
                Articulo.FkImpuesto1=  Convert.ToInt32( this.ddImpuesto1.SelectedValue);
                Articulo.FkImpuesto2=  Convert.ToInt32( this.ddImpuesto2.SelectedValue);
                Articulo.FkImpuesto3= Convert.ToInt32(  this.ddImpuesto3.SelectedValue);
                Articulo.FkUnidaddeMedidaId=Convert.ToInt32(   this.ddUnidaddemedida.SelectedValue);
                Articulo.FkFamiliaId = Convert.ToInt32( this.ddFamilia.SelectedValue) ;
                Articulo.ActivoSN=   this.chkActivo.Checked;

                FContext.TblArticulos.AddObject(Articulo);
                Response.Redirect("ListArticulos.aspx");
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
                var articulo = new TblArticulo();
                int _idArticulo = Convert.ToInt32(ViewState["IdArticulo"]);

                articulo = FContext.TblArticulos.Single(Articulo => Articulo.PkArticuloId == _idArticulo);

                articulo.FkEmisorId = Convert.ToInt32(Session["IdArticulo"]);
                articulo.Descripcion = this.txtDescripción.Text;
                articulo.CodigoBarras = this.txtCodigodeBarras.Text;
                articulo.ClaveInterna = this.txtClaveInterna.Text;
                articulo.PrecioUnitario = Convert.ToDecimal(this.txtPrecioUnitario.Text);
                articulo.ManejaIVA = this.chkCausaIva.Checked;
                articulo.FkImpuesto1 = Convert.ToInt32(this.ddImpuesto1.SelectedValue);
                articulo.FkImpuesto2 = Convert.ToInt32(this.ddImpuesto2.SelectedValue);
                articulo.FkImpuesto3 = Convert.ToInt32(this.ddImpuesto3.SelectedValue);
                articulo.FkUnidaddeMedidaId = Convert.ToInt32(this.ddUnidaddemedida.SelectedValue);
                articulo.FkFamiliaId = Convert.ToInt32(this.ddFamilia.SelectedValue);
                articulo.ActivoSN = this.chkActivo.Checked;

                FContext.SaveChanges();
                Response.Redirect("ListArticulos.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar La Compania: " + ex.Message;
            }

        }
    }
}