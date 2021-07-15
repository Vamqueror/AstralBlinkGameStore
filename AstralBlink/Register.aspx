<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="StyleSheet.css" rel="Stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style25 {
            width: 100%;
            height: 219px;
        }
        .auto-style28 {
            font-size: large;
            margin-bottom: 0px;
        }
        .auto-style32 {
            height: 20px;
            width: 372px;
        }
        .auto-style33 {
            width: 372px;
        }
        .auto-style34 {
            width: 372px;
            height: 35px;
        }
        .auto-style35 {
            height: 35px;
            text-align: left;
        }
        .auto-style36 {
            font-size: xx-large;
            text-align: center;
            height: 36px;
        }
        .auto-style38 {
            text-align: left;
        }
        .auto-style39 {
            height: 20px;
            text-align: left;
        }
        .auto-style29 {
            font-size: large;
            margin-bottom: 2px;
        }
        .auto-style40 {
            font-size: large;
            border-top-style: solid;
            margin-bottom: 0px;
            background-color: #A032D4;
            background-image: url('images/background.jpg');
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style25">
        <tr>
            <td class="auto-style36">Create an Astral Blink Account</td>
        </tr>
        <tr>
            <td class="auto-style20">
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style32">Username</td>
                        <td class="auto-style39">
                            <asp:TextBox ID="UsernameTxt" runat="server" CssClass="auto-style12" Width="220px" OnTextChanged="UsernameTxt_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredUsername" runat="server" ControlToValidate="UsernameTxt" CssClass="auto-style12" ForeColor="#7E52DE">Required Field</asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="TakenLbl" runat="server" Text="This username is already in use" Visible="False"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style34">Password</td>
                        <td class="auto-style35"><asp:TextBox ID="PasswordTxt" runat="server" CssClass="auto-style12" Width="220px" OnTextChanged="PasswordTxt_TextChanged" TextMode="Password" Height="27px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredPassword" runat="server" ControlToValidate="PasswordTxt" CssClass="auto-style12" ForeColor="#7E52DE">Required Field</asp:RequiredFieldValidator>
                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style33">Confirm Password</td>
                        <td class="auto-style38">
                            <asp:TextBox ID="ConfirmTxt" runat="server" CssClass="auto-style12" Width="220px" OnTextChanged="ConfirmTxt_TextChanged" TextMode="Password"></asp:TextBox>
                            <asp:CompareValidator ID="ComparePasswords" runat="server" ControlToCompare="PasswordTxt" ControlToValidate="ConfirmTxt" CssClass="auto-style12" ErrorMessage="Passwords do not match" ForeColor="#7E52DE"></asp:CompareValidator>
                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style33">First Name</td>
                        <td class="auto-style38">
                            <asp:TextBox ID="FirstTxt" runat="server" CssClass="auto-style29" Width="220px" Height="22px" OnTextChanged="FirstTxt_TextChanged"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFirst" runat="server" ControlToValidate="FirstTxt" CssClass="auto-style12" ForeColor="#7E52DE">Required Field</asp:RequiredFieldValidator>
                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style33">Last Name</td>
                        <td class="auto-style38">
                            <asp:TextBox ID="LastTxt" runat="server" CssClass="auto-style12" Width="220px" OnTextChanged="LastTxt_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredLast" runat="server" ControlToValidate="LastTxt" CssClass="auto-style12" ForeColor="#7E52DE">Required Field</asp:RequiredFieldValidator>
                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style33">Email</td>
                        <td class="auto-style38">
                            <asp:TextBox ID="EmailTxt" runat="server" CssClass="auto-style12" Width="220px" OnTextChanged="EmailTxt_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredEmail" runat="server" ControlToValidate="EmailTxt" CssClass="auto-style12" ForeColor="#7E52DE">Required Field</asp:RequiredFieldValidator>
                            &nbsp;<asp:Label ID="ErrorEmail" runat="server" CssClass="auto-style12" ForeColor="#7E52DE"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style34">Country</td>
                        <td class="auto-style35">
                            <asp:DropDownList ID="CountryDDL" runat="server" CssClass="auto-style12" Height="28px" Width="230px" OnSelectedIndexChanged="CountryDDL_SelectedIndexChanged">
                            </asp:DropDownList>
                           <%-- <asp:RequiredFieldValidator ID="RequiredCountry" runat="server" ControlToValidate="CountryDDL" CssClass="auto-style12" InitialValue=0 SetFocusOnError="True">Required Field</asp:RequiredFieldValidator>--%>
                            </td>
                    </tr>
                    <tr>
                        <td class="auto-style33">&nbsp;</td>
                        <td class="auto-style38">
                            <asp:Button ID="SignUpBtn" runat="server" Text="Sign up" OnClick="SignUpBtn_Click" Height="38px" Width="130px" CssClass="btn" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

