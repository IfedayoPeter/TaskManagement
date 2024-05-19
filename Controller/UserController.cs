using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.DTOS;
using TaskManagement.Service.Interface;

namespace UserManagement.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // [HttpGet("/getAllUser")]
        // public async User<IActionResult> GetAllUser()
        // {
        //     var result = await _userService.GetAllUser();
        //     return Ok(result);
        // }
        // [HttpGet("/getUserById")]
        // public async User<IActionResult> GetUserById(string UserCode)
        // {
        //     var result = await _userService.GetUserById(UserCode);
        //     return Ok(result);
        // }

        [HttpPost("/createUser")]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            var result = await _userService.CreateUser(userDTO);
            return Ok(result);
        }

        // [HttpPut("/UpdateUser")]
        // public async Task<IActionResult> UpdateUser(string userCode, UserDTO usersDTO)
        // {
        //     var result = await _userService.UpdateUser(userCode, usersDTO);
        //     return Ok(result);
        // }

        // [HttpDelete("/deleteUser")]
        // public async Task<IActionResult> DeleteUser(string userCode)
        // {
        //     var result = await _userService.DeleteUser(userCode);
        //     return Ok(result);
        // }
    }
}