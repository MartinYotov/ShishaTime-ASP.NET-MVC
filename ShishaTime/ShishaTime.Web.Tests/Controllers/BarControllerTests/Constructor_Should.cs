using Moq;
using NUnit.Framework;
using ShishaTime.Common.Providers.Contracts;
using ShishaTime.Services.Contracts;
using ShishaTime.Web.Controllers;
using System;

namespace ShishaTime.Web.Tests.Controllers.BarControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnAnInstance_ParametersAreNotNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            //Act
            var controller = new BarController(mockedMappingService.Object,
                                               mockedBarsService.Object,
                                               mockedReviewsService.Object,
                                               mockedRatingService.Object,
                                               mockedUserProvider.Object);

            //Assert
            Assert.IsInstanceOf<BarController>(controller);
        }

        [Test]
        public void ThrowArgumentNullException_WhenMappingServiceIsNull()
        {
            //Arrange
            var mockedBarsService = new Mock<IBarsService>();
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new BarController(null,
                                                                         mockedBarsService.Object,
                                                                         mockedReviewsService.Object,
                                                                         mockedRatingService.Object,
                                                                         mockedUserProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenMappingServiceIsNull()
        {
            //Arrange
            var mockedBarsService = new Mock<IBarsService>();
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            //Act & Assert
            Assert.That(() => new BarController(null,
                                                mockedBarsService.Object,
                                                mockedReviewsService.Object,
                                                mockedRatingService.Object,
                                                mockedUserProvider.Object),
               Throws.ArgumentNullException.With.Message.Contains("Mapping service cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenBarsServiceIsNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new BarController(mockedMappingService.Object,
                                                                         null,
                                                                         mockedReviewsService.Object,
                                                                         mockedRatingService.Object,
                                                                         mockedUserProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenBarsServiceIsNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            //Act & Assert
            Assert.That(() => new BarController(mockedMappingService.Object,
                                                null,
                                                mockedReviewsService.Object,
                                                mockedRatingService.Object,
                                                mockedUserProvider.Object),
               Throws.ArgumentNullException.With.Message.Contains("Bars service cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenReviewsServiceIsNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockeBarsService = new Mock<IBarsService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new BarController(mockedMappingService.Object,
                                                                         mockeBarsService.Object,
                                                                         null,
                                                                         mockedRatingService.Object,
                                                                         mockedUserProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenReviewsServiceIsNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedRatingService = new Mock<IRatingService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            //Act & Assert
            Assert.That(() => new BarController(mockedMappingService.Object,
                                                mockedBarsService.Object,
                                                null,
                                                mockedRatingService.Object,
                                                mockedUserProvider.Object),
               Throws.ArgumentNullException.With.Message.Contains("Reviews service cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenRatingServiceIsNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new BarController(mockedMappingService.Object,
                                                                         mockedBarsService.Object,
                                                                         mockedReviewsService.Object,
                                                                         null,
                                                                         mockedUserProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenRatingServiceIsNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            //Act & Assert
            Assert.That(() => new BarController(mockedMappingService.Object,
                                                mockedBarsService.Object,
                                                mockedReviewsService.Object,
                                                null,
                                                mockedUserProvider.Object),
               Throws.ArgumentNullException.With.Message.Contains("Rating service cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserProviderIsNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedRatingService = new Mock<IRatingService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new BarController(mockedMappingService.Object,
                                                                         mockedBarsService.Object,
                                                                         mockedReviewsService.Object,
                                                                         mockedRatingService.Object,
                                                                         null));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenUserProviderIsNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedReviewsService = new Mock<IReviewsService>();
            var mockedRatingService = new Mock<IRatingService>();

            //Act & Assert
            Assert.That(() => new BarController(mockedMappingService.Object,
                                                mockedBarsService.Object,
                                                mockedReviewsService.Object,
                                                mockedRatingService.Object,
                                                null),
               Throws.ArgumentNullException.With.Message.Contains("User provider cannot be null."));
        }
    }
}