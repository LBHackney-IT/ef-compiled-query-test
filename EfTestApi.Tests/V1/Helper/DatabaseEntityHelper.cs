using AutoFixture;
using EfTestApi.V1.Domain;
using EfTestApi.V1.Infrastructure;

namespace EfTestApi.Tests.V1.Helper
{
    public static class DatabaseEntityHelper
    {
        public static CustomerDbEntity CreateDatabaseEntity()
        {
            var entity = new Fixture().Create<CustomerEntity>();

            return CreateDatabaseEntityFrom(entity);
        }

        public static CustomerDbEntity CreateDatabaseEntityFrom(CustomerEntity entity)
        {
            return new CustomerDbEntity
            {
                CustomerId = entity.CustomerId,
                CreateDate = entity.CreateDate
            };
        }
    }
}
