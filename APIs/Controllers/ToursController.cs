using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models.View;
using ServiceLayer.Interfaces;
using System.Security.Claims;

namespace web_pairing_kit_dot_net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToursController : ControllerBase
    {
        private readonly ITourService _tourService;
        private readonly ITokenService _tokenService;
        public ToursController(ITourService tourService, ITokenService tokenService) {
            
            _tourService = tourService;
            _tokenService = tokenService;
        }    
        [HttpGet]
        [Route("filter")]
        public List<VmTour> Filter(string? keyword)
        {
            return _tourService.Filter(keyword);
        }
        [HttpGet]
        [Route("get/{Id}")]
        public VmTour Get(int Id)
        {
            return _tourService.Get(Id);
        }

       
    }
}
