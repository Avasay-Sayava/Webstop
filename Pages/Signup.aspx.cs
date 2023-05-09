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
      if (Request.Form["up-submit"] != null)
      {
        if (Request.Form["up-email"] == null || !Database.IsExist("select * from Users where Email='" + Request.Form["up-email"] + "'"))
        {

        }
      }
    }
  }
}