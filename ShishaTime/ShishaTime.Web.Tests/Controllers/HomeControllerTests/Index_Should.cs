using Moq;
using NUnit.Framework;
using ShishaTime.Models;
using ShishaTime.Services.Contracts;
using ShishaTime.Web.Controllers;
using ShishaTime.Web.Models;
using System.Collections.Generic;
using TestStack.FluentMVCTesting;

namespace ShishaTime.Web.Tests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void CallBarsService_GetTopRatedMethod()
        {
            // Arrange
            var bars = new List<ShishaBar>();
            var barsShortViewModel = new List<BarShortViewModel>();
            var mockedMappingService = new Mock<IMappingService>();
            mockedMappingService.Setup(x => x.Map<IEnumerable<ShishaBar>, IEnumerable<BarShortViewModel>>(bars))
                .Returns(barsShortViewModel);
            var mockedBarsService = new Mock<IBarsService>();
            mockedBarsService.Setup(x => x.GetTopRated(It.IsAny<int>())).Returns(bars);
            HomeController controller = new HomeController(mockedMappingService.Object,
                                                           mockedBarsService.Object);

            //Act
            controller.Index();

            //Assert
            mockedBarsService.Verify(x => x.GetTopRated(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void CallMappingService_MapFromShishaBarsToShishaBarsViewModel_WithTheCorrectBarsList()
        {
            // Arrange
            var bars = new List<ShishaBar>();
            var barsShortViewModel = new List<BarShortViewModel>();
            var mockedMappingService = new Mock<IMappingService>();
            mockedMappingService.Setup(x => x.Map<IEnumerable<ShishaBar>, IEnumerable<BarShortViewModel>>(bars))
                .Returns(barsShortViewModel);
            var mockedBarsService = new Mock<IBarsService>();
            mockedBarsService.Setup(x => x.GetTopRated(It.IsAny<int>())).Returns(bars);
            HomeController controller = new HomeController(mockedMappingService.Object,
                                                           mockedBarsService.Object);

            //Act
            controller.Index();

            //Assert
            mockedMappingService.Verify(x => x.Map<IEnumerable<ShishaBar>, 
                                                   IEnumerable<BarShortViewModel>>(bars), 
                                                   Times.Once());
        }

        [Test]
        public void ReturnDefaultView_WithTheCorrectModel()
        {
            // Arrange
            var bars = new List<ShishaBar>();
            var barsShortViewModel = new List<BarShortViewModel>();
            var mockedMappingService = new Mock<IMappingService>();
            mockedMappingService.Setup(x => x.Map<IEnumerable<ShishaBar>, IEnumerable<BarShortViewModel>>(bars))
                .Returns(barsShortViewModel);
            var mockedBarsService = new Mock<IBarsService>();
            mockedBarsService.Setup(x => x.GetTopRated(It.IsAny<int>())).Returns(bars);
            HomeController controller = new HomeController(mockedMappingService.Object,
                                                           mockedBarsService.Object);

            //Act & Assert
            controller.WithCallTo(c => c.Index())
                .ShouldRenderDefaultView()
                .WithModel<IEnumerable<BarShortViewModel>>(barsShortViewModel);
        }
    }
}
