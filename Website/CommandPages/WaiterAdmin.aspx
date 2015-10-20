<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="WaiterAdmin.aspx.cs" Inherits="CommandPages_WaiterAdmin" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Waiter Admin CRUD</h1>
<uc1:MessageUserControl runat="server" ID="MessageUserControl" />

    <asp:Label ID="WaiterLabel" runat="server" Text="Waiters: "></asp:Label>
    <asp:DropDownList ID="WaiterDropDownList" runat="server" AppendDataBoundItems="True" AutoPostBack="True" DataSourceID="ObjectDataWaiterList" DataTextField="FullName" DataValueField="WaiterID" Height="18px" OnSelectedIndexChanged="WaiterDropDownList_SelectedIndexChanged" Width="318px">
        <asp:ListItem Value="0">Select a Waiter</asp:ListItem>
    </asp:DropDownList>
    
    <table align="center" style="width: 70%">   
        <tr>
            <td style="height: 22px">ID</td>
            <td style="height: 22px">
                <asp:Label ID="WaiterID" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>First Name</td>
            <td>
                <asp:TextBox ID="WaiterFirstName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td>
                <asp:TextBox ID="WaiterLastName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Address</td>
            <td>
                <asp:TextBox ID="WaiterAddress" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Phone</td>
            <td>
                <asp:TextBox ID="WaiterPhone" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Hire Date</td>
            <td>
                <asp:TextBox ID="WaiterHireDate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Release Date</td>
            <td>
                <asp:TextBox ID="WaiterReleaseDate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="WaiterInsert" runat="server" OnClick="WaiterInsert_Click">Insert</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="WaiterUpdate" runat="server" OnClick="WaiterUpdate_Click">Update</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ObjectDataWaiterList" runat="server" OldValuesParameterFormatString="original_{0}" OnSelected="CheckForException" SelectMethod="Waiters_List" TypeName="eRestuarantSystem.BLL.AdminController"></asp:ObjectDataSource>
</asp:Content>

