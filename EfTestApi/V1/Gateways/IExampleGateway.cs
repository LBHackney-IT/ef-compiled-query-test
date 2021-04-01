using System.Collections.Generic;
using EfTestApi.V1.Domain;

namespace EfTestApi.V1.Gateways
{
    public interface IExampleGateway
    {
        CustomerEntity GetEntityById(int id);

        List<CustomerEntity> GetAll();
    }
}
