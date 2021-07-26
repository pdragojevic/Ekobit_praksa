using AutoMapper;
using Business.Services.Interfaces;
using Business.Services.Models.City;
using Data.Entities;
using Data.Functions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Implementation
{
    public class City_Service : ICity_Service
    {
        private readonly IGenericRepository<City> _repository;
        private readonly IMapper _mapper;

        public City_Service(IGenericRepository<City> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Adds an new City to the database.
        /// </summary>
        /// <returns></returns>
        public async Task<CityDto> AddCity(CityDto city)
        {
            City City = _mapper.Map<City>(city);

            _repository.Insert(City);
            _repository.Save();

            return _mapper.Map<CityDto>(City);
        }


        /// <summary>
        /// Gets all Users that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CityDto>> GetAllCities()
        {
            var cities = await _repository
                .GetAll()
                .ToListAsync();

            return _mapper.Map<List<CityDto>>(cities);
        }


        /// <summary>
        /// Deletes selected City that exist in the database
        /// </summary>
        /// <param name="zip_code"></param>
        /// <returns></returns>
        public async Task<CityDto> DeleteCity(string zip_code)
        {
            City City = _repository.GetById(zip_code);

            _repository.Delete(zip_code);
            _repository.Save();

            return _mapper.Map<CityDto>(City);
        }
    }
}
