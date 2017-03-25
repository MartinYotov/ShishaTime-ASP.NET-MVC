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
    public class Rate_Should
    {
        [Test]
        public void CallRatingService_AddRatingMethod()
        {
            //Arrange
            int barId = 1;
            int value = 4;
            double rating = 3.6d;
            var reviews = new List<Review>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedRatingService = new Mock<IRatingService>();
            mockedRatingService.Setup(x => x.AddRating(It.IsAny<Rating>())).Verifiable();
            mockedRatingService.Setup(x => x.UpdateBarRating(It.IsAny<int>())).Returns(rating);
            var mockedUserProvider = new Mock<IUserProvider>();
            var controller = new BarController(mockedMappingService.Object,
                                               mockedBarsService.Object,
                                               mockedReviewsService.Object,
                                               mockedRatingService.Object,
                                               mockedUserProvider.Object);

            //Act
            controller.Rate(barId, value);

            //Assert
            mockedRatingService.Verify(x => x.AddRating(It.IsAny<Rating>()), Times.Once());
        }

        [Test]
        public void CallRatingService_UpdateBarRatingMethod_WithCorrectId()
        {
            //Arrange
            int barId = 1;
            int value = 4;
            double rating = 3.6d;
            var reviews = new List<Review>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedRatingService = new Mock<IRatingService>();
            mockedRatingService.Setup(x => x.AddRating(It.IsAny<Rating>())).Verifiable();
            mockedRatingService.Setup(x => x.UpdateBarRating(It.IsAny<int>())).Returns(rating);
            var mockedUserProvider = new Mock<IUserProvider>();
            var controller = new BarController(mockedMappingService.Object,
                                               mockedBarsService.Object,
                                               mockedReviewsService.Object,
                                               mockedRatingService.Object,
                                               mockedUserProvider.Object);

            //Act
            controller.Rate(barId, value);

            //Assert
            mockedRatingService.Verify(x => x.UpdateBarRating(barId), Times.Once());
        }

        [Test]
        public void ReturnPartialView_WithTheCorrectRating()
        {
            //Arrange
            int barId = 1;
            int value = 4;
            double rating = 3.6d;
            var reviews = new List<Review>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedRatingService = new Mock<IRatingService>();
            mockedRatingService.Setup(x => x.AddRating(It.IsAny<Rating>())).Verifiable();
            mockedRatingService.Setup(x => x.UpdateBarRating(It.IsAny<int>())).Returns(rating);
            var mockedUserProvider = new Mock<IUserProvider>();
            var controller = new BarController(mockedMappingService.Object,
                                               mockedBarsService.Object,
                                               mockedReviewsService.Object,
                                               mockedRatingService.Object,
                                               mockedUserProvider.Object);

            //Act & Assert
            controller.WithCallTo(c => c.Rate(barId, value))
                .ShouldRenderPartialView("_RatingPartial");                
        }
    }
}
