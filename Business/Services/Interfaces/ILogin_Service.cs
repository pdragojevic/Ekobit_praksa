using Business.Services.Models.User;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface ILogin_Service
    {
        Task<UserDto> Login(UserDtoLogin user);
    }
}
