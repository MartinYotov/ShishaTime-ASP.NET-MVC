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
    public class GetTopRated_Should
    {
        [Test]
        public void CallDataBarsRepo()
        {
            //Arrange
            var bars = new List<ShishaBar>().AsQueryable();
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.All).Returns(bars);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            var service = new BarsService(mockedData.Object);

            //Act
            service.GetTopRated(3);

            //Arrange
            mockedData.Verify(x => x.Bars, Times.Once());
        }

        [Test]
        public void CallDataBarsRepo_AllProperty()
        {
            //Arrange
            var bars = new List<ShishaBar>().AsQueryable();
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.All).Returns(bars);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            var service = new BarsService(mockedData.Object);

            //Act
            service.GetTopRated(3);

            //Arrange
            mockedBarsRepo.Verify(x => x.All, Times.Once());
        }

        [Test]
        public void ReturnsCorrectNumberOfBars()
        {
            //Arrange
            var bars = new List<ShishaBar>()
            {
                new ShishaBar() { RatingValue = 4.9 },
                new ShishaBar() { RatingValue = 2.0 },
                new ShishaBar() { RatingValue = 3.6 },
                new ShishaBar() { RatingValue = 1.3 },
                new ShishaBar() { RatingValue = 4.6 }

            }.AsQueryable();
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.All).Returns(bars);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            var service = new BarsService(mockedData.Object);

            //Act
            var result = service.GetTopRated(3);

            //Arrange
            Assert.IsTrue(result.Count() == 3);
        }

        [Test]
        public void ReturnsBarsCount_WhenItIsLessThanThePassedParameter()
        {
            //Arrange
            var bars = new List<ShishaBar>()
            {
                new ShishaBar() { RatingValue = 1.3 },
                new ShishaBar() { RatingValue = 4.6 }

            }.AsQueryable();
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.All).Returns(bars);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            var service = new BarsService(mockedData.Object);

            //Act
            var result = service.GetTopRated(3);

            //Arrange
            Assert.IsTrue(result.Count() == 2);
        }

        [Test]
        public void SortTheReturnedBarsByRating()
        {
            //Arrange
            var bars = new List<ShishaBar>()
            {
                new ShishaBar() { RatingValue = 4.9 },
                new ShishaBar() { RatingValue = 2.0 },
                new ShishaBar() { RatingValue = 3.6 },
                new ShishaBar() { RatingValue = 1.3 },
                new ShishaBar() { RatingValue = 4.6 }

            }.AsQueryable();
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.All).Returns(bars);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            var service = new BarsService(mockedData.Object);

            //Act
            var result = service.GetTopRated(3);
            var expected = result.OrderByDescending(x => x.RatingValue).ToList();

            //Arrange
            Assert.AreEqual(expected, result);
            Assert.AreEqual(4.9, result.First().RatingValue);
            Assert.AreEqual(3.6, result.Last().RatingValue);
        }
    }
}
