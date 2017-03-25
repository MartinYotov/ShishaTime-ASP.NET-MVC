using Moq;
using NUnit.Framework;
using ShishaTime.Data.Contracts;
using System;

namespace ShishaTime.Services.Tests.BarsServiceTests
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
            var service = new BarsService(mockedData.Object);

            //Assert
            Assert.IsInstanceOf<BarsService>(service);
        }

        [Test]
        public void ThrowArgumentNullException_WhenDataIsNull()
        {
            //Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new BarsService(null));
        }

        [Test]
        public void ThrowArgumentNullExceptionWithCorrectMessage_WhenDataIsNull()
        {
            //Arrange, Act & Assert
            Assert.That(() => new BarsService(null),
               Throws.ArgumentNullException.With.Message.Contains("Data cannot be null."));
        }
    }
}
