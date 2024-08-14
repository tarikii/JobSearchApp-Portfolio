using Microsoft.AspNetCore.Mvc;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.DataTransferObject;

namespace Swipe4Work.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult HomePage()
        {
            return View();
        }
        public IActionResult ContactFormPage()
        {
            return View();
        }
        public IActionResult TeamDeveloperPage()
        {
            return View();
        }
        public IActionResult InformationPage()
        {
            return View();
        }

        public IActionResult HomeCandidatePage()
        {
            return View();
        }
        public async Task<IActionResult> HomeBusinessOrRecruiterPage(int userId)
        {
            UserDTO user = await _userService.GetUserByIdAsync(userId);

            if (user != null)
            {
                ViewBag.Role = "Admin";
                return View(user);
            }

            return View();
        }
    }
}
