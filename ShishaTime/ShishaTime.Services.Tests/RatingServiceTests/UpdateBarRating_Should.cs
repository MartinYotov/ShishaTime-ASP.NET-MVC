using Moq;
using NUnit.Framework;
using ShishaTime.Data.Contracts;
using ShishaTime.Models;
using System;
using System.Collections.Generic;

namespace ShishaTime.Services.Tests.RatingServiceTests
{
    [TestFixture]
    public class UpdateBarRating_Should
    {
        [Test]
        public void CallDataBarsRepo()
        {
            //Arrange
            var bar = new ShishaBar()
            {
                Ratings = new List<Rating>()
                {
                    new Rating() { BarId = 2, UserId = "2", Value = 4  },
                    new Rating() { BarId = 1, UserId = "2", Value = 3  },
                    new Rating() { BarId = 1, UserId = "3", Value = 5  }
                }
            };
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(bar);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            mockedData.Setup(x => x.SaveChanges()).Verifiable();
            var service = new RatingService(mockedData.Object);

            //Act
            service.UpdateBarRating(1);

            //Assert
            mockedData.Verify(x => x.Bars, Times.Once());
        }

        [Test]
        public void CallDataBarsRepo_GetByIdMethod()
        {
            //Arrange
            var bar = new ShishaBar()
            {
                Ratings = new List<Rating>()
                {
                    new Rating() { BarId = 2, UserId = "2", Value = 4  },
                    new Rating() { BarId = 1, UserId = "2", Value = 3  },
                    new Rating() { BarId = 1, UserId = "3", Value = 5  }
                }
            };
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(bar);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            mockedData.Setup(x => x.SaveChanges()).Verifiable();
            var service = new RatingService(mockedData.Object);

            //Act
            service.UpdateBarRating(1);

            //Assert
            mockedBarsRepo.Verify(x => x.GetById(It.IsAny<int>()), Times.Once());
        }

        [Test]
        public void CallDataBarsRepo_GetByIdMethod_WithCorrectId()
        {
            //Arrange
            var bar = new ShishaBar()
            {
                Ratings = new List<Rating>()
                {
                    new Rating() { BarId = 2, UserId = "2", Value = 4  },
                    new Rating() { BarId = 1, UserId = "2", Value = 3  },
                    new Rating() { BarId = 1, UserId = "3", Value = 5  }
                }
            };
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(bar);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            mockedData.Setup(x => x.SaveChanges()).Verifiable();
            var service = new RatingService(mockedData.Object);

            //Act
            service.UpdateBarRating(1);

            //Assert
            mockedBarsRepo.Verify(x => x.GetById(1), Times.Once());
        }

        [Test]
        public void CallData_SaveChangesMethod()
        {
            //Arrange
            var bar = new ShishaBar()
            {
                Ratings = new List<Rating>()
                {
                    new Rating() { BarId = 2, UserId = "2", Value = 4  },
                    new Rating() { BarId = 1, UserId = "2", Value = 3  },
                    new Rating() { BarId = 1, UserId = "3", Value = 5  }
                }
            };
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(bar);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            mockedData.Setup(x => x.SaveChanges()).Verifiable();
            var service = new RatingService(mockedData.Object);

            //Act
            service.UpdateBarRating(1);

            //Assert
            mockedData.Verify(x => x.SaveChanges(), Times.Once());
        }

        [Test]
        public void ReturnCorrectResult()
        {
            //Arrange
            var bar = new ShishaBar()
            {
                Ratings = new List<Rating>()
                {
                    new Rating() { BarId = 2, UserId = "2", Value = 5  },
                    new Rating() { BarId = 1, UserId = "2", Value = 2  },
                    new Rating() { BarId = 1, UserId = "3", Value = 5  }
                }
            };
            var mockedBarsRepo = new Mock<IEntityFrameworkRepository<ShishaBar>>();
            mockedBarsRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(bar);
            var mockedData = new Mock<IShishaTimeData>();
            mockedData.Setup(x => x.Bars).Returns(mockedBarsRepo.Object);
            mockedData.Setup(x => x.SaveChanges()).Verifiable();
            var service = new RatingService(mockedData.Object);

            //Act
            var result = service.UpdateBarRating(1);

            //Assert
            Assert.AreEqual(4, result);
        }
    }
}
