using AssetManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Service
{
    public interface ILoginService
    {
        public Task<Login> ValidateUserService(string UserName, string password);
        public Task<Login> RegisterLogin(Login login);
        public  Task<User> RegisterUser(User user);
        
    }
}
