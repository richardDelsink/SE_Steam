﻿<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="SteamApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
</asp:Content>
