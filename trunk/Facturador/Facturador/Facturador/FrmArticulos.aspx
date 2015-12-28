<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmArticulos.aspx.cs" Inherits="Facturador.FrmArticulos" %>
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
    <td width="30%" align="right"> Descripción:</td>
    <td width="70%" align="left"> 
        <asp:TextBox ID="txtDescripción" name="txtDescripción" runat="server" Width="400px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDescripción" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione una Descripción</asp:RequiredFieldValidator>

        </td>
    </tr>
    <tr>
    <td width="30%" align="right"> Clave Interna:</td>
    <td width="70%" align="left"> 
        <asp:TextBox ID="txtClaveInterna" name="txtClaveInterna" runat="server" Width="300px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtClaveInterna" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione una Clave </asp:RequiredFieldValidator>
        </td>
    </tr>
            <tr>
                <td align="right" width="30%">
                    Código de Barras</td>
                <td align="left" width="70%">
                    <asp:TextBox ID="txtCodigodeBarras" name="txtCodigodeBarras" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="30%">
                    Precio Unitario</td>
                <td align="left" width="70%">
                    <asp:TextBox ID="txtPrecioUnitario" name="txtPrecioUnitario" runat="server" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtNoExterior" runat="server" ErrorMessage="RequiredFieldValidator"><br/>Proporcione un Precio</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" width="30%"></td>
                <td align="left" width="70%">
                    <asp:CheckBox ID="chkCausaIva"  runat="server" />
                </td>
            </tr>
      
        <tr>
            <td align="right" width="30%">
            Impuesto 1:
            </td>
            <td align="left" width="70%">
                <asp:DropDownList ID="ddImpuesto1" runat="server" Width="300px"> 
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" width="30%">
                Impuesto 2:</td>
            <td align="left" width="70%">
                <asp:DropDownList ID="ddImpuesto2" runat="server" Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" width="30%">
                Impuesto 3: 
            </td>
            <td align="left" width="70%">
                <asp:DropDownList ID="ddImpuesto3" runat="server" Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" width="30%">
                Unidad de Médida:</td>
            <td align="left" width="70%">
                <asp:DropDownList ID="ddUnidaddemedida" runat="server" Width="300px">
                </asp:DropDownList>
           </td>
        </tr>
        <tr>
            <td align="right" width="30%">
                Familia:</td>
            <td align="left" width="70%">
                <asp:DropDownList ID="ddFamilia" runat="server" Width="300px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" width="30%">
               </td>
            <td align="left" width="70%">
                <asp:CheckBox ID="chkActivo" runat="server" Text="Activo" />
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
