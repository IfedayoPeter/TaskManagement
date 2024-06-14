using Microsoft.AspNetCore.Identity;
using TaskManagement.Domain.Model;

namespace TaskManagement.Data.Interface
{
    public interface IUserRepository
    {
         Task<User> CreateUser(User user);
         Task<User> GetUserByCode(string userCode);
    }
}