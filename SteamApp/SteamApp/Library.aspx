<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Library.aspx.cs" Inherits="SteamApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Library</h3>
    <asp:GridView ID="Grid" runat="server" AutoGenerateColumns="False" >
        <Columns>
            <asp:BoundField DataField="ITEMNAME" HeaderText="ITEMNAME" SortExpression="ITEMNAME"></asp:BoundField>
            <asp:BoundField DataField="PRODUCT" HeaderText="PRODUCT" SortExpression="PRODUCT"></asp:BoundField>
            <asp:BoundField DataField="ISCOST" HeaderText="PRICE" SortExpression="ISCOST"></asp:BoundField>
        </Columns>
    </asp:GridView>
    
</asp:Content>
