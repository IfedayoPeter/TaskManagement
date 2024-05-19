using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Interface;
using TaskManagement.Domain.Model;

namespace TaskManagement.Data.Implementation
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtService _jwtService;
        public LoginRepository(IDbContext context, IPasswordHasher<User> passwordHasher,
        IJwtService jwtService)
        {
            _jwtService = jwtService;
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> UserLogin(Login login)
        {
            var user = await _context.User.SingleOrDefaultAsync(u => u.Email == login.Email);
            
            if (user != null && _passwordHasher.VerifyHashedPassword
            (user, user.Password, login.Password) == PasswordVerificationResult.Success)
            {
                return await _jwtService.GenerateJwtToken(login);
            }
            else
            {
                return "Invalid login credentials";
            }
        }

    }
}