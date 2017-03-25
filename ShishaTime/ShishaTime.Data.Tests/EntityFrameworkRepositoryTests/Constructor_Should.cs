using Moq;
using NUnit.Framework;
using ShishaTime.Data.Contracts;
using ShishaTime.Data.Tests.EntityFrameworkRepositoryTests.Mocks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Data.Tests.EntityFrameworkRepositoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ReturnAnInstance_ParametersAreNotNull()
        {
            //Arrange
            var mockedDbContext = new Mock<IShishaTimeDbContext>();

            //Act
            var efRepo = new EntityFrameworkRepository<MockedModel>(mockedDbContext.Object);

            //Assert
            Assert.IsInstanceOf<EntityFrameworkRepository<MockedModel>>(efRepo);
        }

        [Test]
        public void ThrowArgumentNullException_WhenContextIsNull()
        {
            //Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new EntityFrameworkRepository<MockedModel>(null));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenContextIsNull()
        {
            //Arrange, Act, Assert
            Assert.That(() => new EntityFrameworkRepository<MockedModel>(null),
                Throws.ArgumentNullException.With.Message.Contains("DbContext cannot be null."));
        }

        [Test]
        public void CallContextSetMethod()
        {
            //Arrange
            var mockedContext = new Mock<IShishaTimeDbContext>();
            mockedContext.Setup(x => x.Set<MockedModel>()).Verifiable();

            //Act
            var repository = new EntityFrameworkRepository<MockedModel>(mockedContext.Object);

            //Assert
            mockedContext.Verify(x => x.Set<MockedModel>(), Times.Once);
        }
    }
}
