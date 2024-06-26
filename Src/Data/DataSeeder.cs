using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using proy_ayudantía.Src.Data;
using proy_ayudantía.Src.Models;

namespace ayudantia_IDWM.Src.Data
{
    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<DataContext>();

                if(!context.Roles.Any()){
                    context.Roles.AddRange(
                        new Role { Name = "Admin"},
                        new Role { Name = "Usuario"}
                     );
                }

                if(!context.Users.Any())
                {
                    
                    var user = new User { 
                        Nombre = "Ignacio Mancilla",
                        Email = "ignacio.mancilla@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("P4ssw0rd"),
                        RoleId = 1
                    };

                    context.Users.Add(user);

                    var faker = new Faker<User>()
                    .RuleFor(u => u.Nombre, f => f.Person.FullName)
                    .RuleFor(u => u.Email, f => f.Internet.Email())
                    .RuleFor(u => u.Password, f => BCrypt.Net.BCrypt.HashPassword("password"))
                    .RuleFor(u => u.RoleId, f => 2);

                    var users = faker.Generate(20); // Genera 10 usuarios aleatorios

                    context.Users.AddRange(users);
                }

                context.SaveChanges();
            }
        }
    }
}