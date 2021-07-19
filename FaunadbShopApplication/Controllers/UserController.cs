using FaunadbShopApplication.Dto;
using FaunadbShopApplication.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FaunadbShopApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Authentificate existing user
        /// </summary>
        /// <param name="user"></param>
        [HttpPost("authenticate")]
        public async Task<AuthentificatedUser> Authentificate(LoginUser user)
        {
            return await _userService.Authenticate(user);
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="user"></param>
        [HttpPut("adduser")]
        [AllowAnonymous]
        public async Task<bool> AddUser(User user)
        {
            return await _userService.AddUser(user);
        }
    }
}
