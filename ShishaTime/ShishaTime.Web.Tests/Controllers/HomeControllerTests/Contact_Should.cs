using Moq;
using NUnit.Framework;
using ShishaTime.Services.Contracts;
using ShishaTime.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShishaTime.Web.Tests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class Contact_Should
    {
        [Test]
        public void DefaultTest_Contact()
        {
            // Arrange
            var mockedMappingService = new Mock<IMappingService>();
            var mockedBarsService = new Mock<IBarsService>();
            HomeController controller = new HomeController(mockedMappingService.Object,
                                                           mockedBarsService.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
