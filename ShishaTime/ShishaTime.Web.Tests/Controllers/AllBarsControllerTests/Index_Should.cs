using Moq;
using NUnit.Framework;
using PagedList;
using ShishaTime.Models;
using ShishaTime.Services.Contracts;
using ShishaTime.Web.Controllers;
using ShishaTime.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace ShishaTime.Web.Tests.Controllers.AllBarsControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public static void CallBarsService_GetBarsWithPagingMethod_WithCorrectParameters()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var viewModelsList = new List<AllBarsViewModel>();
            mockedMappingService.Setup(x => x.Map<IEnumerable<ShishaBar>,
                                                  IEnumerable<AllBarsViewModel>>
                                                  (It.IsAny<IEnumerable<ShishaBar>>()))
                                                  .Returns(viewModelsList);
                                                             
            var mockedBarsService = new Mock<IBarsService>();
            int count;
            var bars = new List<ShishaBar>();
            mockedBarsService.Setup(x => x.GetBarsWithPaging(out count, 
                                                             It.IsAny<int>(),
                                                             It.IsAny<int>()))
                                                             .Returns(bars);

            var controller = new AllBarsController(mockedMappingService.Object,
                                               mockedBarsService.Object);

            //Act
            controller.Index(-1, -1);

            //Act
            mockedBarsService.Verify(x => x.GetBarsWithPaging(out count, 1, 1), Times.Once());
        }

        [Test]
        public static void CallMappingService_MapMethod_WithCorrectParameter()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var viewModelsList = new List<AllBarsViewModel>();
            mockedMappingService.Setup(x => x.Map<IEnumerable<ShishaBar>,
                                                  IEnumerable<AllBarsViewModel>>
                                                  (It.IsAny<IEnumerable<ShishaBar>>()))
                                                  .Returns(viewModelsList);

            var mockedBarsService = new Mock<IBarsService>();
            int count;
            var bars = new List<ShishaBar>();
            mockedBarsService.Setup(x => x.GetBarsWithPaging(out count,
                                                             It.IsAny<int>(),
                                                             It.IsAny<int>()))
                                                             .Returns(bars);

            var controller = new AllBarsController(mockedMappingService.Object,
                                               mockedBarsService.Object);

            //Act
            controller.Index(-1, 15);

            //Act
            mockedMappingService.Verify(x => x.Map<IEnumerable<ShishaBar>,
                                                  IEnumerable<AllBarsViewModel>>(bars), Times.Once());
        }

        [Test]
        public static void ReturnsDefaultView_WithCorrectModelType()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var viewModelsList = new List<AllBarsViewModel>();
            mockedMappingService.Setup(x => x.Map<IEnumerable<ShishaBar>,
                                                  IEnumerable<AllBarsViewModel>>
                                                  (It.IsAny<IEnumerable<ShishaBar>>()))
                                                  .Returns(viewModelsList);

            var mockedBarsService = new Mock<IBarsService>();
            int count;
            var bars = new List<ShishaBar>();
            mockedBarsService.Setup(x => x.GetBarsWithPaging(out count,
                                                             It.IsAny<int>(),
                                                             It.IsAny<int>()))
                                                             .Returns(bars);

            var controller = new AllBarsController(mockedMappingService.Object,
                                               mockedBarsService.Object);

            //Act & Assert
            controller.WithCallTo(x => x.Index(2, 2))
                .ShouldRenderDefaultView()
                .WithModel<StaticPagedList<AllBarsViewModel>>();
        }
    }
}
