<%@ Page Title="" Language="C#" MasterPageFile="~/External.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Facturador.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Styles/Main.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Registro.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="MainTitle" runat="server">
    <span>
Paquetes
</span>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="RegistroContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table class="tablaRegistro" >
    <tr>
    <td width="30%" align="right">*Nombre:</td>
    <td width="70%" align="left"> 
        <asp:TextBox ID="txtNombre" name="txtNombre" runat="server" Width="200px">
           </asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator100" SetFocusOnError=true ControlToValidate="txtNombre" runat="server" ErrorMessage="*" ForeColor="red" Font-Size="X-Large"></asp:RequiredFieldValidator> 
    </td>
   
    </tr>
    <tr>
        <td align="right" width="30%">
            *Empresa:
            </td>
        <td align="left" width="70%">
            <asp:TextBox ID="txtEmpresa" name="txtEmpresa" runat="server" Width="200px"></asp:TextBox>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError=true ControlToValidate="txtEmpresa" runat="server" ErrorMessage="*" ForeColor="red" Font-Size="X-Large"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" width="30%">
            *Telefono:</td>
        <td align="left" width="70%">
            <asp:TextBox ID="txtTelefono" name="txtTelefono" runat="server" Width="120px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" SetFocusOnError=true ControlToValidate="txtTelefono" runat="server" ErrorMessage="*" ForeColor="red" Font-Size="X-Large"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" width="30%">
            *Correo:</td>
        <td align="left" width="70%">
            <asp:TextBox ID="txtEmail" name="txtEmail" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError=true ControlToValidate="txtEmail" runat="server" ErrorMessage="*" ForeColor="red" Font-Size="X-Large"></asp:RequiredFieldValidator>
        </td>
     </tr>
    <tr>
        <td align="right" width="30%">
            *Contraseña:</td>
        <td align="left" width="70%">
            <asp:TextBox ID="txtPassword" name="txtPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" SetFocusOnError=true ControlToValidate="txtPassword" runat="server" ErrorMessage="*" ForeColor="red" Font-Size="X-Large"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
            <td align="right" width="30%">
            
            </td>
            <td align="left" width="70%">
             <asp:Button ID="BtnRegistrar" runat="server" CausesValidation="true" 
                    Text="Registrarse" CssClass="button pngfix" onclick="BtnRegistrar_Click" />
                  <asp:Button ID="BtnClientesRegistrados" runat="server" 
                    CausesValidation="false"  Text="Clientes" CssClass="button color-button pngfix" 
                    onclick="BtnClientesRegistrados_Click"/>
            </td>
        </tr>
    <tr>
            <td colspan="2">
                 <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                 <asp:LinkButton ID="lnkRecuperarPassword" runat="server" Visible="False"  onclick="lnkRecuperarPassword_Click" ForeColor="white" CausesValidation="false">Recuperar Password</asp:LinkButton>
             </td>           
        </tr>
    </table>    
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<br />

<div id="divPaquetes" class="DivPaquetes">


<div id="divPaquete100" class="arrow_box">
<br />
<h2>Paquete 100</h2>
<h3>100 Facturas<h3>
<h3>Hasta 3 Contribuyentes</h3>
<h3>$799.00 + IVA</h3>
</div>

<div id="DivPaquete200" class="arrow_box">
<br />
<h2>Paquete 200</h2>
<h3>200 Facturas<h3>
<h3>Hasta 3 Contribuyentes</h3>
<h3>$1499.00 + IVA</h3>
</div>

<div id="DivPaquete500" class="arrow_box">
<br />
<h2>Paquete 500</h2>
<h3>500 Facturas<h3>
<h3>Hasta 5 Contribuyentes</h3>
<h3>2199.00 + IVA</h3>

</div>

<div id="DivPaquete1000" class="arrow_box">
<br />
<h2>Paquete 1000</h2>
<h3>1000 Facturas<h3>
<h3>Hasta 5 Contribuyentes</h3>
<h3>2999.00 + IVA</h3>

</div>

</div>

<div id="InformacionPructo">
<p>
<h2> Porque Usar Facturaplus. </h2>
Por que es la manera más fácil de emitir facturas electrónicas para su empresa, que deriva en múltiples beneficios para usted y sus clientes,  elevando la eficiencia de procesos, así como los niveles de calidad y servicio al cliente. Facturaplus  es una aplicación de facturación electrónica desarrollado para Internet, que cumple con todos los estándares definidos por el SAT e incluye timbrado CFDI, a través de una clave y su usted tiene acceso  para dar de alta sus productos o servicios, clientes, sucursales, todo lo necesario para  comenzar a generar su factura electrónica .

•	Confiable, el sistema siempre está en línea.
•	Seguro. El sistema cuenta con un certificado SSL para mejor protección de los datos. Toda la información viaja en un canal seguro.
•	Reducción de Costos. Con la Facturación electrónica ya no necesita almacenar sus facturas en papel, Nosotros guardamos la Información hasta por 10 años.
•	Confiabilidad. Nosotros Validamos la Factura antes de enviarla al SAT.
•	 Facilidad de Uso. Es muy simple usar el sistema con 10 min. Usted puede hacerse experto en facturación electrónica.
•	Fácil Acceso. Solo necesita una conexión de Internet. Lo demás Nosotros lo hacemos.

</p>

</div>

</asp:Content>
