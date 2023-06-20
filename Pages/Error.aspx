<%@ Page Language="C#" MasterPageFile="~/Masters/Default.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Webstop.Pages.Error" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
  <link href="wwwroot/css/error.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ContentPlaceHolderID="content" runat="server">
  <p><%= code %></p>
  <p><%= msg %></p>
  <p><a onclick="history.back();"><u>↪ Retrun to <%= last %></u></a></p>
</asp:Content>