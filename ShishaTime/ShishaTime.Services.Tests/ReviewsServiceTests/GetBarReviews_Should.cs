using Moq;
using NUnit.Framework;
using ShishaTime.Data.Contracts;
using ShishaTime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Services.Tests.ReviewsServiceTests
{
    [TestFixture]
    public class GetBarReviews_Should
    {
        [Test]
        public void CallDataReviewsRepository()
        {
            //Arrange
            var expectedReview = new Review() { BarId = 2 };
            var reviewsList = new List<Review>
            {
                new Review() { BarId = 1 },
                expectedReview,
                new Review() { BarId = 3 },
            }.AsQueryable();

            var mockedReviewsRepo = new Mock<IEntityFrameworkRepository<Review>>();
            mockedReviewsRepo.Setup(x => x.All).Returns(reviewsList);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Reviews).Returns(mockedReviewsRepo.Object);
            var service = new ReviewsService(mockedData.Object);

            //Act
            service.GetBarReviews(2);

            //Assert
            mockedData.Verify(x => x.Reviews, Times.Once());
        }

        [Test]
        public void CallDataReviewsRepository_AllProperty()
        {
            //Arrange
            var expectedReview = new Review() { BarId = 2 };
            var reviewsList = new List<Review>
            {
                new Review() { BarId = 1 },
                expectedReview,
                new Review() { BarId = 3 },
            }.AsQueryable();

            var mockedReviewsRepo = new Mock<IEntityFrameworkRepository<Review>>();
            mockedReviewsRepo.Setup(x => x.All).Returns(reviewsList);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Reviews).Returns(mockedReviewsRepo.Object);
            var service = new ReviewsService(mockedData.Object);

            //Act
            service.GetBarReviews(2);

            //Assert
            mockedReviewsRepo.Verify(x => x.All, Times.Once());
        }

        [Test]
        public void ReturnsCorrectResult_WhenThereIsOneReviewWithPassedId()
        {
            //Arrange
            var expectedReview = new Review() { BarId = 2 };
            var reviewsList = new List<Review>
            {
                new Review() { BarId = 1 },
                expectedReview,
                new Review() { BarId = 3 },
            }.AsQueryable();

            var mockedReviewsRepo = new Mock<IEntityFrameworkRepository<Review>>();
            mockedReviewsRepo.Setup(x => x.All).Returns(reviewsList);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Reviews).Returns(mockedReviewsRepo.Object);
            var service = new ReviewsService(mockedData.Object);

            //Act
            var result = service.GetBarReviews(2);

            //Assert
            Assert.IsTrue(result.Count() == 1);
            Assert.AreEqual(expectedReview, result.FirstOrDefault());
        }

        [Test]
        public void ReturnsCorrectResult_WhenThereAreSeveralReviewsWithPassedId()
        {
            //Arrange
            var reviewsList = new List<Review>
            {
                new Review() { BarId = 1 },
                new Review() { BarId = 2 },
                new Review() { BarId = 2 },
                new Review() { BarId = 3 },
            }.AsQueryable();


            var mockedReviewsRepo = new Mock<IEntityFrameworkRepository<Review>>();
            mockedReviewsRepo.Setup(x => x.All).Returns(reviewsList);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Reviews).Returns(mockedReviewsRepo.Object);
            var service = new ReviewsService(mockedData.Object);

            //Act
            var result = service.GetBarReviews(2);

            //Assert
            Assert.IsTrue(result.Count() == 2);
            Assert.IsTrue(result.All(x => x.BarId == 2));
        }
    }
}
