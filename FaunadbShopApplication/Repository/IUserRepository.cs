using FaunadbShopApplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FaunadbShopApplication.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByPhone(string phoneNumber);
        Task<bool> AddUser(User user);
        Task<User> GetUserById(string id);
    }
}
