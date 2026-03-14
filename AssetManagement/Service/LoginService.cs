using AssetManagement.Models;
using AssetManagement.Repository;

namespace AssetManagement.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<Login> RegisterLogin(Login login)
        {
            return await _loginRepository.RegisterLogin(login);
        }

        public async Task<User> RegisterUser(User user)
        {
            return await _loginRepository.RegisterUser(user);
        }

        public async Task<Login> ValidateUserService(string UserName, string password)
        {
           return await _loginRepository.ValidateUser(UserName, password);  
        }
    }
}
