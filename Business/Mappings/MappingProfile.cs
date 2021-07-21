﻿using AutoMapper;
using Business.Services.Models.City;
using Business.Services.Models.User;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDto>()
                .ReverseMap();
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.CityName))
                .ReverseMap();
            CreateMap<User, UserForCreateDto>()
                .ReverseMap();
        }
    }
}
