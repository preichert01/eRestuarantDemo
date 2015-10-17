using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional NameSpaces
using eRestuarantSystem.BLL;  // controller
using eRestuarantSystem.DAL.Entities;  //Entity
using EatIn.UI;  // Delete process request
#endregion

public partial class CommandPages_WaiterAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {

        }
    }

    protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
    {
        MessageUserControl.HandleDataBoundException(e);
    }
    protected void WaiterDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        // to properly interface with our Message User Control 
        // we will delegatethe execution of this Click event 
        // under the MessageUserControl
        if (WaiterDropDownList.SelectedIndex == 0)
        {
            // issue our own error Message
            MessageUserControl.ShowInfo("Please Select a Waiter to Process");
        }
        else
        {
            // execute the necessary standart lookup code under the 
            // control of the MessageUserControl
            MessageUserControl.TryRun((ProcessRequest)GetWaiterInfo);
        }
    }

    public void GetWaiterInfo()
    {
        // a standard lookup process
        AdminController sysmgr = new AdminController();

        var waiter = sysmgr.GetWaiterByID(int.Parse(WaiterDropDownList.SelectedValue));
        WaiterID.Text = waiter.WaiterID.ToString();
        WaiterFirstName.Text = waiter.FirstName;
        WaiterLastName.Text = waiter.LastName;
        WaiterAddress.Text = waiter.Address;
        WaiterPhone.Text = waiter.Phone;
        WaiterHireDate.Text = waiter.HireDate.ToShortDateString();
        // null field check
        if (waiter.ReleaseDate.HasValue)
        {
            WaiterReleaseDate.Text = waiter.ReleaseDate.ToString();
        }
        else
        {
            WaiterReleaseDate.Text = "";
        }
    }
}