using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ayudantia_IDWM.Src.DTOs;
using ayudantia_IDWM.Src.Services.Interfaces;
using proy_ayudantía.Src.Models;

namespace ayudantia_IDWM.Src.Services.Implements
{
    public class MapperService : IMapperService
    {
        private readonly IMapper _mapper;

        public MapperService(IMapper mapper)
        {
            _mapper = mapper;
        } 
        
        public User RegisterUserDtoToUser(RegisterUserDto registerUserDto)
        {
            var mappedUser = _mapper.Map<User>(registerUserDto);
            return mappedUser;
        }
    }
}