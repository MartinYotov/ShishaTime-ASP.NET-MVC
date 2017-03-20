using AutoMapper;
using ShishaTime.Models;
using ShishaTime.Services.Contracts;
using ShishaTime.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShishaTime.Web.Controllers
{
    public class AddBarController : Controller
    {
        private IMappingService mappingService;
        private IRegionsService regionsService;
        private IBarsService barsService;

        public AddBarController(IMappingService mappingService, 
                                IRegionsService regionsService,
                                IBarsService barsService)
        {
            this.mappingService = mappingService;
            this.regionsService = regionsService;
            this.barsService = barsService;
        }

        public ActionResult Index()
        {
            return this.RenderView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AddBarViewModel barModel)
        {

            if (!ModelState.IsValid)
            {
                return this.RenderView();
            }
           
            if (!IsImageFile(barModel.Image))
            {
                ModelState.AddModelError("Image", "The uploaded file should be an image");
                return this.RenderView();
            }
          
            var bar = Mapper.Map<AddBarViewModel, ShishaBar>(barModel);

            var path = this.Server.MapPath(bar.ImagePathBig);
            barModel.Image.SaveAs(path);

            this.barsService.AddBar(bar);

            return this.Redirect("/home");           
        }

        private bool IsImageFile(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return true;
            }

            var allowedExtensions = new[] { ".png", ".jpg", ".jpeg", ".bmp" };
            var fileExtension = Path.GetExtension(file.FileName).ToLower();

            if(allowedExtensions.Contains(fileExtension))
            {
                return true;
            }

            return false;
        }

        private ActionResult RenderView()
        {
            var regions = this.regionsService.GetAllRegions();
            ViewBag.Regions = new SelectList(regions, "Id", "Name");
            return View();
        }        
    }
}