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
      if (Request.Form["add"] != null)
      {
        Database.DoQuery(@"insert into Users (name, email, password, type) values ('" + Request.Form["name"] + @"', '" + Request.Form["email"] + @"', '" + Request.Form["password"] + @"', '" + Request.Form["type"] + @"')");
      }
      else if (Request.Form["update"] != null)
      {
        Database.DoQuery(@"update Users set name='" + Request.Form["name"] + @"', email='" + Request.Form["email"] + @"', password='" + Request.Form["password"] + @"', type='" + Request.Form["type"] + @"' where id='" + Request.Form["id"] + @"'");
      }
      else if (Request.Form["remove"] != null)
      {
        Database.DoQuery(@"delete from Users where id='" + Request.Form["id"] + @"'");
      }
      Users = Database.GetDataTable("select * from Users", "Users");
    }
  }
}