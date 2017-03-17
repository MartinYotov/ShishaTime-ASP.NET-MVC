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
    public class AllProperty_Should
    {
        [Test]
        public void ReturnDbSet()
        {
            //Arrange
            var mockedContext = new Mock<IShishaTimeDbContext>();
            var mockedSet = new Mock<IDbSet<MockedModel>>();
            mockedContext.Setup(x => x.Set<MockedModel>()).Returns(mockedSet.Object);

            var repository = new EntityFrameworkRepository<MockedModel>(mockedContext.Object);

            //Act
            var result = repository.All;

            //Assert
            Assert.AreEqual(mockedSet.Object, result);
        }
    }
}
