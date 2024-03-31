using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ayudantia_IDWM.Src.DTOs;
using proy_ayudantía.Src.Models;

namespace ayudantia_IDWM.Src.Services.Interfaces
{
    public interface IMapperService
    {
        public User RegisterUserDtoToUser(RegisterUserDto registerUserDto);
    }
}