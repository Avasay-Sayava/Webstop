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
          Response.Redirect("Home");
        }
        else
        {
          error.Visible = true;
        }
      }
    }
  }
}