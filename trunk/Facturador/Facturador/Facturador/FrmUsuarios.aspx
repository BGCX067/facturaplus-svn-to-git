<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmUsuarios.aspx.cs" Inherits="Facturador.FrmUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div id="Error">
        <asp:Label ID="lblError" runat="server" Text="" Visible="False"></asp:Label>
    </div>
    <div style="width: 100%">
    <table width="90%">
    <tr>
    <td width="30%" align="right"> Nombre:</td>
    <td width="70%" align="left"> 
        <asp:TextBox ID="txtNombre" name="txtNombre" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtNombre" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione el Nombre</asp:RequiredFieldValidator>

        </td>
    </tr>
    <tr>
    <td width="30%" align="right"> Apellidos:</td>
    <td width="70%" align="left"> 
        <asp:TextBox ID="txtApellidos" name="txtApellidos" runat="server" Width="300px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtApellidos" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione Los Apellidos</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
                <td align="right" width="30%">
                    Puesto:</td>
                <td align="left" width="70%">
                    <asp:TextBox ID="txtPuesto" name="txtPuesto" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPuesto" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione El Puesto</asp:RequiredFieldValidator>
                </td>
            </tr>
    <tr>
                <td align="right" width="30%">
                    Rol:</td>
                <td align="left" width="70%">
                    <asp:DropDownList ID="cmbRol" runat="server">
                    </asp:DropDownList>
                   
                </td>
            </tr>
    <tr>
                <td align="right" width="30%">
                   Contraseña:</td>
                <td align="left" width="70%">
                    <asp:TextBox ID="txtPassword" name="txtPassword" runat="server" Width="40px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtPassword" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione una Contraseña</asp:RequiredFieldValidator>
                </td>
            </tr>
    <tr>
                <td align="right" width="30%">
                   Confirmar Contraseña:</td>
                <td align="left" width="70%">
                    <asp:TextBox ID="txtConfirmPassword" name="txtConfirmPassword" runat="server" Width="40px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtConfirmPassword" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Confirme la Contraseña</asp:RequiredFieldValidator>
                </td>
            </tr>
    <tr>
            <td align="right" width="30%">
                </td>
            <td align="left" width="70%">
                <asp:CheckBox ID="chkBloqueado" runat="server" />
            </td>
        </tr>
    <tr>
        <td align="right" width="30%">
            <asp:Button ID="BtnCancel" runat="server" Text="Cancelar" />
        </td>
        <td align="left" width="70%">
            <asp:Button ID="btnSave" runat="server" CausesValidation="true" 
                onclick="btnSave_Click" Text="Guardar " />
        </td>
        </tr>
    </table>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

