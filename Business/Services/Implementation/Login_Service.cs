using AutoMapper;
using Business.Services.Interfaces;
using Business.Services.Models.User;
using Data.Entities;
using Data.Functions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementation
{
    public class Login_Service:ILogin_Service
    {
        private readonly IUser_Operations _user_Operations;
        private readonly IMapper _mapper;

        public Login_Service(IUser_Operations user_Operations, IMapper mapper)
        {
            this._user_Operations = user_Operations;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets selected User that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<UserDto> Login(UserDtoLogin user)
        {
            User User = _user_Operations.ReadUser(user.UserName);

            if (User.Password == user.Password)
            {
                return _mapper.Map<UserDto>(User);
            }
            UserDto emptyUser = new UserDto();
            return emptyUser;
        }
    }
}
