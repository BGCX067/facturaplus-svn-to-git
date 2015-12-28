<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmEmisores.aspx.cs" Inherits="Facturador.FrmEmisores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
    <td width="30%" align="right"> RFC:</td>
    <td width="70%" align="left"> 
        <asp:TextBox ID="txtRFC" name="txtRFC" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtRFC" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione un RFC</asp:RequiredFieldValidator>

        </td>
    </tr>
    <tr>
    <td width="30%" align="right"> Razón Social:</td>
    <td width="70%" align="left"> 
        <asp:TextBox ID="txtRazonSocial" name="txtRazonSocial" runat="server" Width="300px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtRazonSocial" runat="server" ErrorMessage="RequiredFieldValidator">Proporcione una razón Social</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
    <td width="30%" align="right"> &nbsp;</td>
    <td width="70%" align="left"> </td>
    </tr>
        <caption>
            <tr>
                <td align="right" width="30%">
                    Calle</td>
                <td align="left" width="70%">
                    <asp:TextBox ID="txtCalle" name="txtCalle" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtCalle" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione la Calle</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="30%">
                    No. Exterior</td>
                <td align="left" width="70%">
                    <asp:TextBox ID="txtNoExterior" name="txtNoExterior" runat="server" Width="40px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtNoExterior" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione El No Exterior</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="30%">
                    No. Interior</td>
                <td align="left" width="70%">
                    <asp:TextBox ID="txtNoInterior" name="txtNoInterior" runat="server"></asp:TextBox>
                </td>
            </tr>
        </caption>
        <tr>
            <td align="right" width="30%">
                Colonia:</td>
            <td align="left" width="70%">
                <asp:TextBox ID="txtColonia" name="txtColonia" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtColonia" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione La Colonia</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="30%">
                Referencia:</td>
            <td align="left" width="70%">
                <asp:TextBox ID="txtReferencia" name="txtRererencia" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="30%">
                Localidad:</td>
            <td align="left" width="70%">
                <asp:TextBox ID="txtLocalidad" name="txtLocalidad" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtLocalidad" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione La Localidad</asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td align="right" width="30%">
                Estado:</td>
            <td align="left" width="70%">
                <asp:TextBox ID="txtEstado" name="txtEstado" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtEstado" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione El Estado</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="30%">
                Municipio:</td>
            <td align="left" width="70%">
                <asp:TextBox ID="txtMunicipio" name="txtMunicipio" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtMunicipio" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione el Municipio</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="30%">
                C.P.:</td>
            <td align="left" width="70%">
                <asp:TextBox ID="txtCP" runat="server" name="txtCP"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtCP" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione el CP.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" width="30%">
                Certificado:</td>
            <td align="left" width="70%">
                <asp:FileUpload ID="fuCertificado" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" width="30%">
                Llave del Certificado:</td>
            <td align="left" width="70%">
                <asp:FileUpload ID="fuLlave" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" width="30%">
                Logo:</td>
            <td align="left" width="70%">
                <asp:FileUpload ID="fuLogo" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" width="30%">
                Contraseña del certificado:</td>
            <td align="left" width="70%">
                <asp:TextBox ID="txtPassword" runat="server" name="txtMunicipio"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="30%">
                <asp:Button ID="BtnCancel" runat="server" Text="Cancelar" />
            </td>
             <td align="left" width="70%">
                <asp:Button ID="btnSave" runat="server" Text="Guardar "  CausesValidation="true"
                    onclick="btnSave_Click" />
            </td>
        </tr>
    </table>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
