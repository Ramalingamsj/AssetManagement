using AssetManagement.Models;
using AssetManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AssetManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _configuration;
        public LoginController(ILoginService loginService,IConfiguration configuration)
        {
            _configuration = configuration;
            _loginService = loginService;
        }
        [AllowAnonymous]
        [HttpGet("{UserName}/{Password}")]
        public async Task <IActionResult>Login(string UserName ,string Password)
        {
            IActionResult response = Unauthorized();
            Login login = null;
            login = await _loginService.ValidateUserService(UserName, Password);
            if (login != null)
            {
                var tokenString = GenerateJSONWebToken(login);
                response = Ok(new { 
                    Username = login.UserName,
                    userTypeType= login.UserTypeId,
                    token = tokenString 
                });
            }

            return response;
        }
        [HttpPost]
        [Route("RegisterLogin")]
        public async Task<Login> Register(Login login)
        {
            if (_loginService != null)
            {
                return await _loginService.RegisterLogin(login);
                
            }

            return null;
        }
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<User> RegisterUsers(User user)
        {

            if (_loginService != null)
            {
                return await _loginService.RegisterUser(user);
            }
            return null;
        }
        private string GenerateJSONWebToken(Login DbUser)
        {
            //1 Security key --appSettings
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            //2 define Alogorithm
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //3 Jwt token --payload
            var token = new JwtSecurityToken(
    issuer: _configuration["Jwt:Issuer"],
    audience: _configuration["Jwt:Audience"],
              null,
              expires: DateTime.Now.AddMinutes(20),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
