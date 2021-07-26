using Business.Services.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IUser_Service
    {
        Task<UserForCreateDto> AddUser(UserForCreateDto user);
        Task<List<UserDto>> GetAllUsers();
        Task<UserDto> GetSingleUser(string user_name);
        Task<UserDto> UpdateUser(UserForCreateDto user);
        Task<UserForCreateDto> DeleteUser(string user_name);
    }
}
