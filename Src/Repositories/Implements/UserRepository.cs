using ayudantia_IDWM.Src.DTOs;
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

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteUser(int id)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if(existingUser == null){
                return false;
            }
            
            _context.Remove(existingUser);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditUser(int id, EditUserDto editUser)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null){
                return false;
            }

            existingUser.Nombre = editUser.Nombre ?? existingUser.Nombre;

            _context.Entry(existingUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;

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
            var users = await _context.Users.Where(u => u.RoleId == 2).ToListAsync();
            return users;
        }

        public async Task<bool> VerifyUserByEMail(string Email)
        {
            var user = await _context.Users.Where(u => u.Email == Email)
                                            .FirstOrDefaultAsync();
            if(user == null){
                return false;
            }
            return true;
            
        }
    }
}