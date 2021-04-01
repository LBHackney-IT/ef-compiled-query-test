using EfTestApi.V1.Domain;
using EfTestApi.V1.Factories;
using NUnit.Framework;

namespace EfTestApi.Tests.V1.Factories
{
    public class ResponseFactoryTest
    {
        [Test]
        public void CanMapADatabaseEntityToADomainObject()
        {
            var domain = new CustomerEntity();
            var response = domain.ToResponse();
        }
    }
}
