<%@ Page Title="" Language="C#" MasterPageFile="~/External.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Facturador.RegistroCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="MainTitle" runat="server">
    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div id="Error">
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
    <div style="width: 100%">

    <table width="90%">
    <tr>
    <td width="30%" align="right">*Nombre:</td>
    <td width="70%" align="left"> 
        <asp:TextBox ID="txtNombre" name="txtNombre" runat="server" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" width="30%">
            *Empresa:</td>
        <td align="left" width="70%">
            <asp:TextBox ID="txtEmpresa" name="txtEmpresa" runat="server" Width="300px"></asp:TextBox>
        </td>
    </tr>
   
    <tr>
        <td align="right" width="30%">
            *Email:</td>
        <td align="left" width="70%">
            <asp:TextBox ID="txtEmail" name="txtEmail" runat="server" Width="300px"></asp:TextBox>
        </td>
     </tr>
      <tr>
        <td align="right" width="30%">
            *Password:</td>
        <td align="left" width="70%">
            <asp:TextBox ID="txtPassword" name="txtPassword" runat="server" Width="300px" 
                TextMode="Password"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td align="right" width="30%">
            *Confirmar Password:</td>
        <td align="left" width="70%">
            <asp:TextBox ID="txtConfirmPassword" name="txtConfirmPassword" runat="server" 
                Width="300px" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td align="right" width="30%">
            *Telefono:</td>
        <td align="left" width="70%">
            <asp:TextBox ID="txtTelefono" name="txtTelefono" runat="server" Width="120px"></asp:TextBox>
        </td>
    </tr>
    </tr>
      <tr>
        <td align="right" width="30%">
            *Captcha:</td>
        <td align="left" width="70%">
            <asp:TextBox ID="txtcaptcha" name="txtcaptcha" runat="server" Width="80px"></asp:TextBox>
        </td>
    </tr>
        <tr>
            <td align="right" width="30%">
                &nbsp;</td>
            <td align="left" width="70%">
                <asp:Button ID="btnSave" runat="server" CausesValidation="true" 
                    onclick="btnSave_Click" Text="Guardar "/>
                <asp:LinkButton ID="lnkRecuperarPassword" runat="server" Visible="False" 
                    onclick="lnkRecuperarPassword_Click">Recuperar Password</asp:LinkButton>
            </td>
        </tr>
    </table>
    </div>

    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="RegistroContent" runat="server">
</asp:Content>