<%@ Page Title="Sites" Language="C#" MasterPageFile="~/Masters/Default.Master" AutoEventWireup="true" CodeBehind="Sites.aspx.cs" Inherits="Webstop.Pages.Sites" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
  <link href="/wwwroot/css/sites.css" rel="stylesheet" />
</asp:Content>
<asp:Content ContentPlaceHolderID="Content" runat="server">
  <input type="search" id="search" name="search" placeholder="Search a url" />
  <p>Website not found? <a onclick="document.getElementById('dialog').showModal()">Add it!</a></p>
  <%= Results %>
  <form method="post" action="/Sites">
    <dialog id="dialog">
      <i class="fa fa-times" onclick="document.getElementById('dialog').close()"></i>
      <label for="dialog_input">Invalid Address</label>
      <input type="text" id="dialog_input" name="dialog_input" placeholder="Address" />
      <input type="submit" id="dialog_submit" name="dialog_submit" value="Add" />
    </dialog>
  </form>
  <script src="/Scripts/Sites.js"></script>
</asp:Content>

