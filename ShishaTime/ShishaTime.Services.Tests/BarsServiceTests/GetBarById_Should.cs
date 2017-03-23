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
    public class GetBarById_Should
    {
        [Test]
        public void CallDataBarsRepository()
        {
            //Arrange
            var barsRepoMock = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            barsRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Verifiable();
            var dataMock = new Mock<IShishaTimeData>();
            dataMock.Setup(x => x.Bars).Verifiable();
            dataMock.Setup(x => x.Bars).Returns(barsRepoMock.Object);
            var barsService = new BarsService(dataMock.Object);

            //Act
            barsService.GetBarById(1);

            //Assert
            dataMock.Verify(x => x.Bars, Times.Once());
        }

        [Test]
        public void CallDataBarsRepository_GetByIdMethod()
        {
            //Arrange
            var barsRepoMock = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            barsRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Verifiable();
            var dataMock = new Mock<IShishaTimeData>();
            dataMock.Setup(x => x.Bars).Verifiable();
            dataMock.Setup(x => x.Bars).Returns(barsRepoMock.Object);
            var barsService = new BarsService(dataMock.Object);

            //Act
            barsService.GetBarById(1);

            //Assert
            barsRepoMock.Verify(x => x.GetById(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void CallDataBarsRepository_GetByIdMethod_WithCorrectParameter()
        {
            //Arrange
            var barsRepoMock = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            barsRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Verifiable();
            var dataMock = new Mock<IShishaTimeData>();
            dataMock.Setup(x => x.Bars).Verifiable();
            dataMock.Setup(x => x.Bars).Returns(barsRepoMock.Object);
            var barsService = new BarsService(dataMock.Object);

            //Act
            barsService.GetBarById(1);

            //Assert
            barsRepoMock.Verify(x => x.GetById(1), Times.Once());
        }

        [Test]
        public void ReturnCorrectResult()
        {
            //Arrange
            var mockedBar = new Mock<ShishaBar>();
            var barsRepoMock = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            barsRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Verifiable();
            barsRepoMock.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedBar.Object);
            var dataMock = new Mock<IShishaTimeData>();
            dataMock.Setup(x => x.Bars).Verifiable();
            dataMock.Setup(x => x.Bars).Returns(barsRepoMock.Object);
            var barsService = new BarsService(dataMock.Object);

            //Act
            var result = barsService.GetBarById(1);

            //Assert
            Assert.AreEqual(mockedBar.Object, result);
        }
    }
}
