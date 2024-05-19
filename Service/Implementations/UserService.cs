using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TaskManagement.Data.Interface;
using TaskManagement.Domain.DTOS;
using TaskManagement.Domain.Model;
using TaskManagement.Service.Helpers;
using TaskManagement.Service.Interface;
using TaskManagement.Services.Helpers;

namespace TaskManagement.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Result<UserDTO>> CreateUser(UserDTO userDTO)
        {
            Result<UserDTO> result = new(false);

            try
            {
                userDTO.UserCode = new RandomGenerator().GenerateRandomCode(5);
                //map User to UserDTO
                var user = _mapper.Map<User>(userDTO);
                var response = await _userRepository.CreateUser(user);

                if (response != null)
                {
                    //map userDTO to response 
                    result.SetSuccess(_mapper.Map<UserDTO>(response), $"User Created Successfully !");
                }

                else
                {
                    result.SetError("User not created", "");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating User");
                result.SetError(ex.ToString(), "Error while creating User");
            }
            return result;
        }

    }

}
