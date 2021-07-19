using FaunadbShopApplication.Dto;
using FaunadbShopApplication.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FaunadbShopApplication.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<bool> AddUser(User user)
        {
            return await _repository.AddUser(user);
        }

        public async Task<AuthentificatedUser> Authenticate(LoginUser user)
        {
            var dbUser = await _repository.GetUserByPhone(user.PhoneNumber);
            if (dbUser == null)
            {
                throw new ArgumentException($"Can't find user with phone {user.PhoneNumber}");
            }
            if (!String.Equals(dbUser.Password, user.Password))
            {
                throw new ArgumentException($"Password is incorrect");
            }
            var token = generateJwtToken(dbUser);
            AuthentificatedUser authUser = new AuthentificatedUser(dbUser) { Token = token };
            return authUser;
        }

        public Task<User> GetUserById(string id)
        {
            return _repository.GetUserById(id);
        }

        private string generateJwtToken([NotNull]User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { 
                    new Claim("id", user.IdRef), 
                    new Claim("phone", user.PhoneNumber) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
