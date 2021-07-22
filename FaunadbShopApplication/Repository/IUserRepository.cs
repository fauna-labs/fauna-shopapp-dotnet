using FaunadbShopApplication.Dto;
using System.Threading.Tasks;

namespace FaunadbShopApplication.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByPhone(string phoneNumber);
        Task<bool> AddUser(User user, string password);
        Task<User> GetUserById(string id);
    }
}
