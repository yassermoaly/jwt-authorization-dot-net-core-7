using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.View;
using ServiceLayer.Interfaces;
using System.Data;
using System.Security.Claims;

namespace web_pairing_kit_dot_net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("Login")]
        public LoginResponse Login(LoginRequest PostedRequest)
        {
            return _userService.Login(PostedRequest);
        }
        [HttpGet]
        [Route("GetAuthorizedMessage")]
        [Authorize(Roles = "admin")]
        public string GetAuthorizedMessage()
        {
            return "Authorized";
        }
    }
}
