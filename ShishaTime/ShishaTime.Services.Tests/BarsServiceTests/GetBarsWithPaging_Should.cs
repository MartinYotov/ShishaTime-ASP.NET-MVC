using Moq;
using NUnit.Framework;
using ShishaTime.Data.Contracts;
using ShishaTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Services.Tests.BarsServiceTests
{
    [TestFixture]
    public class GetBarsWithPaging_Should
    {
        [Test]
        public void CallDataBarsRepo_AllPropertyTwice()
        {
            //Arrange
            var bars = new List<ShishaBar>().AsQueryable();
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.All).Returns(bars);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            var service = new BarsService(mockedData.Object);
            int count;

            //Act
            service.GetBarsWithPaging(out count, 1, 5);

            //Arrange
            mockedBarsRepo.Verify(x => x.All, Times.Exactly(2));
        }

        [Test]
        public void ReturnsCorrectCount()
        {
            //Arrange
            var bars = new List<ShishaBar>()
            {
                new ShishaBar(),
                new ShishaBar()
            }.AsQueryable();
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.All).Returns(bars);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            var service = new BarsService(mockedData.Object);
            int count;

            //Act
            service.GetBarsWithPaging(out count, 1, 5);

            //Arrange
            Assert.AreEqual(2, count);
        }

        [Test]
        public void ReturnsPagesCorrectly()
        {
            //Arrange
            var bar1 = new ShishaBar() { Id = 1 };
            var bar2 = new ShishaBar() { Id = 2 };
            var bar3 = new ShishaBar() { Id = 3 };

            var bars = new List<ShishaBar>()
            {
                bar1,
                bar2,
                bar3
            }.AsQueryable();
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.All).Returns(bars);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            var service = new BarsService(mockedData.Object);
            int count;
            var expected = new List<ShishaBar>() { bar2 };

            //Act
            var result = service.GetBarsWithPaging(out count, 2, 1);

            //Arrange
            Assert.AreEqual(expected, result);
        }
    }
}
