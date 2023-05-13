using System;

namespace Webstop.Pages
{
  /// <summary>
  /// Represents the signout page of the website.
  /// </summary>
  public partial class Signout : System.Web.UI.Page
  {
    /// <summary>
    /// Event handler for the page load event.
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
      // Clear the session variable for signed-in user
      Session["Signin"] = 0;

      // Redirect to the home page
      Response.Redirect("Home");
    }
  }
}
