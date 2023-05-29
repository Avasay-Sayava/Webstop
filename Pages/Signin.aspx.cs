using System;

namespace Webstop.Pages
{
  /// <summary>
  /// Represents the signin page of the website.
  /// </summary>
  public partial class Signin : System.Web.UI.Page
  {
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
        // Check if the user exists in the database
        if (SQL.Manager.DoesExist($"select * from Users where Email='{Request.Form["in-email"]}' and Password='{Request.Form["in-password"]}'"))
        {
          // Set the session variable for signed-in user
          Session["Signin"] = (int)SQL.Manager.ExecuteDataTable($"select Id from Users where Email='{Request.Form["in-email"]}' and Password='{Request.Form["in-password"]}'").Rows[0][0];

          // Redirect to the appropriate page based on user type
          Response.Redirect(SQL.Manager.DoesExist($"select * from Users where Id='{Session["Signin"]}' and Type=255") ? "Admin" : "Home");
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
