using System;

namespace Webstop.Pages
{
  /// <summary>
  /// The Admin page of the Webstop website.
  /// </summary>
  public partial class Admin : System.Web.UI.Page
  {
    /// <summary>
    /// The string representing the users.
    /// </summary>
    public string Users;

    /// <summary>
    /// Event handler for the Page_Load event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The event arguments.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
      // Check if the user is authorized as an admin
      if (!SQL.Manager.DoesExist($"select * from Users where Id='{Session["Signin"]}' and Type=255"))
      {
        // Redirect to the Error page with code 404
        Response.Redirect("Error?code=404");
      }

      // Handle form submissions
      if (Request.Form["add"] != null)
      {
        // Insert a new user into the database
        SQL.Manager.DoQuery($@"insert into Users (name, email, password, type) values ('{Request.Form["name"]}', '{Request.Form["email"]}', '{Request.Form["password"]}', '{Request.Form["type"]}')");
      }
      else if (Request.Form["apply"] != null)
      {
        // Update an existing user in the database
        SQL.Manager.DoQuery($@"update Users set name='{Request.Form["name"]}', email='{Request.Form["email"]}', password='{Request.Form["password"]}', type='{Request.Form["type"]}' where id='{Request.Form["id"]}'");
      }
      else if (Request.Form["remove"] != null)
      {
        // Delete a user from the database
        SQL.Manager.DoQuery($"delete from Users where id='{Request.Form["id"]}'");
      }

      // Retrieve the users from the database and generate the table form
      Users = SQL.Manager.ExecuteTableForm("select * from Users", "Admin", new string[] { "readonly", "", "", "", "type='number' min='0' max='255'" });
    }
  }
}
