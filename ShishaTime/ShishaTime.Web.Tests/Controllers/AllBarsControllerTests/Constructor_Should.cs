using Moq;
using NUnit.Framework;
using ShishaTime.Services.Contracts;
using ShishaTime.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Web.Tests.Controllers.AllBarsControllerTests
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

            //Act
            var controller = new AllBarsController(mockedMappingService.Object,
                                               mockedBarsService.Object);

            //Assert
            Assert.IsInstanceOf<AllBarsController>(controller);
        }

        [Test]
        public void ThrowArgumentNullException_WhenMappingServiceIsNull()
        {
            //Arrange
            var mockedBarsService = new Mock<IBarsService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AllBarsController(null,
                                                                             mockedBarsService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenMappingServiceIsNull()
        {
            //Arrange
            var mockedBarsService = new Mock<IBarsService>();

            //Act & Assert
            Assert.That(() => new AllBarsController(null,
                                                    mockedBarsService.Object),
               Throws.ArgumentNullException.With.Message.Contains("Mapping service cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenBarsServiceIsNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AllBarsController(mockedMappingService.Object,
                                                                         null));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenBarsServiceIsNull()
        {
            //Arrange
            var mockedMappingService = new Mock<IMappingService>();

            //Act & Assert
            Assert.That(() => new AllBarsController(mockedMappingService.Object,
                                                null),
               Throws.ArgumentNullException.With.Message.Contains("Bars service cannot be null."));
        }
    }
}