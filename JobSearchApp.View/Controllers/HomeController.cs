using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
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

        public async Task<IActionResult> HomeLoggedPage()
        {
            int userId = int.Parse(HttpContext.Session.GetString("userId"));

            UserDto user = await _userService.GetUserByIdAsync(userId);

            if (user != null)
            {
                ViewBag.Role = user.RoleName;
                return View(user);
            }

            return View();
        }
    }
}
