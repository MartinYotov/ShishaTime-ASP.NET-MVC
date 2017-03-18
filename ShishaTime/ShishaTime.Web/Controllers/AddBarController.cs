using AutoMapper;
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
    public class AddBarController : Controller
    {
        private IMappingService mappingService;
        private IRegionsService regionsService;

        public AddBarController(IMappingService mappingService, IRegionsService regionsService)
        {
            this.mappingService = mappingService;
            this.regionsService = regionsService;
        }

        public ActionResult Index()
        {
            var regions = this.regionsService.GetAllRegions();
            ViewBag.Regions = new SelectList(regions, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AddBarViewModel barModel)
        {

            if (!ModelState.IsValid)
            {
                var regions = this.regionsService.GetAllRegions();
                ViewBag.Regions = new SelectList(regions, "Id", "Name");
                return View();
            }

            var bar = Mapper.Map<AddBarViewModel, ShishaBar>(barModel);

            //TODO: Save image
            //TODO: barsService.Add(bar);
            return this.Redirect("/home");           
        }
    }
}