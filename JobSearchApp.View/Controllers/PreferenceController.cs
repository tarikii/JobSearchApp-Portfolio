using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class PreferenceController : Controller
    {
        IUserPreferenceService _userPreferenceService;

        public PreferenceController(IUserPreferenceService userPreferenceService) 
        { 
            _userPreferenceService = userPreferenceService;
        }

        [HttpGet]
        public async Task<IActionResult> ListPreferencePage()
        {
            int userId = int.Parse(HttpContext.Session.GetString("userId"));

            // Fetch all interests
            IEnumerable<UserPreferenceDto> allPreferences = await 
                _userPreferenceService.GetAllUserPreferencesAsync();

            // Filter interests based on userId
            IEnumerable<UserPreferenceDto> userPreferences = allPreferences
                .Where(i => i.UserId == userId);

            return View(userPreferences);
        }

        public IActionResult EditListPreferencePage() 
        {
            return View();
        }
    }
}
