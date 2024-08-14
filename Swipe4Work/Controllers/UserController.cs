using Microsoft.AspNetCore.Mvc;
using Swipe4Work.BusinessLogic.Interfaces;

namespace Swipe4Work.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetUserByIdAsync(1);

            return View(users);
        }
    }
}
