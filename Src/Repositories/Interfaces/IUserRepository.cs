using proy_ayudantía.Src.Models;

namespace proy_ayudantía.Src.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User?> GetUserByEmail(string Email);
    }
}