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
        private readonly IGenericRepository<User> repository;
        private readonly IUser_Operations _user_Operations;
        private readonly IMapper _mapper;

        public User_Service(IGenericRepository<User> repository, IUser_Operations user_Operations, IMapper mapper)
        {
            this.repository = repository;
            _user_Operations = user_Operations;
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

            repository.Insert(User);
            repository.Save();

            return _mapper.Map<UserForCreateDto>(User);
        }

        /// <summary>
        /// Gets all Users that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserDto>> GetAllUsers()
        {
            List<User> Users = await repository.GetAll().Include(c => c.City).ToListAsync();

            return _mapper.Map<List<UserDto>>(Users);
        }

        /// <summary>
        /// Gets selected User that exist in the database
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public async Task<UserDto> GetSingleUser(string user_name)
        {
            User User = _user_Operations.ReadUser(user_name);

            return _mapper.Map<UserDto>(User);
        }

        /// <summary>
        /// Deletes selected User that exist in the database
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public async Task<UserForCreateDto> DeleteUser(string user_name)
        {
            User User = repository.GetById(user_name);
            repository.Delete(user_name);
            repository.Save();

            return _mapper.Map<UserForCreateDto>(User);
        }
    }
}
