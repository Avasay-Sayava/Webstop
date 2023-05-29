<%@ Page Title="" Language="C#" MasterPageFile="~/Masters/Default.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Webstop.Pages.Error" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
  <link href="wwwroot/css/error.css" rel="stylesheet" />
</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
  <p><%= code %></p>
  <p><%= msg %></p>
</asp:Content>