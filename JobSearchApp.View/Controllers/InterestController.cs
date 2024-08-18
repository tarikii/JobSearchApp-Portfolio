using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.BusinessLogic.Services;
using JobSearchApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class InterestController : Controller
    {
        IInterestService _interestService;

        public InterestController(IInterestService interestService)
        {
            _interestService = interestService;
        }

        [HttpGet]
        public async Task<IActionResult> ListInterestPage()
        {
            int userId = int.Parse(HttpContext.Session.GetString("userId"));

            // Fetch all interests
            IEnumerable<InterestDto> allInterests = await _interestService.GetAllInterestsAsync();

            // Filter interests based on userId
            IEnumerable<InterestDto> userInterests = allInterests
                .Where(i => i.UserId == userId);

            return View(userInterests);
        }

        [HttpGet]
        public async Task<IActionResult> EditListInterestPage()
        {
            int userId = int.Parse(HttpContext.Session.GetString("userId"));

            // Fetch all interests
            IEnumerable<InterestDto> allInterests = await _interestService.GetAllInterestsAsync();

            // Filter interests based on userId
            IEnumerable<InterestDto> userInterests = allInterests
                .Where(i => i.UserId == userId);

            return View(userInterests);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInterest([FromBody]CreateInterestDto dto)
        {
            return View(dto);
        }
    }
}
