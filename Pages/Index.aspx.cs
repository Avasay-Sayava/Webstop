using System;

namespace Webstop.Pages
{
  /// <summary>
  /// The Index page of the Webstop website.
  /// </summary>
  public partial class Index : System.Web.UI.Page
  {
    /// <summary>
    /// Event handler for the Page_Load event.
    /// </summary>
    /// <param name="sender">The object that raised the event.</param>
    /// <param name="e">The event arguments.</param>
    protected void Page_Load(object sender, EventArgs e)
    {
      // Redirect the user to the Home page
      Response.Redirect("Home");
    }
  }
}