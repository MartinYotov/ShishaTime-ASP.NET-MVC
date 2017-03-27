using PagedList;
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
    public class AllBarsController : Controller
    {
        private IMappingService mappingService;
        private IBarsService barsService;

        public AllBarsController(IMappingService mappingService,
                                 IBarsService barsService)
        {
            this.mappingService = mappingService;
            this.barsService = barsService;
        }

        public ActionResult Index(int page = 1, int pageSize = 3)
        {
            if (page < 1)
            {
                page = 1;
            }

            if (pageSize < 1)
            {
                pageSize = 1;
            }

            if (pageSize > 10)
            {
                pageSize = 10;
            }

            int count = 0;
            var bars = this.barsService.GetBarsWithPaging(out count, page, pageSize);
            var barsModel = this.mappingService.Map<IEnumerable<ShishaBar>, IEnumerable<AllBarsViewModel>>(bars);

            var model = new StaticPagedList<AllBarsViewModel>(barsModel, page, pageSize, count);

            return View(model);
        }
    }
}