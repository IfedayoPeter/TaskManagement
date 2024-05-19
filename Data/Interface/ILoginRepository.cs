using TaskManagement.Domain.Model;

namespace TaskManagement.Data.Interface
{
    public interface ILoginRepository
    {
         Task<string> UserLogin(Login login);
    }
}