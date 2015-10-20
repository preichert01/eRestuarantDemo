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
        if (!Page.IsPostBack)
        {
            WaiterHireDate.Text = DateTime.Today.ToShortDateString();
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
    protected void WaiterInsert_Click(object sender, EventArgs e)
    {
        // inline version of using the MessageUser Controll
        MessageUserControl.TryRun(() => 
                // remainder of the code is what would have gone in the external method.
                // of (ProcessRequest(MethodName))
                {
                    Waiter item = new Waiter();
                    item.FirstName = WaiterFirstName.Text;
                    item.LastName = WaiterLastName.Text;
                    item.Address = WaiterAddress.Text;
                    item.Phone = WaiterPhone.Text;
                    item.HireDate = DateTime.Parse(WaiterHireDate.Text);

                    if (string.IsNullOrEmpty(WaiterReleaseDate.Text))
                    {
                        item.ReleaseDate = null;
                    }
                    else
                    {
                        item.ReleaseDate = DateTime.Parse(WaiterReleaseDate.Text);
                    }

                    AdminController sysmgr = new AdminController();
                    WaiterID.Text = sysmgr.Waiters_Add(item).ToString();
                    MessageUserControl.ShowInfo("Waiter added.");
                }
            );
    }
    protected void WaiterUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(WaiterID.Text))
        {
            MessageUserControl.ShowInfo("Please select a Waiter first!!!");
        }
        else
        {
            MessageUserControl.TryRun(() =>
            // remainder of the code is what would have gone in the external method.
            // of (ProcessRequest(MethodName))
            {
                Waiter item = new Waiter();
                item.WaiterID = int.Parse(WaiterID.Text);
                item.FirstName = WaiterFirstName.Text;
                item.LastName = WaiterLastName.Text;
                item.Address = WaiterAddress.Text;
                item.Phone = WaiterPhone.Text;
                item.HireDate = DateTime.Parse(WaiterHireDate.Text);

                if (string.IsNullOrEmpty(WaiterReleaseDate.Text))
                {
                    item.ReleaseDate = null;
                }
                else
                {
                    item.ReleaseDate = DateTime.Parse(WaiterReleaseDate.Text);
                }

                AdminController sysmgr = new AdminController();
                sysmgr.Waiter_Update(item);
                MessageUserControl.ShowInfo("Waiter updated.");
            }
            );
        }
    }
}