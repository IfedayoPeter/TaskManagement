using TaskManagement.Domain.DTOS;
using TaskManagement.Service.Helpers;

namespace TaskManagement.Service.Interface
{
    public interface ILoginService
    {
         Task<Result<string>> UserLogin(LoginDTO loginDTO);
    }
}