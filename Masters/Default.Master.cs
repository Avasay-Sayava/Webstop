using System;
using System.Threading;
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
    protected void Swap(object sender, EventArgs e)
    {
      string theme = Body.Attributes["theme"];
      theme = theme.Equals("light") ? "dark" : "light";
      Body.Attributes.Add("theme", theme);
      Session["theme"] = theme;
      Thread.Sleep(700);
    }

    /// <summary> 
    /// This event handler is called when the master page is being loaded.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">An EventArgs object that contains the event data.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
      // Set the theme to the saved theme or to the default light theme
      Body.Attributes.Add("theme", Session["theme"] as string ?? Body.Attributes["theme"] ?? "light");

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
  {(
    (Session["Signin"] as int? ?? 0) == 0
      ? @"<a href='/Signin'><li>Sign In</li></a>
          <a href='/Signup'><li>Sign Up</li></a>"
      : @"<a onclick='document.getElementById(""d_signout"").showModal()'><li>Sign Out</li></a>
          <a href='/Profile'><li>Profile</li></a>"
  )}
</ul>";

      SQL.Connection conn = new SQL.Connection();
      // Generate the Admin button HTML markup based on the user's type
      // If the user's type is 255, display the Admin buttons, otherwise hide the button
      string tableName = "Users";
      string[] columns = { "*" };
      string condition = $"[Id]='{Session["Signin"] ?? 0}' AND [Type]='255'";
      AdminBtn = conn.DoesExist(SQL.Syntax.Select(tableName, columns, condition))
        ? $@"
          <a href='/Admin/Users'><li>Users</li></a>
          <a href='/Admin/Websites'><li>Websites</li></a>
          <a href='/Admin/Reviews'><li>Reviews</li></a>"
        : "";
    }
  }
}