using ShishaTime.Models;
using ShishaTime.Services.Contracts;
using ShishaTime.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShishaTime.Web.Controllers
{
    public class HomeController : Controller
    {
        private IMappingService mappingService;
        private IBarsService barsService;
        public HomeController(IMappingService mappingService,
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

        public ActionResult Index()
        {
            var bars = this.barsService.GetTopRated(5);
            var barsShort = this.mappingService.Map<IEnumerable<ShishaBar>, IEnumerable<BarShortViewModel>>(bars);
            return View(barsShort);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to ShishaTime!";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}