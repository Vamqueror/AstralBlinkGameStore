<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CheckoutComplete.aspx.cs" Inherits="CheckoutComplete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style26 {
            text-align: center;
        }
        .auto-style30 {
            text-align: center;
            font-size: 40pt;
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p class="auto-style26">
        &nbsp;</p>
    <p class="auto-style30">
        Order Complete!</p>
    <p class="auto-style26">
        &nbsp;</p>
    <p class="auto-style26">
        Thank You For Your Purchase! You Have Been Charged For
        <asp:Label ID="PriceLbl" runat="server"></asp:Label>
        <asp:Label ID="ShekelLbl" runat="server" Text="₪" Width="20px"></asp:Label>
&nbsp;<span style="color: rgb(34, 34, 34); font-family: sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;"><asp:Label ID="ConvertedLbl" runat="server" BackColor="Black" ForeColor="#7E52DE"></asp:Label>
    </p>
    </span>
    <p class="auto-style26">
        &nbsp;</p>
    <p class="auto-style26">
        &nbsp;</p>
    <p class="auto-style26">
        &nbsp;</p>
</asp:Content>

