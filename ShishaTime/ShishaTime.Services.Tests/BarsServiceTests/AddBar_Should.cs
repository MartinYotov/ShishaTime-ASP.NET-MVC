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
    public class AddBar_Should
    {
        [Test]
        public void CallDataBarsRepository()
        {
            //Arrange
            var barsRepoMock = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            barsRepoMock.Setup(x => x.Add(It.IsAny<ShishaBar>())).Verifiable();
            var dataMock = new Mock<IShishaTimeData>();
            dataMock.Setup(x => x.Bars).Verifiable();
            dataMock.Setup(x => x.Bars).Returns(barsRepoMock.Object);
            dataMock.Setup(x => x.SaveChanges()).Verifiable();
            var barsService = new BarsService(dataMock.Object);
            var mockedBar = new Mock<ShishaBar>();

            //Act
            barsService.AddBar(mockedBar.Object);

            //Assert
            dataMock.Verify(x => x.Bars, Times.Once());
        }

        [Test]
        public void CallDataBarsRepository_AddMethod()
        {
            //Arrange
            var barsRepoMock = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            barsRepoMock.Setup(x => x.Add(It.IsAny<ShishaBar>())).Verifiable();
            var dataMock = new Mock<IShishaTimeData>();
            dataMock.Setup(x => x.Bars).Verifiable();
            dataMock.Setup(x => x.Bars).Returns(barsRepoMock.Object);
            dataMock.Setup(x => x.SaveChanges()).Verifiable();
            var barsService = new BarsService(dataMock.Object);
            var mockedBar = new Mock<ShishaBar>();

            //Act
            barsService.AddBar(mockedBar.Object);

            //Assert
            barsRepoMock.Verify(x => x.Add(It.IsAny<ShishaBar>()), Times.Once());
        }

        [Test]
        public void CallDataBarsRepository_AddMethod_WithTheCorrectParameter()
        {
            //Arrange
            var barsRepoMock = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            barsRepoMock.Setup(x => x.Add(It.IsAny<ShishaBar>())).Verifiable();
            var dataMock = new Mock<IShishaTimeData>();
            dataMock.Setup(x => x.Bars).Verifiable();
            dataMock.Setup(x => x.Bars).Returns(barsRepoMock.Object);
            dataMock.Setup(x => x.SaveChanges()).Verifiable();
            var barsService = new BarsService(dataMock.Object);
            var mockedBar = new Mock<ShishaBar>();

            //Act
            barsService.AddBar(mockedBar.Object);

            //Assert
            barsRepoMock.Verify(x => x.Add(mockedBar.Object), Times.Once());
        }

        [Test]
        public void CallDataSaveChangesMethod()
        {
            //Arrange
            var barsRepoMock = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            barsRepoMock.Setup(x => x.Add(It.IsAny<ShishaBar>())).Verifiable();
            var dataMock = new Mock<IShishaTimeData>();
            dataMock.Setup(x => x.Bars).Verifiable();
            dataMock.Setup(x => x.Bars).Returns(barsRepoMock.Object);
            dataMock.Setup(x => x.SaveChanges()).Verifiable();
            var barsService = new BarsService(dataMock.Object);
            var mockedBar = new Mock<ShishaBar>();

            //Act
            barsService.AddBar(mockedBar.Object);

            //Assert
            dataMock.Verify(x => x.SaveChanges(), Times.Once());
        }
    }
}
