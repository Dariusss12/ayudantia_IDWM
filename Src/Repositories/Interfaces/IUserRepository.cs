using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proy_ayudantía.Src.Models;

namespace proy_ayudantía.Src.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
    }
}