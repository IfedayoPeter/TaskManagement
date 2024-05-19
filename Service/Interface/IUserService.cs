using Microsoft.AspNetCore.Identity;
using TaskManagement.Domain.DTOS;
using TaskManagement.Service.Helpers;

namespace TaskManagement.Service.Interface
{
    public interface IUserService
    {
        Task<Result<UserDTO>> CreateUser(UserDTO userDTO); 
    }
}