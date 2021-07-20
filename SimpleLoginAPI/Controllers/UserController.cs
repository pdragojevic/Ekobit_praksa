using AutoMapper;
using Business.Services.Interfaces;
using Business.Services.Models.User;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<UserForCreateDto>> AddUser(UserForCreateDto user)
        {
            var result = await _user_service.AddUser(user.user_name, user.password, user.first_name, user.last_name, user.zip_code);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            var result = await _user_service.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("{user_name}")]
        public async Task<ActionResult<UserDto>> Login(string user_name, string password)
        {
            var result = await _user_service.GetSingleUser(user_name, password);
            return result;
        }

        [HttpDelete("{user_name}")]
        public async Task<ActionResult> Delete(string user_name)
        {
            var result = await _user_service.DeleteUser(user_name);
            return Ok(result);
        }
    }
}
