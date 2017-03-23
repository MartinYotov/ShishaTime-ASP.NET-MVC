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
    public class AddReview_Should
    {
        [Test]
        public void CallDataBarsRepository()
        {
            //Arrange
            var mockedReviewsCollection = new Mock<ICollection<Review>>();
            mockedReviewsCollection.Setup(x => x.Add(It.IsAny<Review>())).Verifiable();
            var mockedBar = new Mock<ShishaBar>();
            mockedBar.Setup(x => x.Reviews).Returns(mockedReviewsCollection.Object);
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedBar.Object);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            mockedData.Setup(x => x.SaveChanges()).Verifiable();
            var mockedReview = new Mock<Review>();
            var service = new ReviewsService(mockedData.Object);

            //Act
            service.AddReview(1, mockedReview.Object);

            //Assert
            mockedData.Verify(x => x.Bars, Times.Once());
        }

        [Test]
        public void CallDataBarsRepository_GetByIdMethod()
        {
            //Arrange
            var mockedReviewsCollection = new Mock<ICollection<Review>>();
            mockedReviewsCollection.Setup(x => x.Add(It.IsAny<Review>())).Verifiable();
            var mockedBar = new Mock<ShishaBar>();
            mockedBar.Setup(x => x.Reviews).Returns(mockedReviewsCollection.Object);
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedBar.Object);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            mockedData.Setup(x => x.SaveChanges()).Verifiable();
            var mockedReview = new Mock<Review>();
            var service = new ReviewsService(mockedData.Object);

            //Act
            service.AddReview(1, mockedReview.Object);

            //Assert
            mockedBarsRepo.Verify(x => x.GetById(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void CallDataBarsRepository_GetByIdMethod_WithCorrectId()
        {
            //Arrange
            var mockedReviewsCollection = new Mock<ICollection<Review>>();
            mockedReviewsCollection.Setup(x => x.Add(It.IsAny<Review>())).Verifiable();
            var mockedBar = new Mock<ShishaBar>();
            mockedBar.Setup(x => x.Reviews).Returns(mockedReviewsCollection.Object);
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedBar.Object);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            mockedData.Setup(x => x.SaveChanges()).Verifiable();
            var mockedReview = new Mock<Review>();
            var service = new ReviewsService(mockedData.Object);

            //Act
            service.AddReview(1, mockedReview.Object);

            //Assert
            mockedBarsRepo.Verify(x => x.GetById(1), Times.Once());
        }

        [Test]
        public void CallBar_ReviewCollection()
        {
            //Arrange
            var mockedReviewsCollection = new Mock<ICollection<Review>>();
            mockedReviewsCollection.Setup(x => x.Add(It.IsAny<Review>())).Verifiable();
            var mockedBar = new Mock<ShishaBar>();
            mockedBar.Setup(x => x.Reviews).Returns(mockedReviewsCollection.Object);
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedBar.Object);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            mockedData.Setup(x => x.SaveChanges()).Verifiable();
            var mockedReview = new Mock<Review>();
            var service = new ReviewsService(mockedData.Object);

            //Act
            service.AddReview(1, mockedReview.Object);

            //Assert
            mockedBar.Verify(x => x.Reviews, Times.Once());
        }

        [Test]
        public void CallBar_ReviewCollection_AddMethod()
        {
            //Arrange
            var mockedReviewsCollection = new Mock<ICollection<Review>>();
            mockedReviewsCollection.Setup(x => x.Add(It.IsAny<Review>())).Verifiable();
            var mockedBar = new Mock<ShishaBar>();
            mockedBar.Setup(x => x.Reviews).Returns(mockedReviewsCollection.Object);
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedBar.Object);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            mockedData.Setup(x => x.SaveChanges()).Verifiable();
            var mockedReview = new Mock<Review>();
            var service = new ReviewsService(mockedData.Object);

            //Act
            service.AddReview(1, mockedReview.Object);

            //Assert
            mockedReviewsCollection.Verify(x => x.Add(It.IsAny<Review>()), Times.Once());
        }

        [Test]
        public void CallBar_ReviewCollection_AddMethod_WithCorrectParameter()
        {
            //Arrange
            var mockedReviewsCollection = new Mock<ICollection<Review>>();
            mockedReviewsCollection.Setup(x => x.Add(It.IsAny<Review>())).Verifiable();
            var mockedBar = new Mock<ShishaBar>();
            mockedBar.Setup(x => x.Reviews).Returns(mockedReviewsCollection.Object);
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedBar.Object);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            mockedData.Setup(x => x.SaveChanges()).Verifiable();
            var mockedReview = new Mock<Review>();
            var service = new ReviewsService(mockedData.Object);

            //Act
            service.AddReview(1, mockedReview.Object);

            //Assert
            mockedReviewsCollection.Verify(x => x.Add(mockedReview.Object), Times.Once());
        }

        [Test]
        public void CallData_SaveChangesMethod()
        {
            //Arrange
            var mockedReviewsCollection = new Mock<ICollection<Review>>();
            mockedReviewsCollection.Setup(x => x.Add(It.IsAny<Review>())).Verifiable();
            var mockedBar = new Mock<ShishaBar>();
            mockedBar.Setup(x => x.Reviews).Returns(mockedReviewsCollection.Object);
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(mockedBar.Object);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            mockedData.Setup(x => x.SaveChanges()).Verifiable();
            var mockedReview = new Mock<Review>();
            var service = new ReviewsService(mockedData.Object);

            //Act
            service.AddReview(1, mockedReview.Object);

            //Assert
            mockedData.Verify(x => x.SaveChanges(), Times.Once());
        }
    }
}
