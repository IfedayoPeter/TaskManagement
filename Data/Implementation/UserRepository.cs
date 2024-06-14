using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TaskManagement.Data.Interface;
using TaskManagement.Domain.Model;
using TaskManagement.Service.Helpers;

namespace TaskManagement.Data.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IDbContext _context;
        private readonly WebSocketHandler _webSocketHandler;
        public UserRepository(IDbContext context,
        WebSocketHandler webSocketHandler,
        IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _context = context;
            _webSocketHandler = webSocketHandler;
        }
        public async Task<User> CreateUser(User user)
        {
            user.Password = _passwordHasher.HashPassword(user, user.Password);
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        public async Task<User> GetUserByCode(string userCode)
        {
            var result = await _context.User
            .Where(x => x.UserCode == userCode)
            .FirstOrDefaultAsync();

            // Broadcast the task to all connected clients
            var taskJson = JsonConvert.SerializeObject(result, Formatting.Indented);
            await _webSocketHandler.BroadcastAsync(taskJson);


            return result;
        }

    }
}