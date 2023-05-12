using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Webstop.Pages
{
  public partial class Admin : System.Web.UI.Page
  {
    public string Users;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Database.IsExist("select * from Users where Id='" + Session["signin"] + "' and Type=255"))
        Response.Redirect("Error?code=404");
      if (Request.Form["Users-add"] != null)
      {

      }
      else if (Request.Form["Users-update"] != null)
      {

      }
      else if (Request.Form["Users-remove"] != null)
      {

      }
      Users = Database.GetDataTable("select * from Users", "Users");
    }
  }
}