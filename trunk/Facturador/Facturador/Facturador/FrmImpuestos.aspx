<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmImpuestos.aspx.cs" Inherits="Facturador.FrmImpuestos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div id="Error">
        <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
    </div>

    <div style="width: 100%">
    <table width="90%">
    <tr>
    <td width="30%" align="right"> Impuesto:</td>
    <td width="70%" align="left"> 
        <asp:TextBox ID="txtImpuesto" name="txtImpuesto" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtImpuesto" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione un Impuesto</asp:RequiredFieldValidator>

        </td>
    </tr>
     <tr>
    <td width="30%" align="right"> Tasa:</td>
    <td width="70%" align="left">
     <asp:TextBox ID="txtTasa" name="txtTasa" runat="server" Width="300px"></asp:TextBox>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtTasa" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione la Tasa</asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td width="30%" align="right"> Tipo Impuesto:</td>
    <td width="70%" align="left"> 
        <asp:DropDownList ID="ddtipoImpuesto" runat="server" width="300px">
        </asp:DropDownList>
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

