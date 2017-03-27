using System.Web.Mvc;
using System.Web.Routing;

namespace ShishaTime.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.LowercaseUrls = true;

            routes.MapRoute(
              name: "Rate",
              url: "bar/rate",
              defaults: new { controller = "Bar", action = "Rate", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "AddReview",
              url: "bar/AddReview",
              defaults: new { controller = "Bar", action = "AddReview", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Bar",
               url: "bar/{id}",
               defaults: new { controller = "Bar", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", area = "", id = UrlParameter.Optional }
            );
        }
    }
}
