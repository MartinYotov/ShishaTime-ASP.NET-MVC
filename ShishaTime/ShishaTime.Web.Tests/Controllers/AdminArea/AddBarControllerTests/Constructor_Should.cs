using Moq;
using NUnit.Framework;
using ShishaTime.Common.Providers.Contracts;
using ShishaTime.Services.Contracts;
using ShishaTime.Web.Areas.Admin.Controllers;
using System;

namespace ShishaTime.Web.Tests.Controllers.AdminArea.AddBarControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnAnInstance_ParametersAreNotNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedRegionsService = new Mock<IRegionsService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedCacheProvider = new Mock<ICacheProvider>();
            var mockedServerProvider = new Mock<IServerProvider>();
            var mockedPathProvider = new Mock<IPathProvider>();

            //Act
            var controller = new AddBarController(mockedMappingService.Object,
                                                  mockedRegionsService.Object,
                                                  mockedBarsService.Object,
                                                  mockedCacheProvider.Object,
                                                  mockedServerProvider.Object,
                                                  mockedPathProvider.Object);

            //Assert
            Assert.IsInstanceOf<AddBarController>(controller);
        }

        [Test]
        public void ThrowArgumentNullException_WhenMappingServiceIsNull()
        {
            //Arrange
            var mockedRegionsService = new Mock<IRegionsService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedCacheProvider = new Mock<ICacheProvider>();
            var mockedServerProvider = new Mock<IServerProvider>();
            var mockedPathProvider = new Mock<IPathProvider>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddBarController(null,
                                                                            mockedRegionsService.Object,
                                                                            mockedBarsService.Object,
                                                                            mockedCacheProvider.Object,
                                                                            mockedServerProvider.Object,
                                                                            mockedPathProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenMappingServiceIsNull()
        {
            //Arrange
            var mockedRegionsService = new Mock<IRegionsService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedCacheProvider = new Mock<ICacheProvider>();
            var mockedServerProvider = new Mock<IServerProvider>();
            var mockedPathProvider = new Mock<IPathProvider>();

            //Act & Assert
            Assert.That(() => new AddBarController(null,
                                                   mockedRegionsService.Object,
                                                   mockedBarsService.Object,
                                                   mockedCacheProvider.Object,
                                                   mockedServerProvider.Object,
                                                   mockedPathProvider.Object),
               Throws.ArgumentNullException.With.Message.Contains("Mapping service cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenRegionsServiceIsNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedCacheProvider = new Mock<ICacheProvider>();
            var mockedServerProvider = new Mock<IServerProvider>();
            var mockedPathProvider = new Mock<IPathProvider>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddBarController(mockedMappingService.Object,
                                                                            null,
                                                                            mockedBarsService.Object,
                                                                            mockedCacheProvider.Object,
                                                                            mockedServerProvider.Object,
                                                                            mockedPathProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenRegionsServiceIsNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedCacheProvider = new Mock<ICacheProvider>();
            var mockedServerProvider = new Mock<IServerProvider>();
            var mockedPathProvider = new Mock<IPathProvider>();

            //Act & Assert
            Assert.That(() => new AddBarController(mockedMappingService.Object,
                                                   null,
                                                   mockedBarsService.Object,
                                                   mockedCacheProvider.Object,
                                                   mockedServerProvider.Object,
                                                   mockedPathProvider.Object),
               Throws.ArgumentNullException.With.Message.Contains("Regions service cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenBarsServiceIsNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedRegionsService = new Mock<IRegionsService>();
            var mockedCacheProvider = new Mock<ICacheProvider>();
            var mockedServerProvider = new Mock<IServerProvider>();
            var mockedPathProvider = new Mock<IPathProvider>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddBarController(mockedMappingService.Object,
                                                                            mockedRegionsService.Object,
                                                                            null,
                                                                            mockedCacheProvider.Object,
                                                                            mockedServerProvider.Object,
                                                                            mockedPathProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenBarsServiceIsNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedRegionsService = new Mock<IRegionsService>();
            var mockedCacheProvider = new Mock<ICacheProvider>();
            var mockedServerProvider = new Mock<IServerProvider>();
            var mockedPathProvider = new Mock<IPathProvider>();

            //Act & Assert
            Assert.That(() => new AddBarController(mockedMappingService.Object,
                                                   mockedRegionsService.Object,
                                                   null,
                                                   mockedCacheProvider.Object,
                                                   mockedServerProvider.Object,
                                                   mockedPathProvider.Object),
               Throws.ArgumentNullException.With.Message.Contains("Bars service cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenCacheProviderIsNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedRegionsService = new Mock<IRegionsService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedServerProvider = new Mock<IServerProvider>();
            var mockedPathProvider = new Mock<IPathProvider>();

            //Act & Assert
            Assert.That(() => new AddBarController(mockedMappingService.Object,
                                                   mockedRegionsService.Object,
                                                   mockedBarsService.Object,
                                                   null,
                                                   mockedServerProvider.Object,
                                                   mockedPathProvider.Object),
               Throws.ArgumentNullException.With.Message.Contains("Cache provider cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenServerProviderIsNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedRegionsService = new Mock<IRegionsService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedCacheProvider = new Mock<ICacheProvider>();
            var mockedPathProvider = new Mock<IPathProvider>();


            //Act & Assert
            Assert.That(() => new AddBarController(mockedMappingService.Object,
                                                   mockedRegionsService.Object,
                                                   mockedBarsService.Object,
                                                   mockedCacheProvider.Object,
                                                   null,
                                                   mockedPathProvider.Object),
               Throws.ArgumentNullException.With.Message.Contains("Server provider cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenPathProviderIsNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedRegionsService = new Mock<IRegionsService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedCacheProvider = new Mock<ICacheProvider>();
            var mockedServerProvider = new Mock<IServerProvider>();

            //Act & Assert
            Assert.That(() => new AddBarController(mockedMappingService.Object,
                                                   mockedRegionsService.Object,
                                                   mockedBarsService.Object,
                                                   mockedCacheProvider.Object,
                                                   mockedServerProvider.Object,
                                                   null),
               Throws.ArgumentNullException.With.Message.Contains("Path provider cannot be null."));
        }
    }
}