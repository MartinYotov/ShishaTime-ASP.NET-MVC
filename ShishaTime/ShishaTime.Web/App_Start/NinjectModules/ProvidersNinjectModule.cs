using Ninject.Modules;
using Ninject.Web.Common;
using ShishaTime.Common.Providers;
using ShishaTime.Common.Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShishaTime.Web.App_Start.NinjectModules
{
    public class ProvidersNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUserProvider>().To<UserProvider>().InRequestScope();
            this.Bind<ICacheProvider>().To<CacheProvider>().InRequestScope();
            this.Bind<IServerProvider>().To<ServerProvider>().InRequestScope();
            this.Bind<IPathProvider>().To<PathProvider>().InRequestScope();
        }
    }
}