using Business.JWT;
using Business.Services.Interfaces;
using Business.Services.Models.User;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser_Service _user_service;

        public UserController(IUser_Service user_Service)
        {
            _user_service = user_Service;
        }

        [HttpPost]
        public async Task<ActionResult<UserForCreateDto>> AddUser(UserForCreateDto user)
        {
            var result = await _user_service.AddUser(user);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            var result = await _user_service.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("{user_name}")]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetUser(string user_name)
        {

            Thread.Sleep(200);
            var result = await _user_service.GetSingleUser(user_name);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> UpdateUser(UserForCreateDto user)
        {
            var result = await _user_service.UpdateUser(user);
            return Ok(result);
        }

        [HttpDelete("{user_name}")]
        public async Task<ActionResult> Delete(string user_name)
        {
            var result = await _user_service.DeleteUser(user_name);
            return Ok(result);
        }
    }
}
