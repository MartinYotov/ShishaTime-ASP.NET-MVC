using Ninject.Modules;
using Ninject.Web.Common;
using ShishaTime.Data;
using ShishaTime.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShishaTime.Web.App_Start.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IShishaTimeDbContext>().To<ShishaTimeDbContext>().InRequestScope();
            this.Bind(typeof(IEntityFrameworkRepository<>)).To(typeof(EntityFrameworkRepository<>)).InRequestScope();
            this.Bind<IShishaTimeData>().To<ShishaTimeData>().InRequestScope();
        }
    }
}