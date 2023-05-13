using System;

namespace Webstop.Pages
{
  /// <summary>
  /// Represents the signup page of the website.
  /// </summary>
  public partial class Signup : System.Web.UI.Page
  {
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
        if (!SQL.Manager.DoesExist($"select * from Users where Email='{Request.Form["up-email"]}'"))
        {
          // Add a new user to the database
          SQL.Manager.DoQuery($"insert into Users (Name, Email, Password) values ('{Request.Form["up-name"]}', '{Request.Form["up-email"]}', '{Request.Form["up-password"]}')");
          Response.Redirect("Home");

          // Set the session variable for signed-in user
          Session["Signin"] = SQL.Manager.ExecuteQuery($"select * from Users where email='{Request.Form["up-email"]}'")[0, 0];
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