using Business.Services.Interfaces;
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

        [HttpPost]
        public async Task<ActionResult<UserDto>> Login(UserDtoLogin user)
        {
            var result = await _login_service.Login(user);
            if (result.UserName != null) return Ok(result);
            else return Unauthorized();
        }
    }
}
