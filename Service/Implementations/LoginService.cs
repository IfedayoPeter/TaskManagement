using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using TaskManagement.Data.Interface;
using TaskManagement.Domain.DTOS;
using TaskManagement.Domain.Model;
using TaskManagement.Service.Helpers;
using TaskManagement.Service.Interface;

namespace TaskManagement.Service.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<LoginService> _logger;

        public LoginService(ILoginRepository loginRepository, IMapper mapper, ILogger<LoginService> logger)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<string>> UserLogin(LoginDTO loginDTO)
        {
            Result<string> result = new(false);

            try
            {
                //map Login to loginDTO
                var login = _mapper.Map<Login>(loginDTO);
                var response = await _loginRepository.UserLogin(login);

                if (response == "Invalid login credentials")
                {
                    result.SetError("Invalid login credentials or user does not exist", "");
                    
                }

                else
                {
                    //map loginDTO to response 
                    result.SetSuccess(response, $"User logged in Successfully !");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Invalid login credentials or user does not exist");
                result.SetError(ex.ToString(), "Invalid login credentials or user does not exist");
            }
            return result;
        }

    }
}