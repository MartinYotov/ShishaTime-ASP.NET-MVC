using Moq;
using NUnit.Framework;
using ShishaTime.Data.Contracts;
using ShishaTime.Data.Tests.EntityFrameworkRepositoryTests.Mocks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Data.Tests.EntityFrameworkRepositoryTests
{
    [TestFixture]
    public class GetById_Should
    {
        [TestCase(2)]
        [TestCase("abc")]
        public void CallDbSetFindMethod(object id)
        {
            //Arrange
            var mockedContext = new Mock<IShishaTimeDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.Setup(x => x.Find(It.IsAny<object>())).Verifiable();

            var repository = new EntityFrameworkRepository<MockedModel>(mockedContext.Object);

            //Act
            repository.GetById(id);

            //Assert
            mockedSet.Verify(x => x.Find(It.IsAny<object>()), Times.Once);
        }

        [TestCase(2)]
        [TestCase("abc")]
        public void CallDbSetFindMethodWithCorrectParameter(object id)
        {
            //Arrange
            var mockedContext = new Mock<IShishaTimeDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.Setup(x => x.Find(It.IsAny<object>())).Verifiable();

            var repository = new EntityFrameworkRepository<MockedModel>(mockedContext.Object);

            //Act
            repository.GetById(id);

            //Assert
            mockedSet.Verify(x => x.Find(id), Times.Once);
        }

        [Test]
        public void ReturnTheCorrectResult()
        {
            //Arrange
            var mockedContext = new Mock<IShishaTimeDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            var mockedModel = new MockedModel();
            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);
            mockedSet.Setup(x => x.Find(It.IsAny<object>())).Returns(mockedModel);

            var repository = new EntityFrameworkRepository<MockedModel>(mockedContext.Object);

            //Act
            var result = repository.GetById("abc");

            //Assert
            Assert.AreEqual(mockedModel, result);
        }
    }
}
