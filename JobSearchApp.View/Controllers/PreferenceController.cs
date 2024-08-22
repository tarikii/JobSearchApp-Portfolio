using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
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

        public int GetUserId()
        {
            return int.Parse(HttpContext.Session.GetString("userId"));
        }

        [HttpGet]
        public async Task<IActionResult> EditListPreferencePage() 
        {
            // Fetch all preferences
            IEnumerable<UserPreferenceDto> allPreferences = 
                await _userPreferenceService.GetAllUserPreferencesAsync();

            // Filter preferences based on userId
            IEnumerable<UserPreferenceDto> userPreferences = allPreferences
                .Where(i => i.UserId == GetUserId());

            return View(userPreferences);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePreference(CreateUserPreferenceDto dto)
        {
            // Proceed with creating the preference
            UserPreferenceDto preference = await 
                _userPreferenceService.CreateUserPreferenceAsync(dto, GetUserId());

            // Redirect or return to the list page after successful creation
            return RedirectToAction("EditListPreferencePage", "Preference");
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePreference(UpdateUserPreferenceDto dto)
        {
            UserPreferenceDto preference = 
                await _userPreferenceService.UpdateUserPreferenceAsync(dto.PreferenceId, dto);

            return RedirectToAction("EditListPreferencePage", "Preference");
        }

        [HttpPost]
        public async Task<IActionResult> DeletePreference(int id)
        {
            bool preferenceDeleted = await _userPreferenceService.DeleteUserPreferenceAsync(id);

            return RedirectToAction("EditListPreferencePage", "Preference");
        }
    }
}
