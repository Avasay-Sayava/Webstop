<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Masters/Default.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Webstop.Pages.Users" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
  <!-- Include custom CSS for admin page -->
  <link rel="stylesheet" href="/wwwroot/css/admin.css" />
</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
  <p><%= Application["Visitors"] %> visitors so far.</p>
  <div id="container">
    <div class="sticky">
      <div>Id</div>
      <div>Name</div>
      <div>Email</div>
      <div>Password</div>
      <div>Join</div>
      <div>Last</div>
      <div>Type</div>
      <div>Actions</div>
    </div>
    <%= Table %>
  </div>
  <!-- Include admin.js script -->
  <script src="/Scripts/Admin.js"></script>
</asp:Content>