using Ninject.Modules;
using Ninject.Web.Common;
using ShishaTime.Services;
using ShishaTime.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShishaTime.Web.App_Start.NinjectModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMappingService>().To<MappingService>().InRequestScope();
            this.Bind<IRegionsService>().To<RegionsService>().InRequestScope();
        }
    }
}
    
