using FaunadbShopApplication.Dto;
using System.Threading.Tasks;

namespace FaunadbShopApplication.Service
{
    public interface IUserService
    {
        Task<bool> AddUser(User user, string password);
        Task<User> GetUserById(string id);
    }
}
