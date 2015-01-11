<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SteamApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionString %>" ProviderName="<%$ ConnectionStrings:MyConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;DB21_ITEM&quot; ORDER BY &quot;ITEMNAME&quot;"></asp:SqlDataSource>

  <div class="jumbotron">
    <asp:DataList ID="dlItems" runat="server" DataKeyField="ITEMID" DataSourceID="SqlDataSource1" OnItemCommand="dlItems_ItemCommand">
        <ItemTemplate>
            ITEMID:
            <asp:Label ID="ITEMIDLabel" runat="server" Text='<%# Eval("ITEMID") %>' />
            <br />
            ITEMNAME:
            <asp:Label ID="ITEMNAMELabel" runat="server" Text='<%# Eval("ITEMNAME") %>' />
            <br />
            ITEMINFO:
            <asp:Label ID="ITEMINFOLabel" runat="server" Text='<%# Eval("ITEMINFO") %>' />
            <br />
            PRODUCT:
            <asp:Label ID="PRODUCTLabel" runat="server" Text='<%# Eval("PRODUCT") %>' />
            <br />
            ISCOST:
            <asp:Label ID="ISCOSTLabel" runat="server" Text='<%# Eval("ISCOST") %>' />
            <br />
<br />
            <asp:Button ID="btnAddCart" runat="server" OnClick="btnAddCart_Click" Text="Add To Cart" />
            
        </ItemTemplate>
    </asp:DataList>


    <asp:Button ID="btnViewCart" runat="server" Text="Cart" OnClick="btnViewCart_Click" />
  
       </div>

</asp:Content>
