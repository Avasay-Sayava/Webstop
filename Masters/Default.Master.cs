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
      // If Signin session variable is null or 0, display "Sign In" button, otherwise display "Sign Out" button
      SignBtn = $@"
      <button onclick=""location.pathname='/Sign{((Session["Signin"] == null || (int)Session["Signin"] == 0) ? "in" : "out")}'"">
        Sign {((Session["Signin"] == null || (int)Session["Signin"] == 0) ? "In" : "Out")}
      </button>";

      // Generate the Admin button HTML markup based on the user's type
      // If the user's type is 255, display "Admin" button, otherwise hide the button
      AdminBtn = $"{SQL.Manager.ExecuteQuery($"select Type from Users where Id='{Session["Signin"] ?? 0}'")[0, 0]}".Equals("255")
        ? $@"<button onclick=""location.pathname='/Admin'"">Admin</button>"
        : "";
    }
  }
}
