using Business.Services.Models;
using Business.Services.Models.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface ICity_Service
    {
        Task<Generic_ResultSet<City_ResultSet>> AddCity(string zip_code, string city_name);
        Task<Generic_ResultSet<List<City_ResultSet>>> GetAllCities();
        Task<Generic_ResultSet<City_ResultSet>> DeleteCity(string zip_code);
    }
}
