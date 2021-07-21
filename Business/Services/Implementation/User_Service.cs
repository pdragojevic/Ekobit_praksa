using Business.Services.Interfaces;
using Business.Services.Models;
using Business.Services.Models.User;
using Data.Functions.CRUD;
using Data.Functions.Specific;
using Data.Functions.Interfaces;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

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
            //User User = new User
            //{
            //    UserName = user.UserName,
            //    Password = user.Password,
            //    FirstName = user.FirstName,
            //    LastName = user.LastName,
            //    ZipCode = user.ZipCode
            //};

            User User = _mapper.Map<User>(user);

            repository.Insert(User);
            repository.Save();

            //UserForCreateDto userAdded = new UserForCreateDto
            //{
            //    user_name = User.UserName,
            //    password = User.Password,
            //    first_name = User.FirstName,
            //    last_name = User.LastName,
            //    zip_code = User.ZipCode
            //};
            return _mapper.Map<UserForCreateDto>(User);
        }

        /// <summary>
        /// Gets all Users that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserDto>> GetAllUsers()
        {
            List<User> Users = await _user_Operations.ReadAllUsers();

            //Users.ForEach(u => {
            //    result.result_set.Add(new UserDto
            //    {
            //        user_name = u.UserName,
            //        password = u.Password,
            //        first_name = u.FirstName,
            //        last_name = u.LastName,
            //        city_name = u.City.CityName
            //    });
            //});
            return _mapper.Map<List<UserDto>>(Users);
        }

        /// <summary>
        /// Gets selected User that exist in the database
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<UserDto> GetSingleUser(string user_name, string password)
        {
            User User = _user_Operations.ReadUser(user_name);

            if (User.Password == password)
            {
                return _mapper.Map<UserDto>(User);
            }
            UserDto emptyUser = new UserDto();
            return emptyUser;
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
