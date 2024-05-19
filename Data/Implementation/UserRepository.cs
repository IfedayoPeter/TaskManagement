using Microsoft.AspNetCore.Identity;
using TaskManagement.Data.Interface;
using TaskManagement.Domain.Model;

namespace TaskManagement.Data.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IDbContext _context;
        public UserRepository(IDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _context = context;
        }
        public async Task<User> CreateUser(User user)
        {
            user.Password = _passwordHasher.HashPassword(user, user.Password);
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

    }
}