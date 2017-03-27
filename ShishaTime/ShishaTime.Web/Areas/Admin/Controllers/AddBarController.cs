using AutoMapper;
using ShishaTime.Common.Attributes;
using ShishaTime.Common.Providers.Contracts;
using ShishaTime.Models;
using ShishaTime.Services.Contracts;
using ShishaTime.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShishaTime.Web.Areas.Admin.Controllers
{
    [MyAuthorize(Roles = "Admin")]
    public class AddBarController : Controller
    {
        private IMappingService mappingService;
        private IRegionsService regionsService;
        private IBarsService barsService;
        private ICacheProvider cacheProvider;
        private IServerProvider serverProvider;
        private IPathProvider pathProvider;

        public AddBarController(IMappingService mappingService, 
                                IRegionsService regionsService,
                                IBarsService barsService,
                                ICacheProvider cacheProvider,
                                IServerProvider serverProvider,
                                IPathProvider pathProvider)
        {
            if (mappingService == null)
            {
                throw new ArgumentNullException("Mapping service cannot be null.");
            }

            if (regionsService == null)
            {
                throw new ArgumentNullException("Regions service cannot be null.");
            }

            if (barsService == null)
            {
                throw new ArgumentNullException("Bars service cannot be null.");
            }

            if (cacheProvider == null)
            {
                throw new ArgumentNullException("Cache provider cannot be null.");
            }

            if (serverProvider == null)
            {
                throw new ArgumentNullException("Server provider cannot be null.");
            }

            if (pathProvider == null)
            {
                throw new ArgumentNullException("Path provider cannot be null.");
            }

            this.mappingService = mappingService;
            this.regionsService = regionsService;
            this.barsService = barsService;
            this.cacheProvider = cacheProvider;
            this.serverProvider = serverProvider;
            this.pathProvider = pathProvider;
        }

        public ActionResult Index()
        {
            var regions = this.GetRegions();
            ViewBag.Regions = new SelectList(regions, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AddBarViewModel barModel)
        {

            if (!ModelState.IsValid)
            {
                var regions = this.GetRegions();
                ViewBag.Regions = new SelectList(regions, "Id", "Name");
                return View(barModel);
            }
           
            if (!IsImageFile(barModel.Image))
            {
                ModelState.AddModelError("Image", "The uploaded file should be an image");
                var regions = this.GetRegions();
                ViewBag.Regions = new SelectList(regions, "Id", "Name");
                return View(barModel);
            }
          
            var bar = mappingService.Map<AddBarViewModel, ShishaBar>(barModel);

            if (barModel.Image != null)
            {
                var path = this.serverProvider.MapPath(bar.ImagePathBig);
                barModel.Image.SaveAs(path);
            }

            this.barsService.AddBar(bar);

            return this.Redirect("/allbars");           
        }

        private IEnumerable<Region> GetRegions()
        {
            var regions = this.cacheProvider.GetItem("regions");

            if(regions == null)
            {
                regions = this.regionsService.GetAllRegions();
                this.cacheProvider.SaveInCache("regions", regions, 60);
            }

            return (IEnumerable<Region>)regions;
        }

        private bool IsImageFile(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return true;
            }

            var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".bmp" };
            var fileExtension = this.pathProvider.GetExtension(file.FileName).ToLower();

            if(allowedExtensions.Contains(fileExtension))
            {
                return true;
            }

            return false;
        }       
    }
}