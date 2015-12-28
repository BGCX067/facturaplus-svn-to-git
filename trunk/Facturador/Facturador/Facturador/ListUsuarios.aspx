<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListUsuarios.aspx.cs" Inherits="Facturador.ListUsuarios" %>
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
    <br/>
    <br/>
        <div>
            <asp:Button ID="btnAdd" runat="server" Text="Agregar Usuario" onclick="btnAdd_Click" />
        </div>
        <div>
        <asp:GridView ID="gdUsuarios" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None"  DataKeyNames="PkUsuarioId"   AutoGenerateColumns="False" 
                ShowHeaderWhenEmpty="True" 
                onrowdeleting="gdUsuarios_RowDeleting" onrowediting="gdUsuarios_RowEditing" >
            <AlternatingRowStyle BackColor="White" />
            
            <Columns>
            <asp:BoundField DataField="PkUsuarioId" HeaderText="PkUsuarioId" SortExpression="PkUsuarioId" Visible="False" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre"  />
                <asp:BoundField DataField="Apellidos"  HeaderText="Apellidos"  SortExpression="Apellidos" />
                <asp:BoundField DataField="Puesto"  HeaderText="Puesto"  SortExpression="Puesto" />

                <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Eliminar" 
                    ShowHeader="True" Text="Eliminar" />
                <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Editar" 
                    ShowHeader="True" Text="Editar" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        </div>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

