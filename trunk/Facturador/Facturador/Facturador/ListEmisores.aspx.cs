using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Facturador
{
    public partial class ListEmisores : System.Web.UI.Page
    {
        private FacturadorEntities1 FContext;
 

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
             if   (!Page.IsPostBack)
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

            var Emisores = from e in FContext.TblEmisores 
                                orderby e.Rfc descending 
                                select new { e.Rfc, e.RazonSocial, e.PKEmisorId };


            this.gdEmisores.DataSource = Emisores.ToList();
            this.gdEmisores.DataBind(); 
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
        Response.Redirect("FrmEmisores.aspx");
        }

        protected void gdEmisores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
            

            FContext = new FacturadorEntities1();
            var emisor = new TblEmisore();
            int _idemisor = Convert.ToInt32( this.gdEmisores.DataKeys[e.RowIndex].Value);

            emisor = FContext.TblEmisores.Single(Emisor => Emisor.PKEmisorId == _idemisor);

            FContext.TblEmisores.DeleteObject(emisor);

            FContext.SaveChanges();
            Response.Redirect("listEmisores.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Eliminar: " + ex.Message;
            }
        

        }

        protected void gdEmisores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
             Session["idemisor"] =  this.gdEmisores.DataKeys[e.NewEditIndex].Value;
            Response.Redirect("FrmEmisores.aspx");
            }

            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al Seleccionar el Id: " + ex.Message;
            }

        }


    }
}