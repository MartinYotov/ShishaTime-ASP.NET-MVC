using Moq;
using NUnit.Framework;
using ShishaTime.Data.Contracts;
using ShishaTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Data.Tests.ShishaTimeDataTests
{
    [TestFixture]
    public class SaveChanges_Should
    {
        [Test]
        public static void CallDbContextSaveChangesMethod()
        {
            //Arrange
            var mockedDbContext = new Mock<IShishaTimeDbContext>();
            mockedDbContext.Setup(x => x.SaveChanges()).Verifiable();
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            var mockedUsersRepo = new Mock<IEntityFrameworkRepository<User>>();
            var mockedRegionsRepo = new Mock<IEntityFrameworkRepository<Region>>();
            var mockedReviewsRepo = new Mock<IEntityFrameworkRepository<Review>>();
            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();

           
            var data = new ShishaTimeData(mockedDbContext.Object,
                                          mockedBarsRepo.Object,
                                          mockedUsersRepo.Object,
                                          mockedRegionsRepo.Object,
                                          mockedReviewsRepo.Object,
                                          mockedRatingsRepo.Object);

            //Act
            data.SaveChanges();

            //Assert
            mockedDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }
    }
}
