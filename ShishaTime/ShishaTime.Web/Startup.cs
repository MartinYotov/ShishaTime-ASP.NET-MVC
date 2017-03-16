using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShishaTime.Web.Startup))]
namespace ShishaTime.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
