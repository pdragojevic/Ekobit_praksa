using Business.Services.Interfaces;
using Business.Services.Models;
using Data.Functions.CRUD;
using Data.Functions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Business.Services.Models.City;

namespace Business.Services.Implementation
{
    public class City_Service : ICity_Service
    {
        private ICRUD _crud = new CRUD();

        /// <summary>
        /// Adds an new City to the database.
        /// </summary>
        /// <param name="zip_code"></param>
        /// <param name="city_name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<City_ResultSet>> AddCity(string zip_code, string city_name)
        {
            Generic_ResultSet<City_ResultSet> result = new();
            try
            {
                City City = new City
                {
                    ZipCode = zip_code,
                    CityName = city_name
                };

                City = await _crud.Create<City>(City);

                City_ResultSet cityAdded = new City_ResultSet
                {
                    zip_code = City.ZipCode,
                    city_name = City.CityName
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("City {0} was added successfully", city_name);
                result.internalMessage = "LOGIC.Services.Implementation.City_Service: AddCity() method executed successfully.";
                result.result_set = cityAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the city supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.City_Service: AddUser(): {0}", exception.Message); ;
            }
            return result;
        }


        /// <summary>
        /// Gets all Users that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<City_ResultSet>>> GetAllCities()
        {
            Generic_ResultSet<List<City_ResultSet>> result = new();
            try
            {
                //GET ALL GRADES
                List<City> Cities = await _crud.ReadAll<City>();
                //MAP DB GRADE RESULTS
                result.result_set = new List<City_ResultSet>();
                Cities.ForEach(c => {
                    result.result_set.Add(new City_ResultSet
                    {
                        zip_code = c.ZipCode,
                        city_name = c.CityName
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All cities obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.User_Service: GetAllCities() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required cities from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Cities_Service: GetAllUsers(): {0}", exception.Message);
            }
            return result;
        }


        /// <summary>
        /// Deletes selected City that exist in the database
        /// </summary>
        /// <param name="zip_code"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<City_ResultSet>> DeleteCity(string zip_code)
        {
            Generic_ResultSet<City_ResultSet> result = new();
            try
            {
                City City = await _crud.Read<City>(zip_code);
                bool action = await _crud.Delete<City>(zip_code);

                City_ResultSet cityDeleted = new City_ResultSet
                {
                    zip_code = City.ZipCode,
                    city_name = City.CityName
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Deleted city {0} successfully", zip_code);
                result.internalMessage = "LOGIC.Services.Implementation.City_Service: DeleteCity() method executed successfully.";
                result.result_set = cityDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "Failed to delete";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.City_Service: DeleteCity(): {0}", exception.Message);
            }
            return result;
        }
    }
}
