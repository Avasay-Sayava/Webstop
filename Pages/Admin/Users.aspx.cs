using System;

namespace Webstop.Pages
{
  /// <summary>
  /// The Admin page of the Webstop website.
  /// </summary>
  public partial class Users : System.Web.UI.Page
  {
    readonly SQL.Connection conn = new SQL.Connection();

    /// <summary>
    /// The string representing the users.
    /// </summary>
    public string Table { get; private set; }

    /// <summary>
    /// Event handler for the Page_Load event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The event arguments.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
      // Handle form submissions
      if (Request.Form["add"] != null)
      {
        // Insert a new user into the database
        conn.DoQuery(SQL.Syntax.Insert("Users", new string[] { "Name", "Email", "Password", "Join", "Last", "Type" }, new object[] { Request.Form["name"], Request.Form["email"], Request.Form["password"], DateTime.Parse(Request.Form["join"]), DateTime.Parse(Request.Form["last"]), Request.Form["type"] }));
      }
      else if (Request.Form["apply"] != null)
      {
        // Update an existing user in the database
        conn.DoQuery(SQL.Syntax.Update("Users", new string[] { "Name", "Password", "Email", "Join", "Last", "Type" }, new object[] { Request.Form["name"], Request.Form["password"], Request.Form["email"], DateTime.Parse(Request.Form["join"]), DateTime.Parse(Request.Form["last"]), Request.Form["type"] }, $"Id='{Request.Form["id"]}'"));
      }
      else if (Request.Form["remove"] != null)
      {
        // Delete a user from the database
        conn.DoQuery(SQL.Syntax.Delete("Users", $"Id='{Request.Form["id"]}'"));
      }

      // Retrieve the users from the database and generate the table form
      Table = conn.ExecuteTableForm("select * from Users", "Users", new string[] { "readonly", "", "", "", "type='datetime'", "type='datetime'", "type='number' min='0' max='255'" });
    }
  }
}
