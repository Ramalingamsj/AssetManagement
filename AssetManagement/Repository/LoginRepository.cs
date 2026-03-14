using AssetManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AssetManagementContext _context;

        public LoginRepository(AssetManagementContext context)
        {
            _context = context;
        }

        // Register User
        public async Task<Login> RegisterLogin(Login login)
        {
            if (_context != null)
            {
                await _context.Logins.AddAsync(login);
                await _context.SaveChangesAsync();
                return login;
            }

            return null;
        }
        public async Task<User> RegisterUser(User user)
        {
            if (_context != null)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }

            return null;
        }

        // Validate Login
        public async Task<Login> ValidateUser(string UserName, string password)
        {
            if (_context != null)
            {
                Login? dblogin = await _context.Logins
                    .FirstOrDefaultAsync(l => l.UserName == UserName && l.Password == password);

                return dblogin;
            }

            return null;
        }
    }
}