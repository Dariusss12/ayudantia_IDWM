using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proy_ayudantía.Src.Models;

namespace ayudantia_IDWM.Src.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role?> GetRoleById(int id);
    }
}