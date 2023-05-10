<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Webstop.Pages.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <style>
    *{
      margin: 0;
      padding: 0;
      box-sizing: border-box;
    }

    body{
      background-color: rgb(63,72,83);
      font-family: sans-serif;
      color: rgb(220,220,220);
      padding: 50px;
      width: 100vw;
      overflow-x: hidden;
    }

    .st_viewport{
      max-height: 500px;
      overflow: auto;
    }

    pre{
      overflow: auto;
    }

    .st_viewport{
      background-color: rgb(62,148,236);
      color: rgb(27,30,36);
      margin: 20px 0;
    }

    .st_table_header{
      position: -webkit-sticky;
      position: sticky;
      top: 0px;
      z-index: 1;
      background-color: rgb(27,30,36);
      color: rgb(220,220,220);
    }
    .st_table_header h2{
      font-weight: 400;
      margin: 0 20px;
      padding: 20px 0 0;
    }
    .st_table_header .st_row{
      color: rgba(220,220,220, .7);
    }
    .st_table_header .st_column{
  
    }

    .st_table{
      display: -webkit-box;
      display: -webkit-flex;
      display: -ms-flexbox;
      display: flex;
      -webkit-box-orient: vertical;
      -webkit-box-direction: normal;
      -webkit-flex-direction: column;
          -ms-flex-direction: column;
              flex-direction: column;
    }

    .st_row{
      display: -webkit-box;
      display: -webkit-flex;
      display: -ms-flexbox;
      display: flex;
      margin: 0;
    }
    .st_table .st_row:nth-child(even){
      background-color: rgba(0,0,0, .1)
    }

    .st_column{
      padding: 10px 20px;
    }
  </style>
</head>
<body>
  <table class="st_warp_table">
    <header class="st_table_header">
      <h2>Users</h2>
      <div class="st_row">
        <div class="st_column">Id</div>
        <div class="st_column">Name</div>
        <div class="st_column">Password</div>
        <div class="st_column">Email</div>
        <div class="st_column">Type</div>
      </div>
    </header>
  </table>
  <%= table %>
</body>
</html>
