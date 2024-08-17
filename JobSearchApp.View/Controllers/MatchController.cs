using JobSearchApp.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class MatchController : Controller
    {
        private readonly IUserService _userService;

        public MatchController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult MatchesListPage()
        {
            return View();
        }

        public int GetUserId()
        {
            return int.Parse(HttpContext.Session.GetString("userId"));
        }

        [HttpGet]
        public async Task<IActionResult> ListOfMatchesPage()
        {
            return View(await _userService.GetUserByIdAsync(GetUserId()));
        }
    }
}
