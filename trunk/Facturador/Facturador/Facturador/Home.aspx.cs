using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using FacturaPlusTools;

namespace Facturador
{
    public partial class Home : System.Web.UI.Page
    {
        private FacturadorEntities1 FContext;
        private string _password;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {

                }
                else
                {
                    Session.Clear();
                }
            }
            catch (Exception)
            {
                

                throw;
            }
            

        }


        private void Add()
        {


            Crypt _crypt = new Crypt();
            _password = _crypt.MD5(this.txtPassword.Text);


            FContext = new FacturadorEntities1();
            try
            {

                var ObjUsuario = FContext.TblUsuarios.FirstOrDefault(Usuario => Usuario.CorreoElectronico == txtEmail.Text);

                if (ObjUsuario != null)
                {

                    //var _usr = FContext.TblUsuarios.FirstOrDefault(usr => usr.CorreoElectronico == txtEmail.Text && usr.Password == _password);

                    //if (_usr != null)
                    //{
                        lblError.Text = "El Correo Ya existe: ";
                        lnkRecuperarPassword.Visible = true;

                    //}

                }
                else
                {



                    tblCliente cliente = new tblCliente();

                    cliente.Nombre = this.txtNombre.Text.ToUpper();
                    cliente.Empresa = this.txtEmpresa.Text.ToUpper();
                    cliente.CorreoElectronico = this.txtEmail.Text;
                    cliente.FechaCreacion = DateTime.Now;
                    cliente.Telefono = this.txtTelefono.Text;
                    cliente.Password = _password;
                    FContext.AddTotblClientes(cliente);

                    FContext.SaveChanges();
                    Session["IdCliente"] = cliente.pkClienteid;
                    CrearEmisor();
                    CreaUsuario();


                    Response.Redirect("Desktop.aspx");
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CreaUsuario()
        {
            try
            {
                FContext = new FacturadorEntities1();
                TblUsuario usuario = new TblUsuario();

                usuario.FkEmisorId = Convert.ToInt32(Session["IdEmisor"]);
                usuario.Nombre = this.txtNombre.Text;
                usuario.Password = _password;
                usuario.Rol = 3;
                usuario.Bloqueado = false;
                usuario.Username = this.txtEmail.Text;
                usuario.Password = _password;
                usuario.CorreoElectronico = this.txtEmail.Text;
                FContext.AddToTblUsuarios(usuario);
                FContext.SaveChanges();
                Session["IdUsuario"] = usuario.PkUsuarioId;
                //FContext.Refresh(RefreshMode.StoreWins,usuario);
                Session["Usuario"] = usuario;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CrearEmisor()
        {
            try
            {
                FContext = new FacturadorEntities1();
                var emisor = new TblEmisore();

                emisor.FkClienteId = Convert.ToInt32(Session["IdCliente"]);
                emisor.RazonSocial = "Compania de Demostración";
                emisor.Rfc = "XXXX";
                FContext.AddToTblEmisores(emisor);
                FContext.SaveChanges();
                Session["IdEmisor"] = emisor.PKEmisorId;


            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        protected void lnkRecuperarPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("RecuperarPassword.aspx");
        }

        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Add();
            }
            catch (Exception ex)
            {
                lblError.Text = "Ha Ocurrido un Error Al guardar La hacer el registro: " + ex.Message;

            }
        }

        protected void BtnClientesRegistrados_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    
    }
}