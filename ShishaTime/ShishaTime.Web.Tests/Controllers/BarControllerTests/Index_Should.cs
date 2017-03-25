using Moq;
using NUnit.Framework;
using ShishaTime.Common.Providers.Contracts;
using ShishaTime.Models;
using ShishaTime.Services.Contracts;
using ShishaTime.Web.Controllers;
using ShishaTime.Web.Models;
using TestStack.FluentMVCTesting;

namespace ShishaTime.Web.Tests.Controllers.BarControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void CallBarsService_GetByIdMethod_With1WhenIdIsNotPassed()
        {
            //Arrange
            var bar = new ShishaBar();
            var barViewModel = new BarViewModel();
            string userId = "1";
            int rating = 5;
            var mockedMappingService = new Mock<IMappingService>();
            mockedMappingService.Setup(x => x.Map<ShishaBar, BarViewModel>(bar)).Returns(barViewModel);
            var mockedBarsService = new Mock<IBarsService>();
            mockedBarsService.Setup(x => x.GetBarById(It.IsAny<int>())).Returns(bar);
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedRatingService = new Mock<IRatingService>();
            mockedRatingService.Setup(x => x.GetUserRating(It.IsAny<int>(), userId)).Returns(rating);
            var mockedUserProvider = new Mock<IUserProvider>();
            mockedUserProvider.Setup(x => x.GetUserId()).Returns(userId);
            var controller = new BarController(mockedMappingService.Object,
                                               mockedBarsService.Object,
                                               mockedReviewsService.Object,
                                               mockedRatingService.Object,
                                               mockedUserProvider.Object);

            //Act
            controller.Index();

            //Assert
            mockedBarsService.Verify(x => x.GetBarById(1), Times.Once());
        }

        [Test]
        public void CallBarsService_GetByIdMethod_WithCorrectIdWhenItIsPassed()
        {
            //Arrange
            var bar = new ShishaBar();
            var barViewModel = new BarViewModel();
            string userId = "1";
            int rating = 5;
            var mockedMappingService = new Mock<IMappingService>();
            mockedMappingService.Setup(x => x.Map<ShishaBar, BarViewModel>(bar)).Returns(barViewModel);
            var mockedBarsService = new Mock<IBarsService>();
            mockedBarsService.Setup(x => x.GetBarById(It.IsAny<int>())).Returns(bar);
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedRatingService = new Mock<IRatingService>();
            mockedRatingService.Setup(x => x.GetUserRating(It.IsAny<int>(), userId)).Returns(rating);
            var mockedUserProvider = new Mock<IUserProvider>();
            mockedUserProvider.Setup(x => x.GetUserId()).Returns(userId);
            var controller = new BarController(mockedMappingService.Object,
                                               mockedBarsService.Object,
                                               mockedReviewsService.Object,
                                               mockedRatingService.Object,
                                               mockedUserProvider.Object);

            //Act
            controller.Index(2);

            //Assert
            mockedBarsService.Verify(x => x.GetBarById(2), Times.Once());
        }

        [Test]
        public void RedirectToPage404_WhenThereIsNotBarWithPassedId()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedBarsService = new Mock<IBarsService>();
            mockedBarsService.Setup(x => x.GetBarById(It.IsAny<int>())).Returns((ShishaBar)null);
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedUserProvider = new Mock<IUserProvider>();
            var controller = new BarController(mockedMappingService.Object,
                                               mockedBarsService.Object,
                                               mockedReviewsService.Object,
                                               mockedRatingService.Object,
                                               mockedUserProvider.Object);

            //Act
            controller.Index(1);

            //Assert
            controller.WithCallTo(c => c.Index(1))
                .ShouldRedirectTo("errorPages/page404");
        }

        [Test]
        public void CallRatingService_GetUserRating_WithCorrectParameters()
        {
            //Arrange
            var bar = new ShishaBar();
            var barViewModel = new BarViewModel();
            string userId = "1";
            int rating = 5;
            int barId = 2;
            var mockedMappingService = new Mock<IMappingService>();
            mockedMappingService.Setup(x => x.Map<ShishaBar, BarViewModel>(bar)).Returns(barViewModel);
            var mockedBarsService = new Mock<IBarsService>();
            mockedBarsService.Setup(x => x.GetBarById(It.IsAny<int>())).Returns(bar);
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedRatingService = new Mock<IRatingService>();
            mockedRatingService.Setup(x => x.GetUserRating(It.IsAny<int>(), userId)).Returns(rating);
            var mockedUserProvider = new Mock<IUserProvider>();
            mockedUserProvider.Setup(x => x.GetUserId()).Returns(userId);
            var controller = new BarController(mockedMappingService.Object,
                                               mockedBarsService.Object,
                                               mockedReviewsService.Object,
                                               mockedRatingService.Object,
                                               mockedUserProvider.Object);

            //Act
            controller.Index(barId);

            //Assert
            mockedRatingService.Verify(x => x.GetUserRating(barId, userId), Times.Once());
        }

        [Test]
        public void ReturnDefaultView_WithBarViewModel()
        {
            //Arrange
            var bar = new ShishaBar();
            var barViewModel = new BarViewModel();
            string userId = "1";
            int rating = 5;
            int barId = 2;
            var mockedMappingService = new Mock<IMappingService>();
            mockedMappingService.Setup(x => x.Map<ShishaBar, BarViewModel>(bar)).Returns(barViewModel);
            var mockedBarsService = new Mock<IBarsService>();
            mockedBarsService.Setup(x => x.GetBarById(It.IsAny<int>())).Returns(bar);
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedRatingService = new Mock<IRatingService>();
            mockedRatingService.Setup(x => x.GetUserRating(It.IsAny<int>(), userId)).Returns(rating);
            var mockedUserProvider = new Mock<IUserProvider>();
            mockedUserProvider.Setup(x => x.GetUserId()).Returns(userId);
            var controller = new BarController(mockedMappingService.Object,
                                               mockedBarsService.Object,
                                               mockedReviewsService.Object,
                                               mockedRatingService.Object,
                                               mockedUserProvider.Object);

            //Act
            controller.Index(barId);

            //Assert
            controller.WithCallTo(c => c.Index(2))
                .ShouldRenderDefaultView()
                .WithModel<BarViewModel>();
        }

        [Test]
        public void ReturnDefaultView_WithBarViewModel_WithCorrectlySetCurrentUserRating()
        {
            //Arrange
            var bar = new ShishaBar();
            var barViewModel = new BarViewModel();
            string userId = "1";
            int rating = 5;
            int barId = 2;
            var mockedMappingService = new Mock<IMappingService>();
            mockedMappingService.Setup(x => x.Map<ShishaBar, BarViewModel>(bar)).Returns(barViewModel);
            var mockedBarsService = new Mock<IBarsService>();
            mockedBarsService.Setup(x => x.GetBarById(It.IsAny<int>())).Returns(bar);
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedRatingService = new Mock<IRatingService>();
            mockedRatingService.Setup(x => x.GetUserRating(It.IsAny<int>(), userId)).Returns(rating);
            var mockedUserProvider = new Mock<IUserProvider>();
            mockedUserProvider.Setup(x => x.GetUserId()).Returns(userId);
            var controller = new BarController(mockedMappingService.Object,
                                               mockedBarsService.Object,
                                               mockedReviewsService.Object,
                                               mockedRatingService.Object,
                                               mockedUserProvider.Object);

            //Act
            controller.Index(barId);

            //Assert
            controller.WithCallTo(c => c.Index(2))
                .ShouldRenderDefaultView()
                .WithModel<BarViewModel>(ViewModel =>
                {
                    Assert.AreEqual(rating, ViewModel.CurrentUserRating);
                });
        }
    }
}
