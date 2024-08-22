using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class MatchController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMatchService _matchService;
        private readonly IApplicationService _applicationService;

        public MatchController(IUserService userService, IMatchService matchService, IApplicationService applicationService)
        {
            _userService = userService;
            _matchService = matchService;
            _applicationService = applicationService;
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
            var userId = GetUserId();

            // Fetch all matches for the user
            var matches = await _matchService.GetAllMatchesAsync();
            var userMatches = matches.Where(m => m.UserId == userId && m.IsAccepted).ToList();

            // Fetch all applications related to the job offers in the matches
            var applications = await _applicationService.GetAllApplicationsAsync();

            // Iterate through matches and find the corresponding ApplicationId
            foreach (var match in userMatches)
            {
                // Find the application that matches the job offer and user
                var matchingApplication = applications
                    .FirstOrDefault(a => a.JobOfferId == match.JobOfferId && a.UserId == userId);

                // If a matching application is found, set the ApplicationId
                if (matchingApplication != null)
                {
                    match.ApplicationId = matchingApplication.ApplicationId;
                }
            }

            return View(userMatches);
        }


    }
}
