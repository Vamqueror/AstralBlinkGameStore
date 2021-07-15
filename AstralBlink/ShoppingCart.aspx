<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShoppingCart.aspx.cs" Inherits="ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link href="StyleSheet.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style26 {
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <br />
        <strong>
        <asp:Label ID="EmptyLbl" runat="server" Text="Your cart is empty" Visible="False" CssClass="auto-style26"></asp:Label>
        </strong>
        <asp:GridView ID="ShoppingCartGrid" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="ShoppingCartGrid_SelectedIndexChanged" ShowFooter="True" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <Columns>
                <asp:BoundField DataField="Count" HeaderText="s.NO" />
                <asp:BoundField DataField="GameCode" HeaderText="Game Code" />
                <asp:ImageField DataImageUrlField="GameImage" HeaderText="Image" ControlStyle-Height="166" ControlStyle-Width="120" >
                
<ControlStyle Height="166px" Width="120px"></ControlStyle>
                </asp:ImageField>
                
                <asp:BoundField DataField="GameNameEN" HeaderText="Name" />
                <asp:BoundField DataField="GamePrice" HeaderText="Price" />
            </Columns>
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
    </p>
<p>
       </p>
    <p>
        <asp:LinkButton ID="ClearCartBtn" runat="server" OnClick="ClearCartBtn_Click" CssClass="Hlink">Clear Shopping Cart </asp:LinkButton>
    </p>
    <p>
        <asp:ImageButton ID="CheckoutBtn" runat="server" OnClick="CheckoutBtn_Click" ImageUrl="~/Images/PurchaseButton.png"  Width="120px" />
    </p>
</asp:Content>

