<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KeepCloneClient.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="lblDiaryName" runat="server" Text="Diary Name:"></asp:Label>
        <asp:TextBox ID="txtDiaryName" runat="server"></asp:TextBox>
        <asp:Button ID="btnAddDiary" runat="server" Text="Add Diary" OnClick="btnAddDiary_Click" />
    </div>

    <br />

    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>

    <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Diary ID" />
            <asp:BoundField DataField="Diary_name" HeaderText="Diary Name" />
            <asp:TemplateField HeaderText="View Notes">
                <ItemTemplate>
                    <asp:Button runat="server" Text="View Notes" CommandName="Noteit" CommandArgument='<%# Eval("Id") %>' />
                </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Delete Diary">
            <ItemTemplate>
                <asp:Button runat="server" Text="Delete Diary" CommandName="DeleteDiary" CommandArgument='<%# Eval("Id") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
