using System;
using System.Web;

namespace Webstop.Masters
{
  /// <summary>
  /// The default master page for the Webstop application.
  /// </summary>
  public partial class Default : System.Web.UI.MasterPage
  {
    /// <summary>
    /// Gets the HTML markup for the Sign button.
    /// </summary>
    public string SignBtn { get; private set; }

    /// <summary>
    /// Gets the HTML markup for the Admin button.
    /// </summary>
    public string AdminBtn { get; private set; }

    protected void SignOut(object sender, EventArgs e)
    {
      Session["Signin"] = 0;
      Response.Redirect("/");
    }

    /// <summary> 
    /// This event handler is called when the master page is being loaded.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">An EventArgs object that contains the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
      // Check if the requested URL starts with "/Pages/"
      // If true, redirect to the error page with code 404
      if (Request.Url.AbsolutePath.StartsWith("/Pages/"))
      {
        HttpContext.Current.Response.Redirect("/Error?code=404");
      }

      // Append " - Webstop" to the page title
      Page.Title += " - Webstop";

      // Generate the Sign button HTML markup based on the Signin session variable
      // If Signin session variable is null or 0, display "Sign In / Sign Up" switch, otherwise display "Sign Out" button
      SignBtn = $@"
<ul>
  {((Session["Signin"] as int? ?? 0) == 0
    ? @"<li><a href='Signin'>Sign In</a></li>
        <li><a href='Signup'>Sign Up</a></li>"
    : @"<li><a onclick='document.getElementsByTagName(""dialog"")[0].showModal()'>Sign Out</a></li>")}
</ul>";

      SQL.Connection conn = new SQL.Connection();
      // Generate the Admin button HTML markup based on the user's type
      // If the user's type is 255, display "Admin" button, otherwise hide the button
      AdminBtn = $"{conn.ExecuteDataTable($"select Type from Users where Id='{Session["Signin"] ?? 0}'").Rows[0][0]}";
      AdminBtn = $"{conn.ExecuteDataTable(SQL.Syntax.Select("Users", new string[]{"Type"})).Rows[0][0]}".Equals("255")
        ? $@"<a onclick=""location.pathname='/Admin'"">Admin</a>"
        : "";
    }
  }
}