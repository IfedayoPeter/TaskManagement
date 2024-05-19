using Microsoft.AspNetCore.Mvc;
using TaskManagement.Domain.DTOS;
using TaskManagement.Service.Interface;

namespace LoginManagement.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        // [HttpGet("/getAllLogin")]
        // public async Login<IActionResult> GetAllLogin()
        // {
        //     var result = await _loginService.GetAllLogin();
        //     return Ok(result);
        // }
        // [HttpGet("/getLoginById")]
        // public async Login<IActionResult> GetLoginById(string LoginCode)
        // {
        //     var result = await _loginService.GetLoginById(LoginCode);
        //     return Ok(result);
        // }

        [HttpPost("/UserLogin")]
        public async Task<IActionResult> UserLogin(LoginDTO loginDTO)
        {
            var result = await _loginService.UserLogin(loginDTO);
            return Ok(result);
        }

        // [HttpPut("/UpdateLogin")]
        // public async Task<IActionResult> UpdateLogin(string loginCode, LoginDTO loginsDTO)
        // {
        //     var result = await _loginService.UpdateLogin(loginCode, loginsDTO);
        //     return Ok(result);
        // }

        // [HttpDelete("/deleteLogin")]
        // public async Task<IActionResult> DeleteLogin(string loginCode)
        // {
        //     var result = await _loginService.DeleteLogin(loginCode);
        //     return Ok(result);
        // }
    }
}