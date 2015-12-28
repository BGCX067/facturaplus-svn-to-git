<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmMonedas.aspx.cs" Inherits="Facturador.FrmMonedas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div id="Error">
        <asp:Label ID="lblError" runat="server" Text="" Visible="false"></asp:Label>
    </div>

    <div style="width: 100%">
    <table width="90%">
    <tr>
    <td width="30%" align="right"> Moneda:</td>
    <td width="70%" align="left"> 
        <asp:TextBox ID="txtMonenda" name="txtMonenda" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtMonenda" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione una Moneda</asp:RequiredFieldValidator>

        </td>
    </tr>
    <tr>
    <td width="30%" align="right"> Tipo de Cambio:</td>
    <td width="70%" align="left"> 
        <asp:TextBox ID="txtTipodeCambio" name="txtTipodeCambio" runat="server" Width="100px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtTipodeCambio" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione un Tipo de Cambio</asp:RequiredFieldValidator>
        </td>
    </tr>
   
            <tr>
                <td align="right" width="30%">
                    Prefijo:</td>
                <td align="left" width="70%">
                    <asp:TextBox ID="txtPrefijo" name="txtPrefijo" runat="server" Width="50px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPrefijo" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione Un Prefijo</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="30%">
                    Sígno:</td>
                <td align="left" width="70%">
                    <asp:TextBox ID="txtSigno" name="txtSigno" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtSigno" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione El Signo</asp:RequiredFieldValidator>
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

