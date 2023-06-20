using System;

namespace Webstop.Masters
{
  public partial class Admin : System.Web.UI.MasterPage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      // Append " - Admin" to the page title
      Page.Title += " - Admin";
    }
  }
}