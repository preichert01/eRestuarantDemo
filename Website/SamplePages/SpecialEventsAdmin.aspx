<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SpecialEventsAdmin.aspx.cs" Inherits="SamplePages_SpecialEventsAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <table align="center" style="width: 70%">
        <tr>
            <td align="right" style="width:41%">Select an Event:</td>
            <td style="height: 24px">
                <asp:DropDownList ID="SpecialEventList" runat="server" AppendDataBoundItems="True" Height="27px" Width="195px" AutoPostBack="True" DataSourceID="ODSSpecialEvents" DataTextField="Description" DataValueField="EventCode">
                    <asp:ListItem Value="z">Select Event</asp:ListItem>
                </asp:DropDownList>
&nbsp;<asp:LinkButton ID="FetchRegistrations" runat="server" ToolTip="Fetch Registrations">Fetch Registrations</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:GridView ID="ReservationList" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ODSReservaations" PageSize="25" ToolTip="Reservations">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <Columns>
                        <asp:BoundField DataField="CustomerName" HeaderText="Name" SortExpression="CustomerName">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReservationDate" DataFormatString="{0:MMM dd, yyyyy, HH mm}" HeaderText="Date" SortExpression="ReservationDate">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NumberInParty" HeaderText="Size" SortExpression="NumberInParty">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ContactPhone" HeaderText="Phone#" SortExpression="ContactPhone">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReservationStatus" HeaderText="Status" SortExpression="ReservationStatus">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        No Data at this time, Select a Event
                    </EmptyDataTemplate>
                    <HeaderStyle BackColor="#999999" Font-Size="Large" />
                    <PagerSettings FirstPageText="Start" LastPageText="End" Mode="NumericFirstLast" PageButtonCount="4" Position="TopAndBottom" />
                </asp:GridView>
</td>
        </tr>
        <tr>
            <td style="width: 41%">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:DetailsView ID="ReservationListDV" runat="server" AllowPaging="True" AutoGenerateRows="False" DataSourceID="ODSReservaations">
                    <EmptyDataTemplate>
                        No Data To Display
                    </EmptyDataTemplate>
                    <Fields>
                        <asp:BoundField DataField="ReservationID" HeaderText="ReservationID" SortExpression="ReservationID" Visible="False" />
                        <asp:BoundField DataField="CustomerName" HeaderText="Name" SortExpression="CustomerName">
                        <HeaderStyle BackColor="#999999" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReservationDate" DataFormatString="{0:MMM dd,yyyy HH:mm }" HeaderText="Date" SortExpression="ReservationDate">
                        <HeaderStyle BackColor="#999999" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NumberInParty" HeaderText="# in Party" SortExpression="NumberInParty">
                        <HeaderStyle BackColor="#999999" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ContactPhone" HeaderText="Phone#" SortExpression="ContactPhone">
                        <HeaderStyle BackColor="#999999" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ReservationStatus" HeaderText="Status" SortExpression="ReservationStatus">
                        <HeaderStyle BackColor="#999999" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EventCode" HeaderText="Event Code" SortExpression="EventCode">
                        <HeaderStyle BackColor="#999999" />
                        </asp:BoundField>
                    </Fields>
                </asp:DetailsView>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ODSSpecialEvents" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SpecialEvents_List" TypeName="eRestuarantSystem.BLL.AdminController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODSReservaations" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetReservationsByEventCode" TypeName="eRestuarantSystem.BLL.AdminController">
        <SelectParameters>
            <asp:ControlParameter ControlID="SpecialEventList" Name="eventcode" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </asp:Content>

