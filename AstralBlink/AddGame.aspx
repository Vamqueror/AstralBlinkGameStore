<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddGame.aspx.cs" Inherits="AddGame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style26 {
            width: 446px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style26" rowspan="2">Game Name&nbsp;
                <asp:TextBox ID="NameTxt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="NameTxt" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                <br />
                <br />
                Genre&nbsp;
                <asp:TextBox ID="GenreTxt" runat="server"></asp:TextBox>
                <br />
                <br />
                Release Year&nbsp;
                <asp:TextBox ID="YearTxt" runat="server"></asp:TextBox>
                <br />
                <br />
                Price&nbsp;
                <asp:TextBox ID="PriceTxt" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="Required" runat="server" ControlToValidate="PriceTxt" ErrorMessage="Required Field"></asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="PriceTxt" ErrorMessage="Must contain only numbers" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                <br />
                <br />
                Image Link&nbsp;
                <asp:TextBox ID="ImageTxt" runat="server"></asp:TextBox>
                <br />
                <br />
                Game Summary:<br />
                <br />
&nbsp;<asp:TextBox ID="SummaryTxt" runat="server" Height="278px" Width="284px"></asp:TextBox>
            </td>
            <td>
                <asp:GridView ID="GamesGrid" runat="server" AllowPaging="True" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="GamesGrid_PageIndexChanging" PageSize="5">
                    <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                    <RowStyle BackColor="White" ForeColor="#330099" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                    <SortedAscendingCellStyle BackColor="#FEFCEB" />
                    <SortedAscendingHeaderStyle BackColor="#AF0101" />
                    <SortedDescendingCellStyle BackColor="#F6F0C0" />
                    <SortedDescendingHeaderStyle BackColor="#7E0000" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="AddGameBtn" runat="server" OnClick="AddGameBtn_Click" Text="Add Game" />
            </td>
        </tr>
    </table>
</asp:Content>

