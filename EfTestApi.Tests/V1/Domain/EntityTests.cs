using System;
using EfTestApi.V1.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace EfTestApi.Tests.V1.Domain
{
    [TestFixture]
    public class EntityTests
    {
        [Test]
        public void EntitiesHaveAnId()
        {
            var entity = new CustomerEntity();
            entity.CustomerId.Should().BeGreaterOrEqualTo(0);
        }

        [Test]
        public void EntitiesHaveACreatedAt()
        {
            var entity = new CustomerEntity();
            var date = new DateTime(2019, 02, 21);
            entity.CreateDate = date;

            entity.CreateDate.Should().BeSameDateAs(date);
        }
    }
}
