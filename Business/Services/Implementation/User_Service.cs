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

namespace Business.Services.Implementation
{
    public class User_Service:IUser_Service
    {
        private ICRUD _crud = new CRUD();
        private IUser_Operations _user_Operations = new User_Operations();

        /// <summary>
        /// Adds an new User to the database.
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="password"></param>
        /// <param name="first_name"></param>
        /// <param name="last_name"></param>
        /// <param name="zip_code"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<User_ResultSet>> AddUser(string user_name, string password, string first_name, string last_name, string zip_code)
        {
            Generic_ResultSet<User_ResultSet> result = new();
            try
            {
                User User = new User
                {
                    UserName = user_name,
                    Password = password,
                    FirstName = first_name,
                    LastName = last_name,
                    ZipCode = zip_code
                };

                User = await _crud.Create<User>(User);

                User_ResultSet userAdded = new User_ResultSet
                {
                    user_name = User.UserName,
                    password = User.Password,
                    first_name = User.FirstName,
                    last_name = User.LastName,
                    city_name = User.ZipCode
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("User {0} was added successfully", user_name);
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: AddUser() method executed successfully.";
                result.result_set = userAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the user supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: AddUser(): {0}", exception.Message); ;
            }
            return result;
        }

        /// <summary>
        /// Gets all Users that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<User_ResultSet>>> GetAllUsers()
        {
            Generic_ResultSet<List<User_ResultSet>> result = new();
            try
            {
                //List<User> Users = await _crud.ReadAll<User>();
                List<User> Users = await _user_Operations.ReadAllUsers();
                result.result_set = new List<User_ResultSet>();
                Users.ForEach(u => {
                    result.result_set.Add(new User_ResultSet
                    {
                        user_name = u.UserName,
                        password = u.Password,
                        first_name = u.FirstName,
                        last_name = u.LastName,
                        city_name = u.City.CityName
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All users obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: GetAllUsers() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required users from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: GetAllUsers(): {0}", exception.Message);
            }
            return result;
        }

        /// <summary>
        /// Gets selected User that exist in the database
        /// </summary>
        /// <param name="user_name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<User_ResultSet>> GetSingleUser(string user_name, string password)
        {
            Generic_ResultSet<User_ResultSet> result = new();
            try
            {
                User User = await _crud.Read<User>(user_name);

                if(User.Password == password)
                {
                    User_ResultSet userRetrived = new User_ResultSet
                    {
                        user_name = User.UserName,
                        password = User.Password,
                        first_name = User.FirstName,
                        last_name = User.LastName,
                        city_name = User.ZipCode
                    };

                    //SET SUCCESSFUL RESULT VALUES
                    result.userMessage = string.Format("Logged in successfully");
                    result.internalMessage = "LOGIC.Services.Implementation.User_Service: Login() method executed successfully.";
                    result.result_set = userRetrived;
                    result.success = true;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Username doesn't match password";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: GetSingleUser(): {0}", exception.Message);
            }
            return result;
        }

        /// <summary>
        /// Deletes selected User that exist in the database
        /// </summary>
        /// <param name="user_name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<User_ResultSet>> DeleteUser(string user_name)
        {
            Generic_ResultSet<User_ResultSet> result = new();
            try
            {
                User User = await _crud.Read<User>(user_name);
                bool action = await _crud.Delete<User>(user_name);

                User_ResultSet userDeleted = new User_ResultSet
                {
                    user_name = User.UserName,
                    password = User.Password,
                    first_name = User.FirstName,
                    last_name = User.LastName,
                    city_name = User.ZipCode
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Deleted user {0} successfully", user_name);
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: DeleteUser() method executed successfully.";
                result.result_set = userDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to delete";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.User_Service: DeleteUser(): {0}", exception.Message);
            }
            return result;
        }
    }
}
