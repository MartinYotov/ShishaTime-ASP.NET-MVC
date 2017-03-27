using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShishaTime.Common.Attributes
{
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "ErrorPages", action = "Page401", area = "" }));
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}
