<%@ Page Title="Admin" Language="C#" MasterPageFile="~/Masters/Default.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Webstop.Pages.Admin" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
  <!-- Include custom CSS for admin page -->
  <link rel="stylesheet" href="/wwwroot/css/admin.css" />
</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
  <div id="container">
    <div class="sticky">
      <div>Id</div>
      <div>Name</div>
      <div>Email</div>
      <div>Password</div>
      <div>Type</div>
      <div>Actions</div>
    </div>
    <%= Users %>
  </div>
  <!-- Include admin.js script -->
  <script src="Scripts/Admin.js"></script>
</asp:Content>