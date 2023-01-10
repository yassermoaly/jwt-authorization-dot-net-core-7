using ServiceLayer.Interfaces;
using Models.View;
using System.Security.Claims;

namespace ServiceLayer
{
    public class UserService : IUserService
    {
        private readonly ITokenService _tokenService;
        public UserService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public LoginResponse Login(LoginRequest Request)
        {
            if(Request.UserName == "admin" && Request.Password == "admin") {
                var Claims = new Dictionary<string, string>();
                Claims.Add(ClaimTypes.Role,"admin");
                Claims.Add(ClaimTypes.Name, "admin");
                Claims.Add("Sex", "Male");
                Claims.Add("Id", "9123");
                return LoginResponse.CreateSuccess(_tokenService.Create(Claims));
            }
            return LoginResponse.CreateFailed();
        }
    }
}
