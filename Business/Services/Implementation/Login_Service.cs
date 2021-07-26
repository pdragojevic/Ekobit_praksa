using AutoMapper;
using Business.Services.Interfaces;
using Business.Services.Models.User;
using Data.Entities;
using Data.Functions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Business.Services.Implementation
{
    public class Login_Service : ILogin_Service
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IMapper _mapper;

        public Login_Service(IMapper mapper, IGenericRepository<User> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Check if username match password
        /// </summary>
        /// <returns></returns>
        public async Task<UserDto> Login(UserDtoLogin user)
        {
            var User = await _repository.GetAll().Include(c => c.City).FirstOrDefaultAsync(u => u.UserName == user.UserName);
            UserDto emptyUser = new UserDto();

            if (User == null) { return emptyUser; }

            if (User.Password == user.Password)
            {
                return _mapper.Map<UserDto>(User);
            }

            return emptyUser;
        }
    }
}
