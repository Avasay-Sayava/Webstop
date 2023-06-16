<%@ Page Title="Websites" Language="C#" MasterPageFile="~/Masters/Admin.master" AutoEventWireup="true" CodeBehind="Websites.aspx.cs" Inherits="Webstop.Pages.Admin.Websites" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
  <div id="container">
    <div class="sticky">
      <div>Id</div>
      <div>Address</div>
      <div>Security</div>
      <div>Actions</div>
      <div style="width:0"></div>
    </div>
    <table>
      <%= Table %>
    </table>
  </div>
</asp:Content>
