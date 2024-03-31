using Microsoft.EntityFrameworkCore;
using proy_ayudantía.Src.Data;
using proy_ayudantía.Src.Models;
using proy_ayudantía.Src.Repositories.Interfaces;

namespace proy_ayudantía.Src.Repositories.Implements
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmail(string Email)
        {
            var user = await _context.Users.Where(u => u.Email == Email)
                                            .Include(u => u.Role)
                                            .FirstOrDefaultAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
    }
}