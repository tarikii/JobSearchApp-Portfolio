using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class SeeAllController : Controller
    {
        IInterestService _interestService;
        IUserPreferenceService _userPreferenceService;
        IUserSkillService _userSkillService;

        public SeeAllController(IInterestService interestService, IUserPreferenceService userPreferenceService, IUserSkillService userSkillService)
        {
            _interestService = interestService;
            _userPreferenceService = userPreferenceService;
            _userSkillService = userSkillService;
        }

        public int GetUserId()
        {
            return int.Parse(HttpContext.Session.GetString("userId"));
        }

        [HttpGet]
        public async Task<IActionResult> ListOfSeeAllPage()
        {
            // Fetch and filter user skills
            var allUserSkills = await _userSkillService.GetAllUserSkillsAsync();
            var userSkills = allUserSkills.Where(i => i.UserId == GetUserId());

            // Fetch and filter user interests
            var allInterests = await _interestService.GetAllInterestsAsync();
            var userInterests = allInterests.Where(i => i.UserId == GetUserId());

            // Fetch and filter user preferences
            var allPreferences = await _userPreferenceService.GetAllUserPreferencesAsync();
            var userPreferences = allPreferences.Where(i => i.UserId == GetUserId());

            // Create the view model
            var viewModel = new SeeAllDto
            {
                UserSkills = userSkills,
                UserInterests = userInterests,
                UserPreferences = userPreferences
            };

            // Pass the view model to the view
            return View(viewModel);
        }
    }
}
