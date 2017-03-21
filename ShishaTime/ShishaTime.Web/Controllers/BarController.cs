using ShishaTime.Models;
using ShishaTime.Web.Models;
using ShishaTime.Services.Contracts;
using System;
using System.Web.Mvc;

namespace ShishaTime.Web.Controllers
{
    public class BarController : Controller
    {
        private IMappingService mappingService;
        private IBarsService barsService;

        public BarController(IMappingService mappingService,
                             IBarsService barsService)
        {
            if (mappingService == null)
            {
                throw new ArgumentNullException("Mapping service cannot be null.");
            }

            if (barsService == null)
            {
                throw new ArgumentNullException("Bars service cannot be null.");
            }

            this.mappingService = mappingService;
            this.barsService = barsService;
        }
        public ActionResult Index(int id = 1)
        {
            var bar = this.barsService.GetBarById(id);

            if(bar == null)
            {
                return this.Redirect("errorPages/page404");
            }

            var barModel = mappingService.Map<ShishaBar, BarViewModel>(bar);

            return View(barModel);
        }
    }
}