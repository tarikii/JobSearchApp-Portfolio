using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class MatchController : Controller
    {
        [HttpGet]
        public IActionResult MatchesListPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListOfMatchesPage()
        {
            return View();
        }
    }
}
