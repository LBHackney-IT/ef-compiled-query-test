using EfTestApi.V1.Boundary.Response;

namespace EfTestApi.V1.UseCase.Interfaces
{
    public interface IGetByIdUseCase
    {
        ResponseObject Execute(int id);
    }
}
