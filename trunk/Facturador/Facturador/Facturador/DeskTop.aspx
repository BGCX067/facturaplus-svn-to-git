<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeskTop.aspx.cs" Inherits="Facturador.DeskTop" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div Id="TablaPrincipal">
<table style="width: 100%;">
    <tr>
        <td align="center">
           <span>Facturas/Notas de Crédito </span><br />
            <asp:ImageButton ID="BtnFacturas" runat="server" ImageUrl="img/report_256.png" Width="50px" Height="50px" PostBackUrl="ListComprobantes.aspx"/>
        </td>
        <td align="center">
            <span>Clientes </span><br />
            <asp:ImageButton ID="BtnClientes" imageurl="img/ClientsIcon.png" runat="server" Width="50px" Height="50px" PostBackUrl="ListReceptores.aspx"/>
        </td>
        <td align="center">
            <span>Usuarios </span><br />
            <asp:ImageButton ID="BtnUsuarios" imageurl="img/UsersIcon.png" runat="server" Width="50px" Height="50px" PostBackUrl="ListUsuarios.aspx"/>
        </td>
    </tr>
    <tr>
        <td align="center">
          <span>Articulos </span><br />
            <asp:ImageButton ID="BtnArticulos" imageurl="img/ProductsIcon.png" runat="server" Width="50px" Height="50px" PostBackUrl="ListArticulos.aspx"/>
        </td>
        <td align="center">
            <span>Impuestos </span><br />
            <asp:ImageButton ID="BtnImpuestos" imageurl="img/taxIcon.png" runat="server" Width="50px" Height="50px" PostBackUrl="ListImpuestos.aspx"/>
        </td>
        <td align="center">
             <span>Unidades de Médida </span><br />
            <asp:ImageButton ID="BtnUnidadesdeMedida"   imageurl="img/scaleIcon.png" runat="server" Width="50px" Height="50px" PostBackUrl="ListUnidadesdeMedida.aspx"/>
        </td>
    </tr>
    <tr>
        <td align="center">
            <span>Monedas </span><br />
            <asp:ImageButton ID="BtnMonedas" imageurl="img/MonedaIcon.png" runat="server" Width="50px" Height="50px" PostBackUrl="ListMonedas.aspx"/>
        </td>
        <td align="center">
            <span>Sucursales </span><br />
            <asp:ImageButton ID="BtnSucursales" imageurl="img/SucursalesIcon.png" runat="server" Width="50px" Height="50px" PostBackUrl="ListSucursales.aspx"/>
        </td>
        <td align="center">
           <span>Configuración General </span><br />
            <asp:ImageButton ID="ImageButton1" imageurl="img/ConfigurationIcon.png" runat="server" Width="50px" Height="50px" PostBackUrl="ListEmisores.aspx"/>
        </td>
    </tr>
</table>



</div>


</asp:Content>
