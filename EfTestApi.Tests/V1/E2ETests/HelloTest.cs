using System;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using FluentAssertions;

namespace EfTestApi.Tests.V1.E2ETests
{
    [TestFixture]
    public class HelloTest : IntegrationTests<Startup>
    {
        [SetUp]
        public void SetUp()
        {

        }

        [TestCase(TestName = "Calling the hello endpoint returns an ok response")]
        public void HelloEndpiontTest()
        {
            // arrange
            var request = new Uri("api/v1/hello", UriKind.Relative);

            // act
            var response = Client.GetAsync(request).Result;

            // assert
            response.StatusCode.Should().Be(200);
        }
    }
}
