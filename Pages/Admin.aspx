<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Webstop.Pages.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <style>
    * {
      margin: 0;
      padding: 0;
      border-spacing: 0;
      box-sizing: border-box;
    }

    body {
      background-color: white;
      font-family: sans-serif;
      padding: 5vh;
      width: 100vw;
      overflow: hidden;
    }

    #container {
      border-radius: 10px;
      position: absolute;
      top: 5vh;
      left: 50%;
      transform: translate(-50%, 0);
      width: fit-content;
      max-height: 90vh;
      overflow: scroll;
    }

    tr {
      background-color: rgba(0,0,0, .2);
    }
    
    tr:nth-child(even) {
      background-color: rgba(0,0,0, .1);
    }

    td {
      padding: 10px 20px;
    }

    .sticky {
        background: linear-gradient(to right, #2b5dff, #2bb8ff);
      display: flex;
      flex-direction: row;
      top: 0;
      position: sticky;
    }

    .sticky div {
      padding: 10px 20px;
      width: 140px;
    }
    
    .sticky div:nth-child(5) {
      padding: 10px 20px;
      width: 190px;
    }

    input[type=text] {
      border: none;
      outline: none;
      background-color: transparent;
      padding: 0;
      margin: 0;
      width: 100px;
    }

    input[type=submit] {
      padding: 5px;
      margin: 5px;
    }
  </style>
</head>
<body>
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
</body>
</html>
