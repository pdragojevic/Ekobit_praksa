using Business.Services.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface ILogin_Service
    {
        Task<UserDto> Login(UserDtoLogin user);
    }
}
