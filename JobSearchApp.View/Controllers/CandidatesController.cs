using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly IUserService _userService;
        private readonly IJobOfferService _jobOfferService;

        public CandidatesController(IUserService userService, IJobOfferService jobOfferService)
        {
            _userService = userService;
            _jobOfferService = jobOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> CardsOfCandidatesPage(int id)
        {
            JobOfferDto jobOffer = await _jobOfferService.GetJobOfferByIdAsync(id);

            ViewBag.NameOffer = jobOffer.Title;

            int userId = int.Parse(HttpContext.Session.GetString("userId"));

            IEnumerable<UserDto> users = await _userService.GetAllUsersAsync();

            UserDto pruebaUser = users.FirstOrDefault();

            return View(pruebaUser);
        }
    }
}
