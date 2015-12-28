<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmComprobante.aspx.cs" Inherits="Facturador.FrmComprobante" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
       <script type="text/javascript">
           var employeeID, currentEmployee, currentRowIndex = null;
           var employee =
           {
               EmployeeID: null,
               FirstName: null,
               LastName: null,
               Title: null,
               TitleOfCourtesy: null,
               BirthDate: null,
               Notes: null,

               create: function () {
                   var obj = new Object();
                   obj.EmployeeID = "";
                   obj.FirstName = "";
                   obj.LastName = "";
                   obj.Title = "";
                   obj.TitleOfCourtesy = "";
                   obj.BirthDate = "";
                   obj.Notes = "";
                   return obj;
               }
           };

           function getDataItemKeyValue(radGrid, item) {
               return parseInt(radGrid.get_masterTableView().getCellByColumnUniqueName(item, "EmployeeID").innerHTML);
           }

           function pageLoad(sender, args) {
               //employeeID = $find("<%= RadGrid1.ClientID %>").get_masterTableView().get_dataItems()[0].getDataKeyValue("EmployeeID");
               employeeID = getDataItemKeyValue($find("<%= RadGrid1.ClientID %>"), $find("<%= RadGrid1.ClientID %>").get_masterTableView().get_dataItems()[0]);
               $find("<%= LastName.ClientID %>").focus();
           }

           function rowSelected(sender, args) {
               //employeeID = args.getDataKeyValue("EmployeeID");
               employeeID = getDataItemKeyValue(sender, args.get_gridDataItem());

               currentRowIndex = args.get_gridDataItem().get_element().rowIndex;
               $find("<%= RadTabStrip1.ClientID %>").set_selectedIndex(0);

               MyWebService.GetEmployeeByEmployeeID(employeeID, setValues)
           }

           function setValues(employee) {
               $get("<%= EmployeeID.ClientID %>").innerHTML = employee.EmployeeID;
               $find("<%= LastName.ClientID %>").set_value(employee.LastName);
               $find("<%= FirstName.ClientID %>").set_value(employee.FirstName);
               $find("<%= Title.ClientID %>").set_value(employee.Title);
               $find("<%= TitleOfCourtesy.ClientID %>").findItemByText(employee.TitleOfCourtesy).select();
               $find("<%= BirthDate.ClientID %>").set_selectedDate(employee.BirthDate);
               $find("<%= Notes.ClientID %>").set_html(employee.Notes);
               $find("<%= LastName.ClientID %>").focus();
           }
           function getValues() {
               employee.EmployeeID = $get("<%= EmployeeID.ClientID %>").innerHTML;
               employee.LastName = $find("<%= LastName.ClientID %>").get_value();
               employee.FirstName = $find("<%= FirstName.ClientID %>").get_value();
               employee.Title = $find("<%= Title.ClientID %>").get_value();
               employee.TitleOfCourtesy = $find("<%= TitleOfCourtesy.ClientID %>").get_value();
               employee.BirthDate = $find("<%= BirthDate.ClientID %>").get_selectedDate();
               employee.Notes = $find("<%= Notes.ClientID %>").get_html();
               return employee;
           }
           function updateChanges() {
               MyWebService.UpdateEmployeeByEmployee(getValues(), updateGrid);
           }

           function updateGrid(result) {
               var tableView = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
               tableView.set_dataSource(result);
               tableView.dataBind();

               var grid = $find("<%= RadGrid1.ClientID %>");
               grid.repaint();
           }

           function tabSelected(sender, args) {
               if (currentEmployee == null) {
                   currentEmployee = getValues();
               }

               switch (args.get_tab().get_index()) {
                   case 1:
                       {
                           var gridItems = $find("<%= RadGrid1.ClientID %>").get_masterTableView().get_dataItems();
                           //var newID = parseInt(gridItems[gridItems.length - 1].getDataKeyValue("EmployeeID")) + 1;                                                
                           var newID = getDataItemKeyValue($find("<%= RadGrid1.ClientID %>"), gridItems[gridItems.length - 1]) + 1;
                           var newEmployee = employee.create();
                           newEmployee.EmployeeID = newID;
                           setValues(newEmployee);

                           $get(" <%= SaveChanges.ClientID %>").value = "Add";
                           $get(" <%= Delete.ClientID %>").style.display = "none";

                           break;
                       }
                   default:
                       {
                           setValues(currentEmployee);
                           currentEmployee = null;
                           $get(" <%= SaveChanges.ClientID %>").value = "Save";
                           $get(" <%= Delete.ClientID %>").style.display = "";
                           break;
                       }
               }
           }

           function deleteCurrent() {
               var table = $find("<%= RadGrid1.ClientID %>").get_masterTableView().get_element();
               var row = table.rows[currentRowIndex];
               table.deleteRow(currentRowIndex);

               var dataItem = $find(row.id);
               if (dataItem) {
                   dataItem.dispose();
                   Array.remove($find(" <%= RadGrid1.ClientID %>").get_masterTableView()._dataItems, dataItem);
               }

               var gridItems = $find("<%= RadGrid1.ClientID %>").get_masterTableView().get_dataItems();
               MyWebService.DeleteEmployeeByEmployeeID(employeeID, updateGrid);
               gridItems[gridItems.length - 1].set_selected(true);
           }
                       
       </script>
   </telerik:RadCodeBlock>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div id="divComprobante">
        
        <table style="width: 90%; column-span:0 ; border:none;  ">
             <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>Clave
                </td>
                <td>Unidad de Médida
                </td>
                <td>Cantidad 
                </td>
                <td>Descripción
                </td>
                <td>Precio Unitario
                </td>
                <td>Importe
                </td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
                </td>
                <td><asp:TextBox ID="txtUnidaddeMedida" runat="server"></asp:TextBox>
                </td>
                <td><asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                </td>
                <td><asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                </td>
                <td><asp:TextBox ID="txtPrecioUnitario" runat="server"></asp:TextBox>
                </td>
                <td><asp:TextBox ID="TxtImporte" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr></table>
  
      </div>  

           <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
           <Services>
               <asp:ServiceReference Path="MyWebService.asmx" />                
           </Services>
       </telerik:RadScriptManager>
       <!-- content start -->
       <div style="height: 100%; padding: 10px">
    
       <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server" />
       <telerik:RadGrid ID="RadGrid1" CssClass="grid" DataSourceID="SqlDataSource1" runat="server"
           GridLines="None" OnDataBound="RadGrid1_DataBound" OnColumnCreated="RadGrid1_ColumnCreated" Height="300px">
           <MasterTableView TableLayout="Fixed" ClientDataKeyNames="EmployeeID" />                       
           <ClientSettings>
               <Selecting AllowRowSelect="true" />
               <ClientEvents OnRowSelected="rowSelected"/>
               <Scrolling AllowScroll="true" UseStaticHeaders="true" />
           </ClientSettings>
       </telerik:RadGrid>   
       
       <asp:SqlDataSource runat="server" ID="SqlDataSource1"
           ConflictDetection="CompareAllValues"
           ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"            
           SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [Notes] FROM [Employees]">            
       </asp:SqlDataSource>
       
       <telerik:RadTabStrip ID="RadTabStrip1" OnClientTabSelected="tabSelected" Style="margin-top: 10px;"
           SelectedIndex="0" runat="server" >
           <Tabs>
               <telerik:RadTab Text="Edit employee" />
               <telerik:RadTab Text="Add new employee" />
           </Tabs>
       </telerik:RadTabStrip>
       <div style="border: 1px solid threedshadow;">
           <table border="0" style="margin-top: 20px; width: 100%;">
               <tr>
                   <td>
                        Employee ID:
                   </td>
                   <td>
                        <asp:Label ID="EmployeeID" Style="float: left; font-weight: bold;" runat="server" />
                        <asp:Button ID="SaveChanges" CssClass="button" Style="float: right; color: black;
                            font-weight: bold;" OnClientClick="updateChanges(); return false;" Text="Save"
                            runat="server" />
                        <asp:Button ID="Delete" CssClass="button" Style="float: right; margin-right: 10px;
                            color: black; font-weight: bold;" OnClientClick="if(!confirm('Are you sure you want to delete this employee?'))return false; deleteCurrent(); return false;"
                            Text="Delete" runat="server" />
                   </td>
               </tr>
               <tr>
                   <td>
                        Last name:
                   </td>
                   <td>
                        <telerik:RadTextBox ID="LastName" runat="server" />
                   </td>
               </tr>
               <tr>
                   <td>
                        First name:
                   </td>
                   <td>
                        <telerik:RadTextBox ID="FirstName" runat="server"/>
                   </td>
               </tr>
               <tr>
                   <td>
                        Title:
                   </td>
                   <td>
                        <telerik:RadTextBox ID="Title" runat="server" />
                   </td>
               </tr>
               <tr>
                   <td>
                        Title of courtesy:
                   </td>
                   <td>
                        <telerik:RadComboBox ID="TitleOfCourtesy" runat="server" >
                            <Items>
                                <telerik:RadComboBoxItem Text="" Value="" />
                                <telerik:RadComboBoxItem Text="Dr." Value="Dr." />
                                <telerik:RadComboBoxItem Text="Mr." Value="Mr." />
                                <telerik:RadComboBoxItem Text="Mrs." Value="Mrs." />
                                <telerik:RadComboBoxItem Text="Ms." Value="Ms." />
                            </Items>
                        </telerik:RadComboBox>
                   </td>
               </tr>
               <tr>
                   <td>
                        Birth date:
                   </td>
                   <td>
                        <telerik:RadDatePicker ID="BirthDate" MinDate="01/01/1900" runat="server" />
                   </td>
               </tr>
               <tr>
                   <td style="vertical-align: top;">
                        Notes:
                   </td>
                   <td style="height: 400px;float:left;">
                        <telerik:RadEditor ID="Notes"  Width="100%" runat="server" />
                   </td>
               </tr>
           </table>
       </div>
   </div>
       <!-- content end -->


    </ContentTemplate>
        
    </asp:UpdatePanel>
    
</asp:Content>

