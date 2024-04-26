<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KeepCloneClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-container">
        <h2>Sign In</h2>
        <div class="form-container">
            <asp:TextBox ID="txtUsername" runat="server" placeholder="Username"></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <asp:Button ID="btnSignIn" runat="server" Text="Sign In" OnClick="btnSignIn_Click" CssClass="btn-signin" />
        </div>
        <div class="error-message">
            <asp:Label ID="lblErrorMessage" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <div class="login-container">
        <h2>Login</h2>
        <div class="form-container">
            <asp:TextBox ID="txtLoginUsername" runat="server" placeholder="Username"></asp:TextBox>
            <asp:TextBox ID="txtLoginPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn-login" />
        </div>
        <div class="error-message">
            <asp:Label ID="lblLoginErrorMessage" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
