using NUnit.Framework;
using ShishaTime.Web.Controllers;
using TestStack.FluentMVCTesting;

namespace ShishaTime.Web.Tests.Controllers.ErrorPagesControllerTests
{
    [TestFixture]
    public class Page401_Should
    {
        [Test]
        public void ReturnDefaultView()
        {
            //Arrange
            var controller = new ErrorPagesController();

            //Act & Assert
            controller.WithCallTo(c => c.Page401())
                .ShouldRenderDefaultView();
        }
    }
}
