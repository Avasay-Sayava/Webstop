<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Masters/Default.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Webstop.Pages.Profile" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
  <link href="/wwwroot/css/profile.css" rel="stylesheet" />
</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
  <div id="container">
    <h1>Update Profile</h1>
    <%= ProfileForm %>
  </div>
  <script src="/Scripts/Profile.js"></script>
</asp:Content>