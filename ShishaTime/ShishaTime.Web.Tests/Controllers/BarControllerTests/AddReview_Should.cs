using Moq;
using NUnit.Framework;
using ShishaTime.Common.Providers.Contracts;
using ShishaTime.Models;
using ShishaTime.Services.Contracts;
using ShishaTime.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace ShishaTime.Web.Tests.Controllers.BarControllerTests
{
    [TestFixture]
    public class AddReview_Should
    {
        [Test]
        public void CallReviewsService_AddReviewMethod_WithCorrectId()
        {
            //Arrange
            int barId = 1;
            string title = "title";
            string text = "text";
            var reviews = new List<Review>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedReviewsService = new Mock<IReviewsService>();
            mockedReviewsService.Setup(x => x.AddReview(It.IsAny<int>(), It.IsAny<Review>()));
            mockedReviewsService.Setup(x => x.GetBarReviews(It.IsAny<int>())).Returns(reviews);
            var mockedRatingService = new Mock<IRatingService>();
            var mockedUserProvider = new Mock<IUserProvider>();
            var controller = new BarController(mockedMappingService.Object,
                                               mockedBarsService.Object,
                                               mockedReviewsService.Object,
                                               mockedRatingService.Object,
                                               mockedUserProvider.Object);

            //Act
            controller.AddReview(barId, title, text);

            //Assert
            mockedReviewsService.Verify(x => x.AddReview(barId, It.IsAny<Review>()), Times.Once());
        }

        [Test]
        public void CallReviewsService_GetBarReviews_WithCorrectId()
        {
            //Arrange
            int barId = 1;
            string title = "title";
            string text = "text";
            var reviews = new List<Review>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedReviewsService = new Mock<IReviewsService>();
            mockedReviewsService.Setup(x => x.AddReview(It.IsAny<int>(), It.IsAny<Review>()));
            mockedReviewsService.Setup(x => x.GetBarReviews(It.IsAny<int>())).Returns(reviews);
            var mockedRatingService = new Mock<IRatingService>();
            var mockedUserProvider = new Mock<IUserProvider>();
            var controller = new BarController(mockedMappingService.Object,
                                               mockedBarsService.Object,
                                               mockedReviewsService.Object,
                                               mockedRatingService.Object,
                                               mockedUserProvider.Object);

            //Act
            controller.AddReview(barId, title, text);

            //Assert
            mockedReviewsService.Verify(x => x.GetBarReviews(barId), Times.Once());
        }

        [Test]
        public void ReturnsPartialView_WithIEnumerableOfReview()
        {
            //Arrange
            int barId = 1;
            string title = "title";
            string text = "text";
            var reviews = new List<Review>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedReviewsService = new Mock<IReviewsService>();
            mockedReviewsService.Setup(x => x.AddReview(It.IsAny<int>(), It.IsAny<Review>()));
            mockedReviewsService.Setup(x => x.GetBarReviews(It.IsAny<int>())).Returns(reviews);
            var mockedRatingService = new Mock<IRatingService>();
            var mockedUserProvider = new Mock<IUserProvider>();
            var controller = new BarController(mockedMappingService.Object,
                                               mockedBarsService.Object,
                                               mockedReviewsService.Object,
                                               mockedRatingService.Object,
                                               mockedUserProvider.Object);

            //Act & Assert
            controller.WithCallTo(c => c.AddReview(barId, title, text))
                .ShouldRenderPartialView("_ReviewsPartial")
                .WithModel<IEnumerable<Review>>();            
        }

        [Test]
        public void ReturnsPartialView_WithIEnumerableOfReview_WithTheCorrectList()
        {
            //Arrange
            int barId = 1;
            string title = "title";
            string text = "text";
            var reviews = new List<Review>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedReviewsService = new Mock<IReviewsService>();
            mockedReviewsService.Setup(x => x.AddReview(It.IsAny<int>(), It.IsAny<Review>()));
            mockedReviewsService.Setup(x => x.GetBarReviews(It.IsAny<int>())).Returns(reviews);
            var mockedRatingService = new Mock<IRatingService>();
            var mockedUserProvider = new Mock<IUserProvider>();
            var controller = new BarController(mockedMappingService.Object,
                                               mockedBarsService.Object,
                                               mockedReviewsService.Object,
                                               mockedRatingService.Object,
                                               mockedUserProvider.Object);

            //Act & Assert
            controller.WithCallTo(c => c.AddReview(barId, title, text))
                .ShouldRenderPartialView("_ReviewsPartial")
                .WithModel<IEnumerable<Review>>(reviews);
        }
    }
}