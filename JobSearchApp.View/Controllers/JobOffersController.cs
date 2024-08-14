using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class JobOffersController : Controller
    {
        private IUserService _userService;
        private IJobOfferService _jobOfferService;
        private ICompanyService _companyService;
        private IApplicationService _applicationService;

        public JobOffersController(IUserService userService, 
            IJobOfferService jobOfferService,
            IApplicationService applicationService)
        {
            _userService = userService;
            _jobOfferService = jobOfferService;
            _applicationService = applicationService;
        }

        [HttpGet]
        public IActionResult CardsOfJobsOffersPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FilterJobOffersPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListOfJobsAppliedPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ApplyFilterJobOffers()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LikeJobOffer(int userId, int jobOfferId)
        {
            // Retrieve the user to check if the user exists
            UserDto user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            JobOfferDto jobOffer = await _jobOfferService.GetJobOfferByIdAsync(jobOfferId);

            if (jobOffer == null)
            {
                return NotFound("Job offer not found");
            }

            var createApplication = new CreateApplicationDto
            {
                UserId = userId,
                JobOfferId = jobOffer.JobOfferId,
                ApplicationDate = DateTime.Now,
                Status = "En proceso",
                SalaryExpected = 20000
            };

            var application = await _applicationService.CreateApplicationAsync(createApplication);

            return Ok();

        }

    }
}
