using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class InterestController : Controller
    {
        public IActionResult ListInterestPage()
        {
            return View();
        }
    }
}
