using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class MatchController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMatchService _matchService;

        public MatchController(IUserService userService, IMatchService matchService)
        {
            _userService = userService;
            _matchService = matchService;
        }

        /*[HttpGet]
        public IActionResult MatchesListPage()
        {
            return View();
        }*/

        public int GetUserId()
        {
            return int.Parse(HttpContext.Session.GetString("userId"));
        }

        [HttpGet]
        public async Task<IActionResult> ListOfMatchesPage()
        {
            IEnumerable<MatchDto> matches = await _matchService.GetAllMatchesAsync();

            return View(matches.Where(u => u.UserId == GetUserId() && u.IsAccepted));
        }
    }
}
