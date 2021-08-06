using AutoMapper;
using Business.JWT;
using Business.Services.Interfaces;
using Business.Services.Models.Login;
using Business.Services.Models.User;
using Data.Entities;
using Data.Functions.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementation
{
    public class Login_Service : ILogin_Service
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public Login_Service(IMapper mapper, IGenericRepository<User> repository, IOptions<JwtSettings> jwtSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;
        }

        /// <summary>
        /// Check if username match password
        /// </summary>
        /// <returns></returns>
        public async Task<AuthenticateResponse> Login(AuthenticateRequest model)
        {
            var user = await _repository.GetAll()
                .FirstOrDefaultAsync(u => u.UserName == model.UserName && u.Password == model.Password);

            if (user == null) { return null; }

            var token = generateJwtToken(user);

            var User = _mapper.Map<UserDto>(user);

            return new AuthenticateResponse(User, token);
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("UserName", user.UserName.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
