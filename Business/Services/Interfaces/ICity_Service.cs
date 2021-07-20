using Business.Services.Models;
using Business.Services.Models.City;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface ICity_Service
    {
        Task<City> AddCity(string zip_code, string city_name);
        Task<IEnumerable<City>> GetAllCities();
        Task<City> DeleteCity(string zip_code);
    }
}
