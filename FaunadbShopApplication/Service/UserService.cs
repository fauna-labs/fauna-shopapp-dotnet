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

        public async Task<bool> AddUser(User user, string password)
        {
            return await _repository.AddUser(user, password);
        }

        public Task<User> GetUserById(string id)
        {
            return _repository.GetUserById(id);
        }
    }
}
