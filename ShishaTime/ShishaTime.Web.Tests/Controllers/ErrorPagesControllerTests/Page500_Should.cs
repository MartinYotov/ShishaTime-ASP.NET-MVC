using NUnit.Framework;
using ShishaTime.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace ShishaTime.Web.Tests.Controllers.ErrorPagesControllerTests
{
    [TestFixture]
    public class Page500_Should
    {
        [Test]
        public void ReturnDefaultView()
        {
            //Arrange
            var controller = new ErrorPagesController();

            //Act & Assert
            controller.WithCallTo(c => c.Page500())
                .ShouldRenderView("Page500");
        }
    }
}
