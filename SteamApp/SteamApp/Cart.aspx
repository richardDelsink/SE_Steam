<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="SteamApp.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
    <asp:GridView ID="gvCartView" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemID" OnRowCommand="gvCartView_RowCommand" OnRowDataBound="gvCartView_RowDataBound">
        <Columns>
            <asp:BoundField DataField="ItemName" HeaderText="Item Name" ReadOnly="True" SortExpression="ItemName" />
            <asp:BoundField DataField="IsCost" HeaderText="Cost" ReadOnly="True" SortExpression="IsCost" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="tbQuanity" runat="server" Width="29px"></asp:TextBox>
                    <asp:LinkButton ID="btnRemove" runat="server" CommandName="Remove">Remove</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TotalCost"  HeaderText="Total Price" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
     </div>
</asp:Content>
