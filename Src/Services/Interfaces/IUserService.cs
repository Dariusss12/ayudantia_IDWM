using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ayudantia_IDWM.Src.DTOs;

namespace ayudantia_IDWM.Src.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<UserDto>> GetUsers();

        public Task<bool> EditUser(int id, EditUserDto editUser);

        public Task<bool> DeleteUser(int id);
    }
}