<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Store.aspx.cs" Inherits="Store" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="Stylesheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style25 {
            text-align: center;
        }
        .auto-style27 {
            font-size: x-large;
        }
        .auto-style31 {
            width: 100%;
            height: 184px;
        }
        .auto-style33 {
            text-align: center;
            height: 55px;
            width: 222px;
        }
        .auto-style34 {
            width: 222px;
        }
        .auto-style35 {
            height: 25px;
            text-align: left;
            width: 222px;
        }
        .auto-style36 {
            height: 25px;
            text-align: center;
            width: 222px;
        }
    .auto-style37 {
        width: 261px;
        text-align: center;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style37"></td>
        </tr>
        <tr>
            <td class="auto-style37">
                <asp:DataList ID="StoreDataList" runat="server" RepeatColumns="6" RepeatDirection="Horizontal" OnItemCommand="StoreDataList_ItemCommand" OnSelectedIndexChanged="StoreDataList_SelectedIndexChanged">
                    <ItemTemplate>
                        <div Class="datalist">
                        <table class="auto-style31">
                            <tr>
                                <td class="auto-style34">
                                    <asp:Image ID="GameImage" runat="server" Height="166px" ImageUrl='<%# Eval("GameImage") %>' Width="120px" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style33">
                                    <asp:Label ID="NameEngLbl" runat="server" CssClass="auto-style27" Text='<%# Eval("GameNameEN") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style35">
                                    Genre:
                                    <asp:Label ID="GenreLbl" runat="server" Text='<%# Eval("GameGenre") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style35">
                                    Price:
                                    <asp:Label ID="PriceLbl" runat="server" Text='<%# Eval("GamePrice") %>'></asp:Label>
                                    <asp:Label ID="ShekelLbl" runat="server" Text="₪" Width="20px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style36">
                                    <asp:Button ID="ViewBtn" runat="server" Text="View" CommandArgument='<%# Eval("GameCode") %>' CommandName="ViewDetails"  CssClass="button" />
                                </td>
                            </tr>
                        </table>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>

