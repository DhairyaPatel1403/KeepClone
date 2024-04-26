<%@ Page Title="View Note" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewNote.aspx.cs" Inherits="KeepCloneClient.ViewNote" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <div>
        <asp:Label ID="lblNoteName" runat="server" Text="Note Name:"></asp:Label>
        <asp:TextBox ID="txtNoteName" runat="server"></asp:TextBox>
        <asp:Button ID="btnAddNote" runat="server" Text="Add Note" OnClick="btnAddNote_Click" />
    </div>
    <div>
        <h2>Notes for Diary </h2>
        <asp:Label ID="lblDiaryId" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblNotes" runat="server" Text=""></asp:Label>
    </div>


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" DataKeyNames="Id">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Note ID" />
        <asp:BoundField DataField="Name" HeaderText="Note Name" />
        <asp:BoundField DataField="Notecontent" HeaderText="Note content Name" />
        <asp:TemplateField HeaderText="View Notes">
            <ItemTemplate>
                <asp:Button runat="server" Text="View Notes" CommandName="Noteit" CommandArgument='<%# Eval("Id") %>' />
            </ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="Delete Note">
            <ItemTemplate>
                <asp:Button runat="server" Text="Delete Note" CommandName="DeleteNote" CommandArgument='<%# Eval("Id") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>


