using AutoFixture;
using EfTestApi.Tests.V1.Helper;
using EfTestApi.V1.Domain;
using EfTestApi.V1.Gateways;
using FluentAssertions;
using NUnit.Framework;

namespace EfTestApi.Tests.V1.Gateways
{
    //TODO: Remove this file if Postgres gateway is not being used
    //TODO: Rename Tests to match gateway name
    //For instruction on how to run tests please see the wiki: https://github.com/LBHackney-IT/lbh-ef-test-api/wiki/Running-the-test-suite.
    [TestFixture]
    public class ExampleGatewayTests : DatabaseTests
    {
        private readonly Fixture _fixture = new Fixture();
        private ExampleGateway _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new ExampleGateway(DatabaseContext);
        }

        [Test]
        public void GetEntityByIdReturnsNullIfEntityDoesntExist()
        {
            var response = _classUnderTest.GetEntityById(123);

            response.Should().BeNull();
        }

        [Test]
        public void GetEntityByIdReturnsTheEntityIfItExists()
        {
            var entity = _fixture.Create<CustomerEntity>();
            var databaseEntity = DatabaseEntityHelper.CreateDatabaseEntityFrom(entity);

            DatabaseContext.CustomerEntities.Add(databaseEntity);
            DatabaseContext.SaveChanges();

            var response = _classUnderTest.GetEntityById(databaseEntity.CustomerId);

            databaseEntity.CustomerId.Should().Be(response.CustomerId);
            databaseEntity.CreateDate.Should().BeSameDateAs(response.CreateDate);
        }
    }
}
