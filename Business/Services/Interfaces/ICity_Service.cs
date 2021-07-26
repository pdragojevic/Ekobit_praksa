using Business.Services.Models.City;
using System.Collections.Generic;
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
