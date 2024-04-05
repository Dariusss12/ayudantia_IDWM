using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using ayudantia_IDWM.Src.DTOs;
using ayudantia_IDWM.Src.Services.Interfaces;
using proy_ayudantía.Src.Models;
using proy_ayudantía.Src.Repositories.Interfaces;
using System.Text;
using ayudantia_IDWM.Src.Repositories.Interfaces;

namespace ayudantia_IDWM.Src.Services.Implements
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapperService _mapperService;

        public AuthService(IConfiguration configuration, IUserRepository userRepository, IMapperService mapperService, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _mapperService = mapperService;
            _roleRepository = roleRepository;
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

        public async Task<string> RegisterUser(RegisterUserDto registerUserDto)
        {
            var mappedUser = _mapperService.RegisterUserDtoToUser(registerUserDto);
            if(_userRepository.VerifyUserByEMail(mappedUser.Email).Result){
                throw new Exception("El email ingresado ya existe.");
            }

            var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerUserDto.Password, salt);

            mappedUser.Password = passwordHash;
            var role = await _roleRepository.GetRoleByName("Usuario");
            if(role == null){
                throw new Exception("Error del servidor, intentelo más tarde.");
            }
            mappedUser.RoleId = role.Id;
            
            await _userRepository.AddUser(mappedUser);
            var user = await _userRepository.GetUserByEmail(mappedUser.Email);
            if(user == null){
                return "Error del servidor, intentelo más tarde.";
            }
            
            var token = CreateToken(user);
            return token;
            
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