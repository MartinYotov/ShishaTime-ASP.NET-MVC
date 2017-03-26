using Moq;
using NUnit.Framework;
using ShishaTime.Common.Providers.Contracts;
using ShishaTime.Models;
using ShishaTime.Services.Contracts;
using ShishaTime.Web.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace ShishaTime.Web.Tests.Controllers.AdminArea.AddBarControllerTests
{
    [TestFixture]
    public class IndexGet_Should
    {
        [Test]
        public void CallCacheProviderGetItemWithCorrectParameter_AndNotCallRegionsServiceGetAllRegions_WhenProviderReturnsItems()
        {
            //Arrange
            var regions = new List<Region>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedRegionsService = new Mock<IRegionsService>();
            mockedRegionsService.Setup(x => x.GetAllRegions()).Verifiable();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedCacheProvider = new Mock<ICacheProvider>();
            mockedCacheProvider.Setup(x => x.GetItem(It.IsAny<string>())).Returns(regions); 
            var mockedServerProvider = new Mock<IServerProvider>();
            var mockedPathProvider = new Mock<IPathProvider>();

            var controller = new AddBarController(mockedMappingService.Object,
                                                  mockedRegionsService.Object,
                                                  mockedBarsService.Object,
                                                  mockedCacheProvider.Object,
                                                  mockedServerProvider.Object,
                                                  mockedPathProvider.Object);

            //Act
            controller.Index();

            //Assert
            mockedCacheProvider.Verify(x => x.GetItem("regions"), Times.Once());
            mockedRegionsService.Verify(x => x.GetAllRegions(), Times.Never());
        }

        [Test]
        public void CallCacheProviderGetItemWithCorrectParameter_AndCallRegionsServiceGetAllRegions_WhenProviderReturnsNull()
        {
            //Arrange
            var regions = new List<Region>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedRegionsService = new Mock<IRegionsService>();
            mockedRegionsService.Setup(x => x.GetAllRegions()).Returns(regions);
            var mockedBarsService = new Mock<IBarsService>();
            var mockedCacheProvider = new Mock<ICacheProvider>();
            mockedCacheProvider.Setup(x => x.GetItem(It.IsAny<string>())).Returns(null);
            var mockedServerProvider = new Mock<IServerProvider>();
            var mockedPathProvider = new Mock<IPathProvider>();

            var controller = new AddBarController(mockedMappingService.Object,
                                                  mockedRegionsService.Object,
                                                  mockedBarsService.Object,
                                                  mockedCacheProvider.Object,
                                                  mockedServerProvider.Object,
                                                  mockedPathProvider.Object);

            //Act
            controller.Index();

            //Assert
            mockedCacheProvider.Verify(x => x.GetItem("regions"), Times.Once());
            mockedRegionsService.Verify(x => x.GetAllRegions(), Times.Once());
        }

        [Test]
        public void CallCacheProviderSaveInCache_WithCorrectParameters_WhenCacheProviderProviderReturnsNull()
        {
            //Arrange
            var regions = new List<Region>();
            var mockedMappingService = new Mock<IMappingService>();
            var mockedRegionsService = new Mock<IRegionsService>();
            mockedRegionsService.Setup(x => x.GetAllRegions()).Returns(regions);
            var mockedBarsService = new Mock<IBarsService>();
            var mockedCacheProvider = new Mock<ICacheProvider>();
            mockedCacheProvider.Setup(x => x.GetItem(It.IsAny<string>())).Returns(null);
            mockedCacheProvider.Setup(x => x.SaveInCache(It.IsAny<string>(), 
                                                         It.IsAny<object>(), 
                                                         60))
                                                         .Verifiable();
            var mockedServerProvider = new Mock<IServerProvider>();
            var mockedPathProvider = new Mock<IPathProvider>();

            var controller = new AddBarController(mockedMappingService.Object,
                                                  mockedRegionsService.Object,
                                                  mockedBarsService.Object,
                                                  mockedCacheProvider.Object,
                                                  mockedServerProvider.Object,
                                                  mockedPathProvider.Object);

            //Act
            controller.Index();

            //Assert
            mockedCacheProvider.Verify(x => x.SaveInCache("regions", regions, 60), Times.Once());
        }

        [Test]
        public void ReturnDefaultView()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedRegionsService = new Mock<IRegionsService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedCacheProvider = new Mock<ICacheProvider>();
            var mockedServerProvider = new Mock<IServerProvider>();
            var mockedPathProvider = new Mock<IPathProvider>();

            var controller = new AddBarController(mockedMappingService.Object,
                                                  mockedRegionsService.Object,
                                                  mockedBarsService.Object,
                                                  mockedCacheProvider.Object,
                                                  mockedServerProvider.Object,
                                                  mockedPathProvider.Object);
            //Act & Assert
            controller.WithCallTo(x => x.Index())
                .ShouldRenderDefaultView();
        }
    }
}
