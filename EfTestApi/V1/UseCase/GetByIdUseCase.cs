using EfTestApi.V1.Boundary.Response;
using EfTestApi.V1.Factories;
using EfTestApi.V1.Gateways;
using EfTestApi.V1.UseCase.Interfaces;

namespace EfTestApi.V1.UseCase
{
    //TODO: Rename class name and interface name to reflect the entity they are representing eg. GetClaimantByIdUseCase
    public class GetByIdUseCase : IGetByIdUseCase
    {
        private IExampleGateway _gateway;
        public GetByIdUseCase(IExampleGateway gateway)
        {
            _gateway = gateway;
        }

        //TODO: rename id to the name of the identifier that will be used for this API, the type may also need to change
        public CustomerRO Execute(int id)
        {
            return _gateway.GetEntityById(id).ToResponse();
        }
    }
}
