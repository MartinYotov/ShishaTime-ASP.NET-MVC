using Moq;
using NUnit.Framework;
using ShishaTime.Data.Contracts;
using ShishaTime.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShishaTime.Services.Tests.RegionsServiceTests
{
    [TestFixture]
    public class GetAllRegions_Should
    {
        [Test]
        public void CallDataRegionsRepository()
        {
            //Arrange
            var mockedRegion = new Mock<Region>();
            var list = new List<Region> { mockedRegion.Object };                
            var regionsRepoMock = new Mock<IEntityFrameworkRepository<Region>>();
            regionsRepoMock.Setup(x => x.All).Verifiable();
            regionsRepoMock.Setup(x => x.All).Returns(list.AsQueryable());
            var dataMock = new Mock<IShishaTimeData>();
            dataMock.Setup(x => x.Regions).Verifiable();
            dataMock.Setup(x => x.Regions).Returns(regionsRepoMock.Object);
            var regionsService = new RegionsService(dataMock.Object);

            //Act
            regionsService.GetAllRegions();

            //Assert
            dataMock.Verify(x => x.Regions, Times.Once());
        }

        [Test]
        public void CallRegionsRepository_AllProperty()
        {
            //Arrange
            var mockedRegion = new Mock<Region>();
            var list = new List<Region> { mockedRegion.Object };
            var regionsRepoMock = new Mock<IEntityFrameworkRepository<Region>>();
            regionsRepoMock.Setup(x => x.All).Verifiable();
            regionsRepoMock.Setup(x => x.All).Returns(list.AsQueryable());
            var dataMock = new Mock<IShishaTimeData>();
            dataMock.Setup(x => x.Regions).Verifiable();
            dataMock.Setup(x => x.Regions).Returns(regionsRepoMock.Object);
            var regionsService = new RegionsService(dataMock.Object);

            //Act
            regionsService.GetAllRegions();

            //Assert
            regionsRepoMock.Verify(x => x.All, Times.Once());
        }

        [Test]
        public void ReturnCorrectResult()
        {
            //Arrange
            var mockedRegion = new Mock<Region>();
            var list = new List<Region> { mockedRegion.Object };
            var regionsRepoMock = new Mock<IEntityFrameworkRepository<Region>>();
            regionsRepoMock.Setup(x => x.All).Verifiable();
            regionsRepoMock.Setup(x => x.All).Returns(list.AsQueryable());
            var dataMock = new Mock<IShishaTimeData>();
            dataMock.Setup(x => x.Regions).Verifiable();
            dataMock.Setup(x => x.Regions).Returns(regionsRepoMock.Object);
            var regionsService = new RegionsService(dataMock.Object);

            //Act
            var regions = regionsService.GetAllRegions();

            //Assert
            Assert.AreEqual(list, regions);
        }
    }
}
