using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Webstop
{
  /// <summary>
  /// Represents the main application class for the MVC application.
  /// </summary>
  public class MvcApplication : HttpApplication
  {
    /// <summary>
    /// Handles the event raised when an unhandled exception occurs on a page.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
    protected void Page_Error(object sender, EventArgs e)
    {
      Exception lastEx = Server.GetLastError().InnerException ?? Server.GetLastError();
      HttpContext.Current.Response.Redirect($"Error?code={(lastEx as HttpException).ErrorCode}&msg={lastEx.Message}");
    }

    /// <summary>
    /// Handles the application start event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
    protected void Application_Start(object sender, EventArgs e)
    {
      AreaRegistration.RegisterAllAreas();
      RouteConfig.RegisterRoutes(RouteTable.Routes);
    }

    /// <summary>
    /// Handles the application end event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
    protected void Application_End(object sender, EventArgs e)
    {
      // Code that runs on application shutdown
    }

    /// <summary>
    /// Handles the application error event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
    protected void Application_Error(object sender, EventArgs e)
    {
      Exception lastEx = Server.GetLastError().InnerException ?? Server.GetLastError();
      HttpContext.Current.Response.Redirect($"Error?code={(lastEx as HttpException).ErrorCode}&msg={lastEx.Message}");
    }

    /// <summary>
    /// Handles the session start event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
    protected void Session_Start(object sender, EventArgs e)
    {
      // Code that runs when a new session is started
    }

    /// <summary>
    /// Handles the session end event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
    protected void Session_End(object sender, EventArgs e)
    {
      // Code that runs when a session ends. 
      // Note: The Session_End event is raised only when the sessionstate mode
      // is set to InProc in the Web.config file. If session mode is set to StateServer 
      // or SQLServer, the event is not raised.
    }
  }
}
