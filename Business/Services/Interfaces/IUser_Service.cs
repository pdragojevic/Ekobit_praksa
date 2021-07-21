using Business.Services.Models;
using Business.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IUser_Service
    {
        Task<UserForCreateDto> AddUser(UserForCreateDto user);
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetSingleUser(string user_name, string password);
        Task<UserForCreateDto> DeleteUser(string user_name);
    }
}
