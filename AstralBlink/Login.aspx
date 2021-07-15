<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="StyleSheet.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
    .auto-style18 {
            width: 220px;
        }
    .auto-style20 {
        height: 20px;
    }
        .auto-style21 {
            height: 26px;
            font-size: xx-large;
            text-align: center;
        }
        .auto-style22 {
            width: 208px;
        }
        .auto-style23 {
            width: 860px;
            text-align: center;
            font-size: xx-large;
        }
        .auto-style24 {
            font-size: x-large;
        }
        .auto-style25 {
        text-align: center;
    }
    .auto-style26 {
        width: 833px;
        text-align: center;
        font-size: xx-large;
        }
        .auto-style27 {
            font-size: x-large;
            margin-bottom: 0px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table class="auto-style1">
        <tr>
            <td class="auto-style26">Astral Blink Account<br />
                <br />
                <span class="auto-style27">Username:</span><asp:TextBox ID="UsernameTxt" runat="server" Height="28px" Width="230px"></asp:TextBox>
                <br />
                <br />
                <span class="auto-style27">Password:</span><span class="auto-style24"><asp:TextBox ID="PasswordTxt" runat="server" Height="28px" Width="230px" TextMode="Password"></asp:TextBox>
                <br />
                <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click" CssClass="btn" />
                <br />
                <br />
                <asp:Label ID="ErorLbl" runat="server" ForeColor="#7E52DE"></asp:Label>
                </span></td>
            <td class="auto-style25">
                <asp:HyperLink ID="SignUp2Link" runat="server" NavigateUrl="~/Register.aspx" CssClass="Hlink">New user? Sign up here</asp:HyperLink>
                <br />
                <br />
                <asp:HyperLink ID="ForgotLink" runat="server" NavigateUrl="~/ForgotPass.aspx" CssClass="Hlink">Forgot Password? Click here</asp:HyperLink>
            </td>
        </tr>
    </table>

</asp:Content>

