using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Webstop
{
  public class MvcApplication : HttpApplication
  {
    protected void Page_Start()
    {
      if (Request.Url.AbsolutePath.StartsWith("/Pages/"))
        HttpContext.Current.Response.Redirect("/Error?code=404");
    }
    
    protected void Page_End(object sender, EventArgs e)
    {
      // Code that runs on page end
    }

    protected void Page_Error(object sender, EventArgs e)
    {
/*      Exception lastError = Server.GetLastError();
      HttpContext.Current.Response.Redirect("/Error?code=404");*/
    }

    protected void Application_Start(object sender, EventArgs e)
    {
      AreaRegistration.RegisterAllAreas();
      RouteConfig.RegisterRoutes(RouteTable.Routes);
    }

    protected void Application_End(object sender, EventArgs e)
    {
      // Code that runs on application shutdown
    }

    protected void Application_Error(object sender, EventArgs e)
    {
/*      Exception lastError = Server.GetLastError();
      HttpContext.Current.Response.Redirect("/Error?code=403");*/
    }

    protected void Session_Start(object sender, EventArgs e)
    {
      // Code that runs when a new session is started
    }

    protected void Session_End(object sender, EventArgs e)
    {
      // Code that runs when a session ends. 
      // Note: The Session_End event is raised only when the sessionstate mode
      // is set to InProc in the Web.config file. If session mode is set to StateServer 
      // or SQLServer, the event is not raised.
    }
  }
}