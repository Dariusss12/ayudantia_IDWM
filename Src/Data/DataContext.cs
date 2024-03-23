using Microsoft.EntityFrameworkCore;
using proy_ayudantía.Src.Models;

namespace proy_ayudantía.Src.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set;} = null!;

        public DbSet<Role> Roles { get; set;} = null!;

        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}