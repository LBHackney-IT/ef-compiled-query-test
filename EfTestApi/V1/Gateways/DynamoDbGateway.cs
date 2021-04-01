using Amazon.DynamoDBv2.DataModel;
using EfTestApi.V1.Domain;
using EfTestApi.V1.Factories;
using EfTestApi.V1.Infrastructure;
using System.Collections.Generic;

namespace EfTestApi.V1.Gateways
{
    public class DynamoDbGateway : IExampleGateway
    {
        private readonly IDynamoDBContext _dynamoDbContext;

        public DynamoDbGateway(IDynamoDBContext dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext;
        }

        public List<CustomerEntity> GetAll()
        {
            return new List<CustomerEntity>();
        }

        public CustomerEntity GetEntityById(int id)
        {
            var result = _dynamoDbContext.LoadAsync<CustomerDbEntity>(id).GetAwaiter().GetResult();
            return result?.ToDomain();
        }
    }
}
