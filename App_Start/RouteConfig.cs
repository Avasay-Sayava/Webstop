using System.Web.Mvc;
using System.Web.Routing;

namespace Webstop
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
      routes.MapPageRoute("", "", "~/Pages/Index.aspx");
      routes.MapPageRoute("", "{page}", "~/Pages/{page}.aspx");
    }
  }
}