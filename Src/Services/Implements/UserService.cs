using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ayudantia_IDWM.Src.DTOs;
using ayudantia_IDWM.Src.Services.Interfaces;
using proy_ayudantía.Src.Repositories.Interfaces;

namespace ayudantia_IDWM.Src.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly IMapperService _mapperService;

        public UserService(IUserRepository userRepository, IMapperService mapperService)
        {
            _userRepository = userRepository;
            _mapperService = mapperService;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var result = await _userRepository.DeleteUser(id);
            return result;
        }

        public async Task<bool> EditUser(int id, EditUserDto editUser)
        {
            var result = await _userRepository.EditUser(id, editUser);
            return result;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            var mappedUsers = _mapperService.UserToUserDto(users);
            return mappedUsers;
        }
    }
}