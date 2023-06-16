<%@ Page Title="Reviews" Language="C#" MasterPageFile="~/Masters/Admin.master" AutoEventWireup="true" CodeBehind="Reviews.aspx.cs" Inherits="Webstop.Pages.Admin.Reviews" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
  <div id="container">
    <div class="sticky">
      <div>Id</div>
      <div>For</div>
      <div>From</div>
      <div>Stars</div>
      <div>Description</div>
      <div>Actions</div>
      <div style="width:0"></div>
    </div>
    <table>
      <%= Table %>
    </table>
  </div>
</asp:Content>
