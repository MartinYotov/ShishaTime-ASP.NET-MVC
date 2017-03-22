using ShishaTime.Models;
using ShishaTime.Web.Models;
using ShishaTime.Services.Contracts;
using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Net;

namespace ShishaTime.Web.Controllers
{
    public class BarController : Controller
    {
        private IMappingService mappingService;
        private IBarsService barsService;
        private IReviewsService reviewsService;

        public BarController(IMappingService mappingService,
                             IBarsService barsService,
                             IReviewsService reviewsService)
        {
            if (mappingService == null)
            {
                throw new ArgumentNullException("Mapping service cannot be null.");
            }

            if (barsService == null)
            {
                throw new ArgumentNullException("Bars service cannot be null.");
            }

            if (reviewsService == null)
            {
                throw new ArgumentNullException("Reviews service cannot be null.");
            }

            this.mappingService = mappingService;
            this.barsService = barsService;
            this.reviewsService = reviewsService;
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

        [HttpPost]
        public ActionResult AddReview(int barId, string title, string text)
        {
            ModelState.Clear();

            var review = new Review()
            {
                BarId = barId,
                Title = title,
                Text = text,
                UserId = this.User.Identity.GetUserId()
            };

            this.reviewsService.AddReview(barId, review);

            var reviews = this.reviewsService.GetBarReviews(barId);

            return this.PartialView("_ReviewsPartial", reviews);
        }
    }
}