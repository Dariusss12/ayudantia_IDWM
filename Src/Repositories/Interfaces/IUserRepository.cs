using ayudantia_IDWM.Src.DTOs;
using proy_ayudantía.Src.Models;

namespace proy_ayudantía.Src.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User?> GetUserByEmail(string Email);

        Task<bool> VerifyUserByEMail(string Email);

        Task<bool> EditUser(int id, EditUserDto editUser);

        Task<bool> DeleteUser(int id);

        Task AddUser(User user);
    }
}