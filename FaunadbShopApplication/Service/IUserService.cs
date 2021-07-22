using FaunadbShopApplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaunadbShopApplication.Service
{
    public interface IUserService
    {
        Task<bool> AddUser(User user, string password);
        Task<User> GetUserById(string id);
    }
}
