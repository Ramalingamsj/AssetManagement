using AssetManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Repository
{
    public interface ILoginRepository
    {
        public  Task<Login> ValidateUser(string UserName, string password);
        public  Task<Login> RegisterLogin(Login login);
        public  Task<User> RegisterUser(User user);
        
    }
}
