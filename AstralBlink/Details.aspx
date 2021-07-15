<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style26 {
            height: 170px;
            width: 306px;
            text-align: center;
        }
        .auto-style27 {
            width: 306px;
            text-align: center;
        }
        .auto-style28 {
            font-size: x-large;
        }
        .auto-style29 {
            font-size: xx-large;
        }
        .auto-style30 {
            margin-right: 646px;
        }
        .auto-style31 {
            width: 170px;
        }
        .auto-style32 {
            width: 210px;
        }
        .auto-style33 {
            font-size: medium;
            margin-left: 0px;
        }
        .auto-style34 {
            font-size: large;
        }
        .auto-style35 {
            background-color: #000000;
            width: 100%;
            color: #7e52de;
            justify-content: center;
            margin: 0px auto 0px auto;
            font-size: x-large;
        }
        .auto-style36 {
            font-size: x-large;
            margin-left: 0px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DataList ID="DetailsDataList" runat="server" OnItemCommand="DetailsDataList_ItemCommand" OnSelectedIndexChanged="DetailsDataList_SelectedIndexChanged" CssClass="auto-style30" Width="812px" RepeatDirection="Horizontal">
        <ItemTemplate>
            <table class="auto-style22">
                <tr>
                    <td class="auto-style26" rowspan="2">
                        <asp:Image ID="GameImage" runat="server" Height="332px" ImageUrl='<%# Eval("GameImage") %>' Width="240px" />
                    </td>
                    <td class="auto-style32">
                        <asp:Label ID="GameName" runat="server" CssClass="auto-style36" Text='<%# Eval("GameNameEN") %>' ForeColor="#7E52DE"></asp:Label>
                    </td>
                    <td class="auto-style31" style="margin-left:200px" rowspan="3">
                        <asp:Label ID="DetailsLbl" runat="server" Height="436px" Width="418px" Text='<%# Eval("GameSummary") %>' ForeColor="#7E52DE"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style32">
                        <span class="auto-style34">Genre:</span><asp:Label ID="GameGenre" runat="server" CssClass="auto-style33" Text='<%# Eval("GameGenre") %>' ForeColor="#7E52DE"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style27">
                        <br />
                        <asp:Label ID="PriceLbl" runat="server" CssClass="auto-style35" Text='<%# Eval("GamePrice") %>' ForeColor="#7E52DE"></asp:Label>
                        <asp:Label ID="ShekelLbl" runat="server" Text="₪" Width="20px"></asp:Label>
                        <br />&nbsp;<br />&nbsp;<asp:ImageButton ID="AddToCartBtn" runat="server" ImageUrl="~/Images/AddToCart.png" OnClick="AddToCartBtn_Click" CommandArgument='<%# Eval("GameCode") %>' CommandName="AddToCart" />
                        &nbsp;<asp:ImageButton ID="RedeemFreeBtn" runat="server" CommandArgument='<%# Eval("GameCode") %>' CommandName="RedeemToCart" Height="78px" OnClick="RedeemFreeBtn_Click" Width="190px" ImageUrl="~/Images/RedeemWin.png" />
                        &nbsp;<br /></td>
                    <td class="auto-style32">
                        <span class="auto-style34">Year:</span><asp:Label ID="GameYear" runat="server" CssClass="auto-style33" Text='<%# Eval("GameYear") %>' ForeColor="#7E52DE"></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <asp:Label ID="ErorLbl" runat="server" CssClass="auto-style12" Visible="False"></asp:Label>
</asp:Content>

