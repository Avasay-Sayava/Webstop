using System.Web.Routing;

namespace Webstop
{
  public class RouteConfig
  {
    /// <summary>
    /// Registers the routes for the application.
    /// </summary>
    /// <param name="routes">The collection of routes to register.</param>
    public static void RegisterRoutes(RouteCollection routes)
    {
      // Map the default route to the "~/Pages/.aspx" page
      routes.MapPageRoute("", "", "~/Pages/.aspx");

      // Map the route with a parameter named "page" to the "~/Pages/{page}.aspx" page
      routes.MapPageRoute("", "{page}", "~/Pages/{page}.aspx");

      // Map the route with a parameter named "page" under the "Admin" directory to the "~/Pages/Admin/{page}.aspx" page
      routes.MapPageRoute("", "Admin/{page}", "~/Pages/Admin/{page}.aspx");
    }
  }
}