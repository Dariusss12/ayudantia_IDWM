using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ayudantia_IDWM.Src.DTOs;

namespace ayudantia_IDWM.Src.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterUser(RegisterUserDto registerUserDto);

        Task<string?> Login(LoginUserDto loginUserDto);
    }
}