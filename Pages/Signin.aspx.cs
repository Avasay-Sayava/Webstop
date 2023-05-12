using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webstop.Pages
{
  public partial class Signin : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      exist.Visible = false;
      error.Visible = false;
      if (Request.Form["in-submit"] != null)
      {
        if (Database.IsExist("select * from Users where Email='" + Request.Form["in-email"] + "' and Password='" + Request.Form["in-password"] + "'"))
        {
          Session["signin"] = (int) Database.Get("select Id from Users where Email='" + Request.Form["in-email"] + "' and Password='" + Request.Form["in-password"] + "'")[0,0];
          Response.Redirect(Database.IsExist("select * from Users where Id='" + Session["signin"] + "' and Type=255") ? "Admin" : "Home");
        }
        else
        {
          error.Visible = true;
        }
      }
    }
  }
}