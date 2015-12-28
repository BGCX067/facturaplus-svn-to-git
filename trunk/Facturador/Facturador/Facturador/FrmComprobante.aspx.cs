using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Facturador
{
    public partial class FrmComprobante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Notes.Modules.Clear();
            Notes.Tools.Clear();
            //Notes.EditModes = EditModes.Design;
            RadGrid1.SelectedIndexes.Add(0);

        }

        protected void RadGrid1_DataBound(object sender, EventArgs e)
        {
            //GridDataItem selectedItem = RadGrid1.Items[0];
            //EmployeeID.Text = selectedItem["EmployeeID"].Text;
            //FirstName.Text = selectedItem["FirstName"].Text;
            //LastName.Text = selectedItem["LastName"].Text;
            //Title.Text = selectedItem["Title"].Text;
            //TitleOfCourtesy.FindItemByText(selectedItem["TitleOfCourtesy"].Text).Selected = true;
            //BirthDate.SelectedDate = DateTime.Parse(selectedItem["BirthDate"].Text);
            //Notes.Content = selectedItem["Notes"].Text;

        }

        protected void RadGrid1_ColumnCreated(object sender, Telerik.Web.UI.GridColumnCreatedEventArgs e)
        {
            if (e.Column.IsBoundToFieldName("BirthDate"))
            {
                //((GridBoundColumn)e.Column).DataFormatString = "{0:MM/dd/yyyy}";
            }
            else if (e.Column.IsBoundToFieldName("Notes"))
            {
                e.Column.Visible = false;
            }

        }
    }
}