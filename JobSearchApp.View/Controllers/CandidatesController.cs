using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class CandidatesController : Controller
    {
        IUserService _userService;

        public CandidatesController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> CardsOfCandidatesPage()
        {
            int userId = int.Parse(HttpContext.Session.GetString("userId"));

            IEnumerable<UserDto> users = await _userService.GetAllUsersAsync();

            UserDto pruebaUser = users.FirstOrDefault();

            return View(pruebaUser);
        }
    }
}
