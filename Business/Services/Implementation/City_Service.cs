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
using Microsoft.EntityFrameworkCore;

namespace Business.Services.Implementation
{
    public class City_Service : ICity_Service
    {
        private IGenericRepository<City> repository;

        public City_Service(IGenericRepository<City> repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Adds an new City to the database.
        /// </summary>
        /// <param name="zip_code"></param>
        /// <param name="city_name"></param>
        /// <returns></returns>
        public async Task<City> AddCity(string zip_code, string city_name)
        {
            City City = new City
            {
                ZipCode = zip_code,
                CityName = city_name
            };

            repository.Insert(City);
            repository.Save();

            return City;
        }


        /// <summary>
        /// Gets all Users that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await repository
                .GetAll()
                .ToListAsync();
        }


        /// <summary>
        /// Deletes selected City that exist in the database
        /// </summary>
        /// <param name="zip_code"></param>
        /// <returns></returns>
        public async Task<City> DeleteCity(string zip_code)
        {
            City City = repository.GetById(zip_code);

            repository.Delete(zip_code);
            repository.Save();

            return City;
        }
    }
}
