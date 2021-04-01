using AutoFixture;
using EfTestApi.V1.Domain;
using EfTestApi.V1.Factories;
using EfTestApi.V1.Infrastructure;
using FluentAssertions;
using NUnit.Framework;

namespace EfTestApi.Tests.V1.Factories
{
    [TestFixture]
    public class EntityFactoryTest
    {
        private readonly Fixture _fixture = new Fixture();

        //TODO: add assertions for all the fields being mapped in `EntityFactory.ToDomain()`. Also be sure to add test cases for
        // any edge cases that might exist.
        [Test]
        public void CanMapADatabaseEntityToADomainObject()
        {
            var databaseEntity = _fixture.Create<CustomerDbEntity>();
            var entity = databaseEntity.ToDomain();

            databaseEntity.CustomerId.Should().Be(entity.CustomerId);
            databaseEntity.CreateDate.Should().BeSameDateAs(entity.CreateDate);
        }
    }
}
