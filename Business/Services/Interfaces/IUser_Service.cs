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
        Task<Generic_ResultSet<UserForCreateDto>> AddUser(string user_name, string password, string first_name, string last_name, string zip_code);
        Task<Generic_ResultSet<List<UserDto>>> GetAllUsers();
        Task<Generic_ResultSet<UserDto>> GetSingleUser(string user_name, string password);
        Task<Generic_ResultSet<UserForCreateDto>> DeleteUser(string user_name);
    }
}
