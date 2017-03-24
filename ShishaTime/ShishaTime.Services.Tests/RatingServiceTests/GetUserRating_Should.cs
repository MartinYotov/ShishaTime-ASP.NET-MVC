using Moq;
using NUnit.Framework;
using ShishaTime.Data.Contracts;
using ShishaTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Services.Tests.RatingServiceTests
{
    [TestFixture]
    public class GetUserRating_Should
    {
        [Test]
        public void CallDataRatingsRepo()
        {
            //Assert
            var ratings = new List<Rating>().AsQueryable();
            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();
            mockedRatingsRepo.Setup(x => x.All).Returns(ratings);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Ratings).Returns(mockedRatingsRepo.Object);
            var service = new RatingService(mockedData.Object);

            //Act
            service.GetUserRating(1, "1");

            //Assert
            mockedData.Verify(x => x.Ratings, Times.Once());
        }

        [Test]
        public void CallDataRatingsRepo_AllProperty()
        {
            //Assert
            var ratings = new List<Rating>().AsQueryable();
            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();
            mockedRatingsRepo.Setup(x => x.All).Returns(ratings);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Ratings).Returns(mockedRatingsRepo.Object);
            var service = new RatingService(mockedData.Object);

            //Act
            service.GetUserRating(1, "1");

            //Assert
            mockedRatingsRepo.Verify(x => x.All, Times.Once());
        }

        [Test]
        public void ReturnUserRating_IfExists()
        {
            //Assert
            var expected = new Rating() { BarId = 1, UserId = "1", Value = 1 };
            var ratings = new List<Rating>()
            {
                new Rating() { BarId = 2, UserId = "2", Value = 1  },
                expected,
                new Rating() { BarId = 1, UserId = "2", Value = 1  }

            }.AsQueryable();

            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();
            mockedRatingsRepo.Setup(x => x.All).Returns(ratings);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Ratings).Returns(mockedRatingsRepo.Object);
            var service = new RatingService(mockedData.Object);

            //Act
            var result = service.GetUserRating(1, "1");

            //Assert
            Assert.AreEqual(expected.Value, result);
        }

        [Test]
        public void Return0_IfRatingDoesNotExist()
        {
            //Assert
            var ratings = new List<Rating>()
            {
                new Rating() { BarId = 2, UserId = "2", Value = 1  },
                new Rating() { BarId = 1, UserId = "1", Value = 1  },
                new Rating() { BarId = 1, UserId = "2", Value = 1  }

            }.AsQueryable();

            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();
            mockedRatingsRepo.Setup(x => x.All).Returns(ratings);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Ratings).Returns(mockedRatingsRepo.Object);
            var service = new RatingService(mockedData.Object);

            //Act
            var result = service.GetUserRating(1, "3");

            //Assert
            Assert.AreEqual(0, result);
        }
    }
}
