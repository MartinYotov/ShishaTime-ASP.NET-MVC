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
    public class Constructor_Should
    {
        [Test]
        public void ReturnAnInstance_ParametersAreNotNull()
        {
            //Arrange
            var mockedContext = new Mock<IShishaTimeDbContext>();
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            var mockedUsersRepo = new Mock<IEntityFrameworkRepository<User>>();
            var mockedRegionsRepo = new Mock<IEntityFrameworkRepository<Region>>();
            var mockedReviewsRepo = new Mock<IEntityFrameworkRepository<Review>>();
            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();

            //Act
            var data = new ShishaTimeData(mockedContext.Object,
                                          mockedBarsRepo.Object,
                                          mockedUsersRepo.Object,
                                          mockedRegionsRepo.Object,
                                          mockedReviewsRepo.Object,
                                          mockedRatingsRepo.Object);

            //Assert
            Assert.IsInstanceOf<ShishaTimeData>(data);
        }

        [Test]
        public void ThrowArgumentNullException_WhenContextIsNull()
        {
            //Arrange
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            var mockedUsersRepo = new Mock<IEntityFrameworkRepository<User>>();
            var mockedRegionsRepo = new Mock<IEntityFrameworkRepository<Region>>();
            var mockedReviewsRepo = new Mock<IEntityFrameworkRepository<Review>>();
            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ShishaTimeData(null,
                                                                          mockedBarsRepo.Object,
                                                                          mockedUsersRepo.Object,
                                                                          mockedRegionsRepo.Object,
                                                                          mockedReviewsRepo.Object,
                                                                          mockedRatingsRepo.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenContextIsNull()
        {
            //Arrange
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            var mockedUsersRepo = new Mock<IEntityFrameworkRepository<User>>();
            var mockedRegionsRepo = new Mock<IEntityFrameworkRepository<Region>>();
            var mockedReviewsRepo = new Mock<IEntityFrameworkRepository<Review>>();
            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();

            //Act & Assert
            Assert.That(() => new ShishaTimeData(null,
                                                 mockedBarsRepo.Object,
                                                 mockedUsersRepo.Object,
                                                 mockedRegionsRepo.Object,
                                                 mockedReviewsRepo.Object,
                                                 mockedRatingsRepo.Object),
                Throws.ArgumentNullException.With.Message.Contains("DbContext cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenBarsRepositoryIsNull()
        {
            //Arrange
            var mockedContext = new Mock<IShishaTimeDbContext>();
            var mockedUsersRepo = new Mock<IEntityFrameworkRepository<User>>();
            var mockedRegionsRepo = new Mock<IEntityFrameworkRepository<Region>>();
            var mockedReviewsRepo = new Mock<IEntityFrameworkRepository<Review>>();
            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ShishaTimeData(mockedContext.Object,
                                                                          null,
                                                                          mockedUsersRepo.Object,
                                                                          mockedRegionsRepo.Object,
                                                                          mockedReviewsRepo.Object,
                                                                          mockedRatingsRepo.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenBarsRepositoryIsNull()
        {
            //Arrange
            var mockedContext = new Mock<IShishaTimeDbContext>();
            var mockedUsersRepo = new Mock<IEntityFrameworkRepository<User>>();
            var mockedRegionsRepo = new Mock<IEntityFrameworkRepository<Region>>();
            var mockedReviewsRepo = new Mock<IEntityFrameworkRepository<Review>>();
            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();

            //Act & Assert
            Assert.That(() => new ShishaTimeData(mockedContext.Object,
                                                 null,
                                                 mockedUsersRepo.Object,
                                                 mockedRegionsRepo.Object,
                                                 mockedReviewsRepo.Object,
                                                 mockedRatingsRepo.Object),
                Throws.ArgumentNullException.With.Message.Contains("Bars repository cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUsersRepositoryIsNull()
        {
            //Arrange
            var mockedContext = new Mock<IShishaTimeDbContext>();
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            var mockedRegionsRepo = new Mock<IEntityFrameworkRepository<Region>>();
            var mockedReviewsRepo = new Mock<IEntityFrameworkRepository<Review>>();
            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ShishaTimeData(mockedContext.Object,
                                                                          mockedBarsRepo.Object,
                                                                          null,
                                                                          mockedRegionsRepo.Object,
                                                                          mockedReviewsRepo.Object,
                                                                          mockedRatingsRepo.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenUsersRepositoryIsNull()
        {
            //Arrange
            var mockedContext = new Mock<IShishaTimeDbContext>();
            var mockedBarssRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            var mockedRegionsRepo = new Mock<IEntityFrameworkRepository<Region>>();
            var mockedReviewsRepo = new Mock<IEntityFrameworkRepository<Review>>();
            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();

            //Act & Assert
            Assert.That(() => new ShishaTimeData(mockedContext.Object,
                                                 mockedBarssRepo.Object,
                                                 null,
                                                 mockedRegionsRepo.Object,
                                                 mockedReviewsRepo.Object,
                                                 mockedRatingsRepo.Object),
                Throws.ArgumentNullException.With.Message.Contains("Users repository cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenRegionsRepositoryIsNull()
        {
            //Arrange
            var mockedContext = new Mock<IShishaTimeDbContext>();
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            var mockedUsersRepo = new Mock<IEntityFrameworkRepository<User>>();
            var mockedReviewsRepo = new Mock<IEntityFrameworkRepository<Review>>();
            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ShishaTimeData(mockedContext.Object,
                                                                          mockedBarsRepo.Object,
                                                                          mockedUsersRepo.Object,
                                                                          null,
                                                                          mockedReviewsRepo.Object,
                                                                          mockedRatingsRepo.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenRegionsRepositoryIsNull()
        {
            //Arrange
            var mockedContext = new Mock<IShishaTimeDbContext>();
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            var mockedUsersRepo = new Mock<IEntityFrameworkRepository<User>>();
            var mockedReviewsRepo = new Mock<IEntityFrameworkRepository<Review>>();
            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();

            //Act & Assert
            Assert.That(() => new ShishaTimeData(mockedContext.Object,
                                                 mockedBarsRepo.Object,
                                                 mockedUsersRepo.Object,
                                                 null,
                                                 mockedReviewsRepo.Object,
                                                 mockedRatingsRepo.Object),
                Throws.ArgumentNullException.With.Message.Contains("Regions repository cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenReviewsRepositoryIsNull()
        {
            //Arrange
            var mockedContext = new Mock<IShishaTimeDbContext>();
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            var mockedUsersRepo = new Mock<IEntityFrameworkRepository<User>>();
            var mockedRegionsRepo = new Mock<IEntityFrameworkRepository<Region>>();
            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ShishaTimeData(mockedContext.Object,
                                                                          mockedBarsRepo.Object,
                                                                          mockedUsersRepo.Object,
                                                                          mockedRegionsRepo.Object,
                                                                          null,
                                                                          mockedRatingsRepo.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenReviewsRepositoryIsNull()
        {
            //Arrange
            var mockedContext = new Mock<IShishaTimeDbContext>();
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            var mockedUsersRepo = new Mock<IEntityFrameworkRepository<User>>();
            var mockedRegionsRepo = new Mock<IEntityFrameworkRepository<Region>>();
            var mockedRatingsRepo = new Mock<IEntityFrameworkRepository<Rating>>();

            //Act & Assert
            Assert.That(() => new ShishaTimeData(mockedContext.Object,
                                                 mockedBarsRepo.Object,
                                                 mockedUsersRepo.Object,
                                                 mockedRegionsRepo.Object,
                                                 null,
                                                 mockedRatingsRepo.Object),
                Throws.ArgumentNullException.With.Message.Contains("Reviews repository cannot be null."));
        }

        [Test]
        public void ThrowArgumentNullException_WhenRatingsRepositoryIsNull()
        {
            //Arrange
            var mockedContext = new Mock<IShishaTimeDbContext>();
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            var mockedUsersRepo = new Mock<IEntityFrameworkRepository<User>>();
            var mockedRegionsRepo = new Mock<IEntityFrameworkRepository<Region>>();
            var mockedReviewsRepo = new Mock<IEntityFrameworkRepository<Review>>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ShishaTimeData(mockedContext.Object,
                                                                          mockedBarsRepo.Object,
                                                                          mockedUsersRepo.Object,
                                                                          mockedRegionsRepo.Object,
                                                                          mockedReviewsRepo.Object,
                                                                          null));
        }

        [Test]
        public void ThrowArgumentNullException_WithCorrectMessage_WhenRatingsRepositoryIsNull()
        {
            //Arrange
            var mockedContext = new Mock<IShishaTimeDbContext>();
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            var mockedUsersRepo = new Mock<IEntityFrameworkRepository<User>>();
            var mockedRegionsRepo = new Mock<IEntityFrameworkRepository<Region>>();
            var mockedReviewsRepo = new Mock<IEntityFrameworkRepository<Review>>();

            //Act & Assert
            Assert.That(() => new ShishaTimeData(mockedContext.Object,
                                                 mockedBarsRepo.Object,
                                                 mockedUsersRepo.Object,
                                                 mockedRegionsRepo.Object,
                                                 mockedReviewsRepo.Object,
                                                 null),
                Throws.ArgumentNullException.With.Message.Contains("Ratings repository cannot be null."));
        }
    }
}
