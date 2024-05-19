using TaskManagement.Domain.Model;

namespace TaskManagement.Data.Interface
{
    public interface IJwtService
    {
         Task<string> GenerateJwtToken(Login login);
    }
}