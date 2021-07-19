using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleLoginAPI.Models.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private ICity_Service _city_service;
        public CityController(ICity_Service city_Service)
        {
            _city_service = city_Service;
        }

        [HttpPost]
        public async Task<ActionResult<City_Object>> AddCity(City_Object city)
        {
            var result = await _city_service.AddCity(city.ZipCode, city.CityName);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        public async Task<ActionResult<City_Object>> GetAllCities()
        {
            var result = await _city_service.GetAllCities();
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpDelete("{zip_code}")]
        public async Task<ActionResult> Delete(string zip_code)
        {
            var result = await _city_service.DeleteCity(zip_code);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }
    }
}
