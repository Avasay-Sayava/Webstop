using System;

namespace Webstop.Pages
{
  public partial class Error : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      string code = Request.QueryString["code"];
      Response.Write("<p>" + code +"</p>");
      Response.Write("<p>" + Session["Error"] + "</p>");
      
    }
  }
}