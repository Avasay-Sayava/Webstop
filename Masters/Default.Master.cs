using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease.Css.Ast;

namespace Webstop.Masters
{
  public partial class Default : System.Web.UI.MasterPage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Page.Title += " - Webstop";
      if (Request.Url.AbsolutePath.StartsWith("/Pages/"))
        HttpContext.Current.Response.Redirect("/Error?code=404");
    }
  }
}