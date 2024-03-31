using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using ayudantia_IDWM.Src.DTOs;
using ayudantia_IDWM.Src.Services.Interfaces;
using proy_ayudantía.Src.Models;
using proy_ayudantía.Src.Repositories.Interfaces;
using System.Text;

namespace ayudantia_IDWM.Src.Services.Implements
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthService(IConfiguration configuration, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string?> Login(LoginUserDto loginUserDto)
        {
            var user = await _userRepository.GetUserByEmail(loginUserDto.Email.ToString());
            if (user is null) return null;

            var result = BCrypt.Net.BCrypt.Verify(loginUserDto.Password, user.Password);
            if(!result) return null;

            var token = CreateToken(user);

            return token;
        }

        public Task<string> RegisterUser(RegisterUserDto registerUserDto)
        {
            throw new Exception("hola");
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>{
                new ("Id", user.Id.ToString()),
                new ("Email", user.Email),
                new (ClaimTypes.Role, user.Role.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}