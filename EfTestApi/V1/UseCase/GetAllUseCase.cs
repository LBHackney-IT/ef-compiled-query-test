using EfTestApi.V1.Boundary.Response;
using EfTestApi.V1.Factories;
using EfTestApi.V1.Gateways;
using EfTestApi.V1.UseCase.Interfaces;

namespace EfTestApi.V1.UseCase
{
    //TODO: Rename class name and interface name to reflect the entity they are representing eg. GetAllClaimantsUseCase
    public class GetAllUseCase : IGetAllUseCase
    {
        private readonly IExampleGateway _gateway;
        public GetAllUseCase(IExampleGateway gateway)
        {
            _gateway = gateway;
        }

        public ResponseObjectList Execute()
        {
            var gwResponse = _gateway.GetAll();
            return new ResponseObjectList { Customers = gwResponse.ToResponse() };
        }
    }
}
