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
    public class AddRating_Should
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
            mockedData.Setup(x => x.SaveChanges()).Verifiable();
            var service = new RatingService(mockedData.Object);
            var rating = new Rating() { BarId = 1, UserId = "1", Value = 5 };

            //Act
            service.AddRating(rating);

            //Assert
            mockedData.Verify(x => x.Ratings, Times.AtLeastOnce());
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
            mockedData.Setup(x => x.SaveChanges()).Verifiable();
            var service = new RatingService(mockedData.Object);
            var rating = new Rating() { BarId = 1, UserId = "1", Value = 5 };

            //Act
            service.AddRating(rating);

            //Assert
            mockedRatingsRepo.Verify(x => x.All, Times.Once());
        }

        [Test]
        public void ChangeRatingValue_IfAlreadyExists()
        {
            //Assert
            var rating = new Rating() { BarId = 1, UserId = "1", Value = 5 };
            var ratings = new List<Rating>()
            {
                new Rating() { BarId = 2, UserId = "2", Value = 4 },
                rating,
                new Rating() { BarId = 1, UserId = "2", Value = 2 }
            }.AsQueryable();
            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();
            mockedRatingsRepo.Setup(x => x.All).Returns(ratings);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Ratings).Returns(mockedRatingsRepo.Object);
            mockedData.Setup(x => x.SaveChanges()).Verifiable();
            var service = new RatingService(mockedData.Object);            

            //Act
            service.AddRating(new Rating() { BarId = 1, UserId = "1", Value = 1 });

            //Assert
            Assert.AreEqual(1, rating.Value);
        }

        [Test]
        public void CallRatingsRepo_AddMethod_IfRatingDoesNotExist()
        {
            //Assert
            var ratings = new List<Rating>()
            {
                new Rating() { BarId = 2, UserId = "2", Value = 4 },
                new Rating() { BarId = 1, UserId = "1", Value = 5 },
                new Rating() { BarId = 1, UserId = "2", Value = 2 }
            }.AsQueryable();

            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();
            mockedRatingsRepo.Setup(x => x.All).Returns(ratings);
            mockedRatingsRepo.Setup(x => x.Add(It.IsAny<Rating>())).Verifiable();
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Ratings).Returns(mockedRatingsRepo.Object);
            mockedData.Setup(x => x.SaveChanges()).Verifiable();
            var service = new RatingService(mockedData.Object);
            var rating = new Rating() { BarId = 3, UserId = "1", Value = 1 };

            //Act
            service.AddRating(rating);

            //Assert
            mockedRatingsRepo.Verify(x => x.Add(It.IsAny<Rating>()), Times.Once());
        }

        [Test]
        public void CallRatingsRepo_AddMethod_WithTheNewRating_IfRatingDoesNotExist()
        {
            //Assert
            var ratings = new List<Rating>()
            {
                new Rating() { BarId = 2, UserId = "2", Value = 4 },
                new Rating() { BarId = 1, UserId = "1", Value = 5 },
                new Rating() { BarId = 1, UserId = "2", Value = 2 }
            }.AsQueryable();

            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();
            mockedRatingsRepo.Setup(x => x.All).Returns(ratings);
            mockedRatingsRepo.Setup(x => x.Add(It.IsAny<Rating>())).Verifiable();
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Ratings).Returns(mockedRatingsRepo.Object);
            mockedData.Setup(x => x.SaveChanges()).Verifiable();
            var service = new RatingService(mockedData.Object);
            var rating = new Rating() { BarId = 3, UserId = "1", Value = 1 };
            //Act
            service.AddRating(rating);

            //Assert
            mockedRatingsRepo.Verify(x => x.Add(rating), Times.Once());
        }
    }
}
