using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ayudantia_IDWM.Src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using proy_ayudantía.Src.Data;
using proy_ayudantía.Src.Models;
using SQLitePCL;

namespace ayudantia_IDWM.Src.Repositories.Implements
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;

        public RoleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Role?> GetRoleById(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            return role;
        }

        public async Task<Role?> GetRoleByName(string name)
        {
            var role = await _context.Roles.Where(r => r.Name == name).FirstOrDefaultAsync();
            return role;
        }
    }
}