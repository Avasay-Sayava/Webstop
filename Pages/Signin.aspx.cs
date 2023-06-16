using System;

namespace Webstop.Pages
{
  public partial class Signin : System.Web.UI.Page
  {
    readonly SQL.Connection conn = new SQL.Connection();

    /// <summary>
    /// Event handler for the page load event.
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
      // Hide the exist and error elements initially
      exist.Visible = false;
      error.Visible = false;

      // Check if the form was submitted
      if (Request.Form["in-submit"] != null)
      {
        string tableName = "Users";
        string[] columns = { "*" };
        string condition = $"[Email]='{Request.Form["in-email"]}' AND [Password]='{Request.Form["in-password"]}'";

        // Check if the user exists in the database
        if (conn.DoesExist(SQL.Syntax.Select(tableName, columns, condition)))
        {
          columns = new string[] { "Id" };

          // Set the session variable for signed-in user
          Session["Signin"] = (int)conn.ExecuteDataTable(SQL.Syntax.Select(tableName, columns, condition)).Rows[0][0];
          
          columns = new string[] { "Last" };

          conn.DoQuery(SQL.Syntax.Update(tableName, columns, new object[] {DateTime.Now}, $"[id]='{Session["Signin"] as int? ?? 0}'"));

          // Redirect to the appropriate page based on user type
          Response.Redirect(conn.DoesExist($"select * from Users where Id='{Session["Signin"]}' and Type=255") ? "Admin/Users" : "Home");
        }
        else
        {
          // Show the error message
          error.Visible = true;
        }
      }
    }
  }
}
