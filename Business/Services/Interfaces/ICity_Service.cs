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
        Task<CityDto> AddCity(CityDto city);
        Task<IEnumerable<CityDto>> GetAllCities();
        Task<CityDto> DeleteCity(string zip_code);
    }
}
