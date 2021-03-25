using System.Collections.Generic;
using EfTestApi.V1.Domain;

namespace EfTestApi.V1.Gateways
{
    public interface IExampleGateway
    {
        Entity GetEntityById(int id);

        List<Entity> GetAll();
    }
}
