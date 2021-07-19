using FaunadbShopApplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaunadbShopApplication.Service
{
    public interface IUserService
    {
        Task<AuthentificatedUser> Authenticate(LoginUser user);
        Task<bool> AddUser(User user);
        Task<User> GetUserById(string id);
    }
}
