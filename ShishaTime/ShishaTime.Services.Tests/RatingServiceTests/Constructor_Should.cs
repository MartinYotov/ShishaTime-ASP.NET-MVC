using Moq;
using NUnit.Framework;
using ShishaTime.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Services.Tests.RatingServiceTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnAnInstance_ParametersAreNotNull()
        {
            //Arrange
            var mockedData = new Mock<IShishaTimeData>();

            //Act
            var service = new RatingService(mockedData.Object);

            //Assert
            Assert.IsInstanceOf<RatingService>(service);
        }

        [Test]
        public void ThrowArgumentNullException_WhenDataIsNull()
        {
            //Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new RatingService(null));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenDataIsNull()
        {
            //Arrange, Act & Assert
            Assert.That(() => new RatingService(null),
               Throws.ArgumentNullException.With.Message.Contains("Data cannot be null."));
        }
    }
}
