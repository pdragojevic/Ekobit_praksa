using AutoMapper;
using Business.Services.Interfaces;
using Business.Services.Models.User;
using Data.Entities;
using Data.Functions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Implementation
{
    public class User_Service : IUser_Service
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IMapper _mapper;

        public User_Service(IGenericRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds an new User to the database.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<UserForCreateDto> AddUser(UserForCreateDto user)
        {
            User User = _mapper.Map<User>(user);

            _repository.Insert(User);
            _repository.Save();

            return _mapper.Map<UserForCreateDto>(User);
        }

        /// <summary>
        /// Gets all Users that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserDto>> GetAllUsers()
        {
            List<User> Users = await _repository.GetAll().Include(c => c.City).ToListAsync();

            return _mapper.Map<List<UserDto>>(Users);
        }

        /// <summary>
        /// Gets selected User that exist in the database
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public async Task<UserDto> GetSingleUser(string user_name)
        {
            //User User = _user_Operations.ReadUser(user_name);
            var User = await _repository.GetAll().Include(c => c.City).FirstOrDefaultAsync(u => u.UserName == user_name);

            return _mapper.Map<UserDto>(User);
        }

        /// <summary>
        /// Updates User that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<UserDto> UpdateUser(UserForCreateDto user)
        {
            User User = _mapper.Map<User>(user);

            _repository.Update(User);
            _repository.Save();

            return _mapper.Map<UserDto>(User);
        }

        /// <summary>
        /// Deletes selected User that exist in the database
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public async Task<UserForCreateDto> DeleteUser(string user_name)
        {
            User User = _repository.GetById(user_name);
            _repository.Delete(user_name);
            _repository.Save();

            return _mapper.Map<UserForCreateDto>(User);
        }
    }
}
