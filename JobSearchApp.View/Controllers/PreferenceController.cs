using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class PreferenceController : Controller
    {
        public IActionResult ListPreferencePage()
        {
            return View();
        }
    }
}
