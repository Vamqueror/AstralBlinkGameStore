<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Showdown.aspx.cs" Inherits="Showdown" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="StyleSheet.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style26 {
            text-align: center;
        }
        .auto-style28 {
            width: 283px;
        }
        .auto-style30 {
            font-size: xx-large;
        }
    .auto-style31 {
        width: 161px;
    }
        .auto-style32 {
            height: 20px;
            width: 161px;
        }
        .auto-style33 {
            background-color: #000000;
            width: 523px;
            color: #7e52de;
            justify-content: center;
            margin: 0px auto 0px auto;
        }
        .auto-style34 {
            width: 523px;
            height: 20px;
        }
        .auto-style35 {
            width: 465px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
    <tr>
        <td class="auto-style34">
            <asp:Image ID="AiCardLeft" runat="server" Height="200px" ImageUrl="/images-Showdown/CardBack.png" />
            <br />
            <br />
        </td>
        <td class="auto-style35">
            <asp:Image ID="AiCardMid" runat="server" Height="200px" ImageUrl="/images-Showdown/CardBack.png" />
            <br />
            <br />
        </td>
        <td class="auto-style32">
            <asp:Image ID="AiCardRight" runat="server" Height="200px" ImageUrl="/images-Showdown/CardBack.png" />
            <br />
            <br />
        </td>
        <td class="auto-style20">
            <asp:HyperLink ID="TutorialLink" runat="server" NavigateUrl="~/ShowdownTutorial.aspx" CssClass="Hlink">Game Tutorial</asp:HyperLink>
            <br />
            <br />
            <br />
        </td>
    </tr>
    <tr>
        <td class="auto-style33">
            <asp:Image ID="PlayerCardLeft" runat="server" Height="200px" ImageUrl="/images-Showdown/CardBack.png" />
        </td>
        <td class="auto-style35">
            <asp:Image ID="PlayerCardMid" runat="server" Height="200px" ImageUrl="/images-Showdown/CardBack.png" />
        </td>
        <td class="auto-style31">
            <asp:Image ID="PlayerCardRight" runat="server" Height="200px" ImageUrl="/images-Showdown/CardBack.png" />
        </td>
        <td>
            <asp:Label ID="YourCardsLbl" runat="server" Text="&lt;-Your cards" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style26" colspan="4">
            <asp:Button ID="WeakerBtn" runat="server" Text="Weaker" Visible="False" OnClick="WeakerBtn_Click" CssClass="btn" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="StartBtn" runat="server" OnClick="StartBtn_Click" Text="Start" CssClass="btn" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="StrongerBtn" runat="server" OnClick="StrongerBtn_Click" Text="Stronger" Visible="False" CssClass="btn" />
        </td>
    </tr>
    <tr>
        <td class="auto-style26" colspan="4">
            <asp:Label ID="ResultLbl" runat="server" CssClass="auto-style30" Visible="False"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

