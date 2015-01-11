<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SteamApp.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>History</h3>
    <asp:GridView ID="Grid1" runat="server" AutoGenerateColumns="False" >
        <Columns>
            <asp:BoundField DataField="ITEMNAME" HeaderText="ITEMNAME" SortExpression="ITEMNAME"></asp:BoundField>
            <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate"></asp:BoundField>
            <asp:BoundField DataField="Price" HeaderText="PRICE" SortExpression="Price"></asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
