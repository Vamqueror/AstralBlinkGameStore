<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ForgotPass.aspx.cs" Inherits="ForgotPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="StyleSheet.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style27 {
            font-size: xx-large;
        }
        .auto-style28 {
            text-align: center;
            height: 178px;
        }
        .auto-style29 {
            width: 460px;
            text-align: center;
        }
        .auto-style31 {
            text-align: center;
            height: 30px;
        }
        .auto-style32 {
            height: 148px;
        }
        .auto-style26 {
            background-color: #FFFFFF;
        }
        .auto-style33 {
            text-align: center;
        }
        .auto-style34 {
            text-align: center;
            height: 18px;
        }
        .auto-style35 {
            background-color: #000000;
        }
        .auto-style37 {
            color: rgb(126, 82, 222);
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style34"><span class="auto-style27">Reclaim Password<br />
                <br />
                <span class="auto-style35" style="font-family: Avenir, &quot;Avenir Next&quot;, &quot;Helvetica Neue&quot;, Helvetica, Arial, &quot;ヒラギノ角ゴ ProN W3&quot;, &quot;Hiragino Kaku Gothic ProN&quot;, メイリオ, Meiryo, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">Please enter the e-mail address registered to your account, and then select Submit.</span><br class="auto-style35" style="box-sizing: border-box; font-family: Avenir, &quot;Avenir Next&quot;, &quot;Helvetica Neue&quot;, Helvetica, Arial, &quot;ヒラギノ角ゴ ProN W3&quot;, &quot;Hiragino Kaku Gothic ProN&quot;, メイリオ, Meiryo, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;" />
                <span class="auto-style35" style="font-family: Avenir, &quot;Avenir Next&quot;, &quot;Helvetica Neue&quot;, Helvetica, Arial, &quot;ヒラギノ角ゴ ProN W3&quot;, &quot;Hiragino Kaku Gothic ProN&quot;, メイリオ, Meiryo, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">An e-mail will be sent to that address containing a link to reset your password.</span></span><span class="auto-style37"><br class="auto-style35" />
                <br class="auto-style35" />
                </span>
               <span class="auto-style35" style="font-family: Avenir, &quot;Avenir Next&quot;, &quot;Helvetica Neue&quot;, Helvetica, Arial, &quot;ヒラギノ角ゴ ProN W3&quot;, &quot;Hiragino Kaku Gothic ProN&quot;, メイリオ, Meiryo, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">(only works on Gmail, if you use other email types please contact an admin)</span><br class="auto-style26" style="box-sizing: border-box; color: rgb(60, 60, 60); font-family: Avenir, &quot;Avenir Next&quot;, &quot;Helvetica Neue&quot;, Helvetica, Arial, &quot;ヒラギノ角ゴ ProN W3&quot;, &quot;Hiragino Kaku Gothic ProN&quot;, メイリオ, Meiryo, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;" /></td>
        </tr>
        <tr>
            <td class="auto-style32">
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style33">
                            <br />
                            <asp:TextBox ID="EmailTxt" runat="server" Height="36px" Width="280px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style31">
                <asp:Button CssClass="btn" ID="SubmitBtn" runat="server" Text="Send Email" OnClick="SubmitBtn_Click" />
                <br />
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Apologies, we only support Gmail Email Address" ControlToValidate="EmailTxt" ValidationExpression="\w+\@gmail.com"></asp:RegularExpressionValidator>
                <br />
                <asp:Label ID="ErorLbl" runat="server"></asp:Label>
            &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>

