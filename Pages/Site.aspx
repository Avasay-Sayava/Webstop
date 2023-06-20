<%@ Page Title="Site" Language="C#" MasterPageFile="~/Masters/Default.Master" AutoEventWireup="true" CodeBehind="Site.aspx.cs" Inherits="Webstop.Pages.Site" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
  <link href="/wwwroot/css/site.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
  <%= Content %>
  <dialog id="dialog">
    <i class="fa fa-times" onclick="document.getElementById('dialog').close()"></i>
    <panel>Reviews Requested</panel>
    <input type="submit" onclick="document.getElementById('dialog').close()" value="OK" />
  </dialog>
  <script src="/Scripts/Site.js"></script>
</asp:Content>
