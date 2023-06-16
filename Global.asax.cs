using System;
using System.Web;
using System.Web.Routing;
using System.Web.SessionState;

namespace Webstop
{
  public class MvcApplication : HttpApplication
  {
    /// <summary>
    /// Handles the application start event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
    protected void Application_Start(object sender, EventArgs e)
    {
      // Register routes defined in RouteConfig class
      RouteConfig.RegisterRoutes(RouteTable.Routes);

      // Set initial value for the "Visitors" application variable
      Application["Visitors"] = 0;
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
      // Implemented in Web.config
    }

    /// <summary>
    /// Handles the event raised when an unhandled exception occurs on a page.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
    protected void Page_Error(object sender, EventArgs e)
    {
      // Implemented in Web.config
    }

    /// <summary>
    /// Handles the session start event.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
    protected void Session_Start(object sender, EventArgs e)
    {
      // Lock the application object to ensure thread safety
      Application.Lock();

      // Increment the value of the "Visitors" application variable by 1
      Application["Visitors"] = Convert.ToInt32(Application["Visitors"]) + 1;

      // Unlock the application object
      Application.UnLock();
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