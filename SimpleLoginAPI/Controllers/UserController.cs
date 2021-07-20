using AutoMapper;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleLoginAPI.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser_Service _user_service;
        private readonly IMapper _mapper;

        public UserController (IUser_Service user_Service, IMapper mapper)
        {
            _user_service = user_Service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<User_Object>> AddUser(User_Object user)
        {
            var result = await _user_service.AddUser(user.UserName, user.Password, user.FirstName, user.LastName, user.ZipCode);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        public async Task<ActionResult<User_Object>> GetAllUsers()
        {
            var result = await _user_service.GetAllUsers();
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet("{user_name}")]
        public async Task<ActionResult<User_Object>> Login(string user_name, string password)
        {
            var result = await _user_service.GetSingleUser(user_name, password);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return Unauthorized(result);
            }
        }

        [HttpDelete("{user_name}")]
        public async Task<ActionResult> Delete(string user_name)
        {
            var result = await _user_service.DeleteUser(user_name);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }
    }
}
