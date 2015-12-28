<%@ Page Title="" Language="C#" MasterPageFile="~/External.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Facturador.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="Styles/Main.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="MainTitle" runat="server">
    Entrar al sistema:
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
 </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div id="Error">
        <asp:Label ID="lblError" runat="server" Text="" Visible="False"></asp:Label>
    </div>
    <div style="width: 100%; margin: 0 auto;" >
    <table class="tablaLogin" >
    <tr>
    <td width="30%" align="right"> Correo Electrónico:</td>
    <td width="70%" align="left"> 
        <asp:TextBox ID="txtCoreoElectronico" name="txtCoreoElectronico" runat="server"  Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCoreoElectronico" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione el Correo Electrónico</asp:RequiredFieldValidator>

        &nbsp;

        </td>
    </tr>
    <tr>
    <td width="30%" align="right"> Password:</td>
    <td width="70%" align="left"> 
        <asp:TextBox ID="txtpassword" name="txtpassword" runat="server" Width="200px"  TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtpassword" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione la contraseña</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" width="30%">
            &nbsp;</td>
        <td align="left" width="70%">
            <asp:Button ID="btnLogin" runat="server" CausesValidation="true" 
                onclick="btnLogin_Click" Text="Entrar" />
            <asp:Label ID="lblMensaje" runat="server" Text="El Usuario no se ha encontrado,Presione el link para recordarle la contraseña" Visible="False"></asp:Label>&nbsp;
            <asp:LinkButton ID="lnkRecordarPassword" runat="server" Visible="False" CausesValidation="False"
                onclick="lnkRecordarPassword_Click" >Recordar password</asp:LinkButton>
            <asp:Label ID="lblRegistrarse" runat="server" 
                Text="Si todavia no se ha dado de alta puede hacerlo ahora Mismo." 
                Visible="True"></asp:Label>
            <asp:Button ID="btnRegistrarse" runat="server" CausesValidation="False" 
                 onclick="btnRegistrarse_Click" Text="Registrarse" 
                Visible="true" />
        </td>
        </tr>
        <tr>
            <td align="right" width="30%">
                &nbsp;</td>
            <td align="left" width="70%">
                &nbsp;</td>
        </tr>
    </table>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


