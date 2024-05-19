using Microsoft.AspNetCore.Identity;
using TaskManagement.Domain.Model;

namespace TaskManagement.Data.Interface
{
    public interface IUserRepository
    {
         Task<User> CreateUser(User user);
    }
}