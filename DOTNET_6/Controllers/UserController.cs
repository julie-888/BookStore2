using DOTNET_6.Services;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_6.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserStorage _userStorage;
        public UserController(IUserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public IActionResult ReservedBooks(string userName)
        {
            var user = _userStorage.GetUserByName(userName);
            return View(user);
        }
    }
}
