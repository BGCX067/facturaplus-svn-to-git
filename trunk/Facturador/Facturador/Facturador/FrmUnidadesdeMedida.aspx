<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmUnidadesdeMedida.aspx.cs" Inherits="Facturador.FrmUnidadesdeMedida" %>
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
    <td width="30%" align="right"> Unidades de Médida:</td>
    <td width="70%" align="left"> 
        <asp:TextBox ID="txtUnidaddeMedida" name="txtUnidaddeMedida" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="UnidaddeMedida" ControlToValidate="txtUnidaddeMedida" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione la Descripción</asp:RequiredFieldValidator>
        </td>
    </tr>
        <tr>
            <td align="right" width="30%">
                    <asp:Button ID="btnSave" runat="server" Text="Guardar "  CausesValidation="true"
                    onclick="btnSave_Click" />
                
            </td>
             <td align="center" width="70%">
            <asp:Button ID="BtnCancel" runat="server" Text="Cancelar" />
            </td>
        </tr>
    </table>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

