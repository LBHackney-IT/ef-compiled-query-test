using System.Linq;
using AutoFixture;
using EfTestApi.V1.Boundary.Response;
using EfTestApi.V1.Domain;
using EfTestApi.V1.Factories;
using EfTestApi.V1.Gateways;
using EfTestApi.V1.UseCase;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace EfTestApi.Tests.V1.UseCase
{
    public class GetAllUseCaseTests
    {
        private Mock<IExampleGateway> _mockGateway;
        private GetAllUseCase _classUnderTest;
        private Fixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _mockGateway = new Mock<IExampleGateway>();
            _classUnderTest = new GetAllUseCase(_mockGateway.Object);
            _fixture = new Fixture();
        }

        [Test]
        public void GetsAllFromTheGateway()
        {
            var stubbedEntities = _fixture.CreateMany<CustomerEntity>().ToList();
            _mockGateway.Setup(x => x.GetAll()).Returns(stubbedEntities);

            var expectedResponse = new ResponseObjectList { Customers = stubbedEntities.ToResponse() };

            _classUnderTest.Execute().Should().BeEquivalentTo(expectedResponse);
        }
    }
}
