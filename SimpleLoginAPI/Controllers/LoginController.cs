using Business.Services.Interfaces;
using Business.Services.Models.Login;
using Business.Services.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SimpleLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILogin_Service _login_service;

        public LoginController(ILogin_Service login_Service)
        {
            _login_service = login_Service;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<UserDto>> Login(AuthenticateRequest model)
        {
            var result = await _login_service.Login(model);
            if (result != null) return Ok(result);
            else return Unauthorized();
        }
    }
}
