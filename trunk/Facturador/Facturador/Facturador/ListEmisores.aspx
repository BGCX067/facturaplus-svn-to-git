<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListEmisores.aspx.cs" Inherits="Facturador.ListEmisores" %>
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
            <asp:Button ID="btnAdd" runat="server" Text="Agregar Compañía" onclick="btnAdd_Click" />
        </div>
        <div>
        <asp:GridView ID="gdEmisores" runat="server" CellPadding="4" ForeColor="#333333" 
            GridLines="None"  DataKeyNames="PKEmisorId"   AutoGenerateColumns="False" 
                ShowHeaderWhenEmpty="True" 
                onrowdeleting="gdEmisores_RowDeleting" onrowediting="gdEmisores_RowEditing" >
            <AlternatingRowStyle BackColor="White" />
            
            <Columns>
            <asp:BoundField DataField="PKEmisorId" HeaderText="PKEmisorId" SortExpression="PKEmisorId" Visible="False" />
                <asp:BoundField DataField="RFC" HeaderText="RFC" SortExpression="RFC"  />
                <asp:BoundField DataField="RazonSocial"  HeaderText="Razón Social"  SortExpression="RazonSocial" />
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
