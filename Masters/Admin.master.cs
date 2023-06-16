using System;

namespace Webstop.Masters
{
  public partial class Admin : System.Web.UI.MasterPage
  {
    readonly SQL.Connection conn = new SQL.Connection();

    protected void Page_Load(object sender, EventArgs e)
    {
      // Check if the user is authorized as an admin
      if (!conn.DoesExist($"select * from Users where Id='{Session["Signin"]}' and Type=255"))
      {
        // Redirect to the Error page with code 404
        Response.Redirect("/Error?code=404");
      }

      // Append " - Admin" to the page title
      Page.Title += " - Admin";
    }
  }
}