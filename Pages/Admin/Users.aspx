<%@ Page Title="Users" Language="C#" MasterPageFile="~/Masters/Admin.master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Webstop.Pages.Users" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
  <input type="button" value="Fix Identity Value" onclick="document.getElementById('FIV').click()"/>
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
    <table>
      <%= Table %>
    </table>
  </div>
</asp:Content>