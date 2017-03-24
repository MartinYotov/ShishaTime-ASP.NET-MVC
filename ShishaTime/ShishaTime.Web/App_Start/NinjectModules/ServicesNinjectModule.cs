using Ninject.Modules;
using Ninject.Web.Common;
using ShishaTime.Services;
using ShishaTime.Services.Contracts;

namespace ShishaTime.Web.App_Start.NinjectModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMappingService>().To<MappingService>().InRequestScope();
            this.Bind<IRegionsService>().To<RegionsService>().InRequestScope();
            this.Bind<IBarsService>().To<BarsService>().InRequestScope();
            this.Bind<IReviewsService>().To<ReviewsService>().InRequestScope();
            this.Bind<IRatingService>().To<RatingService>().InRequestScope();
        }
    }
}
    
