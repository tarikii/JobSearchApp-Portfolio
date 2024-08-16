using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> ProfileOwnerUserPage()
        {
            int userId = int.Parse(HttpContext.Session.GetString("userId"));

            UserDto user = await _userService.GetUserByIdAsync(userId);

            return View(user);
        }
    }
}