using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webstop.Pages
{
  public partial class Signup : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      error.Visible = false;
      exist.Visible = false;
      if (Request.Form["up-submit"] != null)
      {
        if (!Database.IsExist("select * from Users where Email='" + Request.Form["up-email"] + "'"))
        {
          Database.DoQuery("insert into Users (Name, Email, Password) values ('" + Request.Form["up-name"] + "', '" + Request.Form["up-email"] + "', '" + Request.Form["up-password"] + "')");
          Response.Redirect("Home");
        }
        else
        {
          exist.Visible = true;
        }
      }
    }
  }
}