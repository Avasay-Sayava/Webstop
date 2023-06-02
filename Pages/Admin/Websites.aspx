<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Masters/Default.Master" AutoEventWireup="true" CodeBehind="Websites.aspx.cs" Inherits="Webstop.Pages.Admin.Websites" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
  <!-- Include custom CSS for admin page -->
  <link rel="stylesheet" href="/wwwroot/css/admin.css" />
</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
  <p><%= Application["Visitors"] %> visitors so far.</p>
  <div id="container">
    <div class="sticky">
      <div>Id</div>
      <div>Address</div>
      <div>Security</div>
      <div>Actions</div>
      <div style="width:0"></div>
    </div>
    <%= Table %>
  </div>
  <!-- Include admin.js script -->
  <script src="/Scripts/Admin.js"></script>
</asp:Content>
