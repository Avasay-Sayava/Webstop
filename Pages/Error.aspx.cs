using System;
using System.Net;
using System.Linq;
using System.Text.RegularExpressions;

namespace Webstop.Pages
{
  public partial class Error : System.Web.UI.Page
  {
    /// <summary>
    /// The HTTP status code.
    /// </summary>
    public string code;

    /// <summary>
    /// The corresponding HTTP status message.
    /// </summary>
    public string msg;

    /// <summary>
    /// Last page
    /// </summary>
    public string last;

    /// <summary>
    /// Event handler for the Page_Load event.
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
      // Get the code from the query string or default to "400" if invalid
      code = Regex.IsMatch(Request.QueryString["code"], @"^\d{3}$") ? Request.QueryString["code"] : "400";

      // Get the corresponding HTTP status message based on the code
      msg = HttpStatusMessage.Get(code);

      // Update the last page
      last = string.Join(" - ", Request.UrlReferrer.AbsolutePath.Substring(1).Split('/').Reverse());

      // Set the title
      Page.Title = $"Error {code} - {msg}";
    }
  }
}
