<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="StyleSheet.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style25 {
            margin-top: 19px;
        }
        .auto-style26 {
            text-align: center;
        }
        .Kaguya{
            width:150px;
            overflow:scroll;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        &nbsp;</p>
    <p>
        Users Details</p>
    <p>
        <asp:GridView ID="UserGrid" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="UserGrid_RowCancelingEdit" OnRowDeleting="UserGrid_RowDeleting" OnRowEditing="UserGrid_RowEditing" OnRowUpdating="UserGrid_RowUpdating" AllowPaging="True" OnPageIndexChanging="UserGrid_PageIndexChanging" OnSelectedIndexChanging="UserGrid_SelectedIndexChanging" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
            <Columns>
                <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" />
                <asp:BoundField DataField="UserPassword" HeaderText="User Password" />
                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Country" HeaderText="Country" />
                <asp:CheckBoxField DataField="IsAdmin" HeaderText="Is Admin?" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
    </p>
    <p>
        <asp:Label ID="ErorLbl" runat="server" Text="Please enter valid information" Visible="False"></asp:Label>
    </p>
    <p>
        Game Details</p>
    <p>
        <asp:GridView ID="GameDetailsGrid" runat="server" OnRowCancelingEdit="GameDetailsGrid_RowCancelingEdit" OnRowDeleting="GameDetailsGrid_RowDeleting" OnRowEditing="GameDetailsGrid_RowEditing" OnRowUpdating="GameDetailsGrid_RowUpdating" AutoGenerateColumns="False" CssClass="kaguya" AllowPaging="True" OnPageIndexChanging="GameDetailsGrid_PageIndexChanging" OnPreRender="GameDetailsGrid_PreRender" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" PageSize="5">
            <Columns>
                <asp:BoundField DataField="GameCode" HeaderText="Game Code" ReadOnly="True" />
                <asp:BoundField DataField="GameNameEN" HeaderText="Game Name" />
                <asp:BoundField DataField="GameGenre" HeaderText="Game Genre" />
                <asp:BoundField DataField="GameYear" HeaderText="Game Year" />
                <asp:BoundField DataField="GamePrice" HeaderText="Game Price" />
                <asp:BoundField DataField="GameImage" HeaderText="Game Image" />
                <asp:BoundField DataField="GameSummary" HeaderText="Summary" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
    </p>
    <p>
        <asp:Label ID="ErorLbl2" runat="server" Text="Please enter valid information" Visible="False"></asp:Label>
    </p>
    <p>
        <asp:HyperLink ID="AddGameLink" runat="server" NavigateUrl="~/AddGame.aspx">Add new game</asp:HyperLink>
    </p>
    <p>
        &nbsp;</p>
    <p>
        Country Details</p>
    <p>
        <asp:GridView ID="CountryGrid" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="CountryGrid_RowCancelingEdit" OnRowDeleting="CountryGrid_RowDeleting" OnRowEditing="CountryGrid_RowEditing" OnRowUpdating="CountryGrid_RowUpdating" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
            <Columns>
                <asp:BoundField DataField="Country" HeaderText="Country" ReadOnly="True" />
                <asp:BoundField DataField="CCurrency" HeaderText="Currency" />
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    </p>
    <p>
        Add new country:</p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Country Name<asp:TextBox ID="CountryTxt" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp; Currency<span class="auto-style12">:</span><asp:TextBox ID="CurrencyTxt" runat="server"></asp:TextBox>
    </p>
    <p class="auto-style26">
        <asp:Button ID="AddCountryBtn" runat="server" OnClick="AddCountryBtn_Click" Text="Add Country" CssClass="btn" />
    </p>
</asp:Content>

