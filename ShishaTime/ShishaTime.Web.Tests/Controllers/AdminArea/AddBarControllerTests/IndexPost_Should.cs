using Moq;
using NUnit.Framework;
using ShishaTime.Common.Providers.Contracts;
using ShishaTime.Models;
using ShishaTime.Services.Contracts;
using ShishaTime.Web.Areas.Admin.Controllers;
using ShishaTime.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TestStack.FluentMVCTesting;

namespace ShishaTime.Web.Tests.Controllers.AdminArea.AddBarControllerTests
{
    [TestFixture]
    public class IndexPost_Should
    {
        [Test]
        public void ReturnDefaultView_WithModelError_WhenModelStateIsInvalid()
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
            var barModel = new AddBarViewModel();
            controller.ModelState.AddModelError("Error", "Error message");

            //Act & Assert
            controller.WithCallTo(x => x.Index(barModel))
                .ShouldRenderDefaultView()
                .WithModel<AddBarViewModel>()
                .AndModelError("Error")
                .ThatEquals("Error message");
        }

        [Test]
        public void ReturnDefaultView_WithModelErrorForImage_WhenUploadedFileIsNotImage()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedRegionsService = new Mock<IRegionsService>();
            var mockedBarsService = new Mock<IBarsService>();
            var mockedCacheProvider = new Mock<ICacheProvider>();
            var mockedServerProvider = new Mock<IServerProvider>();
            var mockedPathProvider = new Mock<IPathProvider>();
            mockedPathProvider.Setup(x => x.GetExtension(It.IsAny<string>())).Returns(".exe");

            var controller = new AddBarController(mockedMappingService.Object,
                                                  mockedRegionsService.Object,
                                                  mockedBarsService.Object,
                                                  mockedCacheProvider.Object,
                                                  mockedServerProvider.Object,
                                                  mockedPathProvider.Object);
            var mockedFile = new Mock<HttpPostedFileBase>();
            mockedFile.Setup(x => x.ContentType).Returns(".exe");
            var barModel = new AddBarViewModel() { Image = mockedFile.Object };

            //Act & Assert
            controller.WithCallTo(x => x.Index(barModel))
                .ShouldRenderDefaultView()
                .WithModel<AddBarViewModel>()
                .AndModelError("Image")
                .ThatEquals("The uploaded file should be an image");
        }

        [Test]
        public void RedirectToHome_WhenModelStateIsValid_AndUploadedFileIsNull()
        {
            //Arrange
            var bar = new ShishaBar() { ImagePathBig = "Some/Path" };
            var mockedMappingService = new Mock<IMappingService>();
            mockedMappingService.Setup(x => x.Map<AddBarViewModel, ShishaBar>(It.IsAny<AddBarViewModel>())).Returns(bar);
            var mockedRegionsService = new Mock<IRegionsService>();
            var mockedBarsService = new Mock<IBarsService>();
            mockedBarsService.Setup(x => x.AddBar(It.IsAny<ShishaBar>())).Verifiable();
            var mockedCacheProvider = new Mock<ICacheProvider>();
            var mockedServerProvider = new Mock<IServerProvider>();
            mockedServerProvider.Setup(x => x.MapPath(It.IsAny<string>())).Returns("path");
            var mockedPathProvider = new Mock<IPathProvider>();

            var controller = new AddBarController(mockedMappingService.Object,
                                                  mockedRegionsService.Object,
                                                  mockedBarsService.Object,
                                                  mockedCacheProvider.Object,
                                                  mockedServerProvider.Object,
                                                  mockedPathProvider.Object);
            var barModel = new AddBarViewModel() {};

            //Act & Assert
            controller.WithCallTo(x => x.Index(barModel))
                .ShouldRedirectTo("/allbars");
        }

        [Test]
        public void RedirectToHome_WhenModelStateIsValid_AndUploadedFileIsImage()
        {
            //Arrange
            var bar = new ShishaBar() { ImagePathBig = "Some/Path" };
            var mockedMappingService = new Mock<IMappingService>();
            mockedMappingService.Setup(x => x.Map<AddBarViewModel, ShishaBar>(It.IsAny<AddBarViewModel>())).Returns(bar);
            var mockedRegionsService = new Mock<IRegionsService>();
            var mockedBarsService = new Mock<IBarsService>();
            mockedBarsService.Setup(x => x.AddBar(It.IsAny<ShishaBar>())).Verifiable();
            var mockedCacheProvider = new Mock<ICacheProvider>();
            var mockedServerProvider = new Mock<IServerProvider>();
            mockedServerProvider.Setup(x => x.MapPath(It.IsAny<string>())).Returns("path");
            var mockedPathProvider = new Mock<IPathProvider>();
            mockedPathProvider.Setup(x => x.GetExtension(It.IsAny<string>())).Returns(".png");

            var controller = new AddBarController(mockedMappingService.Object,
                                                  mockedRegionsService.Object,
                                                  mockedBarsService.Object,
                                                  mockedCacheProvider.Object,
                                                  mockedServerProvider.Object,
                                                  mockedPathProvider.Object);
            var mockedFile = new Mock<HttpPostedFileBase>();
            mockedFile.Setup(x => x.ContentType).Returns(".png");
            var barModel = new AddBarViewModel() { Image = mockedFile.Object };

            //Act & Assert
            controller.WithCallTo(x => x.Index(barModel))
                .ShouldRedirectTo("/allbars");
        }
    }
}
