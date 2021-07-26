using Business.Services.Interfaces;
using Business.Services.Models.City;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICity_Service _city_service;

        public CityController(ICity_Service city_Service)
        {
            _city_service = city_Service;
        }

        [HttpPost]
        public async Task<ActionResult<CityDto>> AddCity(CityDto city)
        {
            var City = await _city_service.AddCity(city);
            return Ok(City);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetAllCities()
        {
            var cities = await _city_service.GetAllCities();
            return Ok(cities);
        }

        [HttpDelete("{zip_code}")]
        public async Task<ActionResult<CityDto>> Delete(string zip_code)
        {
            var City = await _city_service.DeleteCity(zip_code);
            return Ok(City);
        }
    }
}
