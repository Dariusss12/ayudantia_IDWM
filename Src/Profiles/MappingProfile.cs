using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ayudantia_IDWM.Src.DTOs;
using proy_ayudantía.Src.Models;

namespace ayudantia_IDWM.Src.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}