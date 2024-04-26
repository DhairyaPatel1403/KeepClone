<%@ Page Title="Write Note" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Write.aspx.cs" Inherits="KeepCloneClient.Write" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Edit Note</h2>
        <asp:Label ID="lblNoteId" runat="server" Text=""></asp:Label><br />
        <asp:TextBox ID="txtNoteContent" runat="server" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox><br />
        <asp:Label ID="lblNoteVal" runat="server" Text=""></asp:Label><br /> <!-- Add this line -->
        <asp:Button ID="btnUpdateNote" runat="server" Text="Update Note" OnClick="btnUpdateNote_Click" />
        <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
