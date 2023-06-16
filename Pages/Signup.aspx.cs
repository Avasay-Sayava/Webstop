using System;

namespace Webstop.Pages
{
  public partial class Signup : System.Web.UI.Page
  {
    readonly SQL.Connection conn = new SQL.Connection();

    /// <summary>
    /// Event handler for the page load event.
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
      // Hide error and exist elements on page load
      error.Visible = false;
      exist.Visible = false;

      // Check if the signup form has been submitted
      if (Request.Form["up-submit"] != null)
      {
        // Check if the user with the provided email already exists in the database
        if (!conn.DoesExist($"select * from Users where Email='{Request.Form["up-email"]}'"))
        {
          // Add a new user to the database
          conn.DoQuery(SQL.Syntax.Insert("Users", new string[] {"Name", "Password", "Email", "Join", "Last" }, new object[] { Request.Form["up-name"], Request.Form["up-password"], Request.Form["up-email"], DateTime.Now, DateTime.Now }));

          // Set the session variable for signed-in user
          Session["Signin"] = conn.ExecuteDataTable($"select * from Users where email='{Request.Form["up-email"]}'").Rows[0][0];
          
          Response.Redirect("Home");
        }
        else
        {
          // Display a message indicating that the user already exists
          exist.Visible = true;
        }
      }
    }
  }
}