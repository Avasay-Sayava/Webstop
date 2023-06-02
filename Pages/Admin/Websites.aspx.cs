using System;

namespace Webstop.Pages.Admin
{
  public partial class Websites : System.Web.UI.Page
  {
    /// <summary>
    /// The string representing the websites.
    /// </summary>
    public string Table { get; private set; }

    /// <summary>
    /// Event handler for the Page_Load event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The event arguments.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
      SQL.Connection conn = new SQL.Connection();

      // Check if the user is authorized as an admin
      if (!conn.DoesExist($"select * from Users where Id='{Session["Signin"]}' and Type=255"))
      {
        // Redirect to the Error page with code 404
        Response.Redirect("/Error?code=404");
      }

      // Handle form submissions
      if (Request.Form["add"] != null)
      {
        // Insert a new website into the database
        conn.DoQuery(SQL.Syntax.Insert("Websites", new string[] { "Address", "Security" }, new object[] { Request.Form["address"], Request.Form["security"] }));
      }
      else if (Request.Form["apply"] != null)
      {
        // Update an existing website in the database
        conn.DoQuery(SQL.Syntax.Update("Websites", new string[] { "Address", "Security" }, new object[] { Request.Form["address"], Request.Form["security"] }, $"Id='{Request.Form["id"]}'"));
      }
      else if (Request.Form["remove"] != null)
      {
        // Delete a website from the database
        conn.DoQuery(SQL.Syntax.Delete("Websites", $"Id='{Request.Form["id"]}'"));
      }

      // Retrieve the websites from the database and generate the table form
      Table = conn.ExecuteTableForm("select * from Websites", "Websites", new string[] { "readonly" });
    }
  }
}