using EfTestApi.V1.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace EfTestApi.Tests.V1.Controllers
{
    [TestFixture]
    public class HelloControllerTests
    {
        private HelloController _classUnderTest;

        public HelloControllerTests()
        {
            _classUnderTest = new HelloController();
        }

        [TestCase(TestName = "When the Hello Controller Get action is called it returns a successful (200) response")]
        public void HelloControllerGetActionReturnsSuccess()
        {
            // arrange

            // act
            var response = _classUnderTest.GetHello() as OkObjectResult;

            // assert
            response.StatusCode.Should().Be(200);
        }

    }
}
