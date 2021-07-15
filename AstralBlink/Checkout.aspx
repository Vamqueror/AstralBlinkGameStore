<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style26 {
        width: 100%;
        height: 426px;
    }
    .auto-style27 {
        width: 513px;
        text-align: center;
    }
    .auto-style28 {
        width: 513px;
        text-align: left;
    }
        .auto-style30 {
            font-size: large;
        }
        .auto-style31 {
            color: #7E52DE;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style26">
    <tr>
        <td class="auto-style3">
            <br />
            Credit Card Number
            <asp:TextBox ID="CreditNumTxt" runat="server" CssClass="auto-style31"></asp:TextBox>
            <br />
            <br />
            CVV&nbsp;
            <asp:TextBox ID="CVVTxt" runat="server" CssClass="auto-style31"></asp:TextBox>
            <br />
            <br />
            First Name&nbsp;
            <asp:TextBox ID="FirstTxt" runat="server" CssClass="auto-style31"></asp:TextBox>
            <br />
            <br />
            Last Name&nbsp;
            <asp:TextBox ID="LastTxt" runat="server" CssClass="auto-style31"></asp:TextBox>
            <br />
            <br />
            Credit Card Type&nbsp;
            <asp:DropDownList ID="TypeDDL" runat="server" CssClass="auto-style31">
                <asp:ListItem>Select Type</asp:ListItem>
                <asp:ListItem>Visa</asp:ListItem>
                <asp:ListItem>Cal</asp:ListItem>
                <asp:ListItem>IsraCard</asp:ListItem>
                <asp:ListItem>American Express</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            Expiration month
            <asp:TextBox ID="MonthTxt" runat="server" CssClass="auto-style31"></asp:TextBox>
            <br />
            <br />
            Expiration year&nbsp;
            <asp:TextBox ID="YearTxt" runat="server" CssClass="auto-style31"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="ErorLbl" runat="server"></asp:Label>
        </td>
        <td rowspan="2">
            Order ID<span class="auto-style30">: </span>
            <asp:Label ID="OrderIdLbl" runat="server"></asp:Label>
            <br />
            Order Date<span class="auto-style30">: </span>
            <asp:Label ID="OrderDateLbl" runat="server"></asp:Label>
            <br />
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
            <br />
            <br />
            <br />
            <asp:GridView ID="OrderDetailsGrid" runat="server" OnSelectedIndexChanged="OrderDetailsGrid_SelectedIndexChanged" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td class="auto-style27">
            <asp:ImageButton ID="CheckOutBtn" runat="server" ImageUrl="~/Images/CheckoutButton.png" OnClick="CheckOutBtn_Click" Width="80px" />
        </td>
    </tr>
</table>
</asp:Content>

