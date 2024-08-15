using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Infrastructure.Extensions;
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


        // CANDIDATE SECTION
        [HttpGet]
        public async Task<IActionResult> CardsOfJobsOffersPage(int? currentIndex)
        {
            // Get the current user ID from the session
            int userId = int.Parse(HttpContext.Session.GetString("userId"));

            // Fetch the list of job offers
            IEnumerable<JobOfferDto> jobOffers = await _jobOfferService.GetAllJobOffersAsync();

            // Determine the current index, defaulting to 0 if not provided
            int index = currentIndex ?? 0;

            // If we've gone past the end of the list, redirect to a "No more offers" page or similar
            if (index >= jobOffers.Count())
            {
                return View("HomeLoggedPage", "Home");
            }

            // Get the current job offer based on the index
            JobOfferDto currentJobOffer = jobOffers.ElementAt(index);

            // Pass the current job offer and the next index to the view
            ViewBag.NextIndex = index + 1;
            return View(currentJobOffer);
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
        public async Task<IActionResult> LikeJobOffer(int jobOfferId, int nextIndex)
        {
            int userId = int.Parse(HttpContext.Session.GetString("userId"));

            // Create a new CreateApplicationDto instance and populate it
            var createApplicationDto = new CreateApplicationDto
            {
                UserId = userId,
                JobOfferId = jobOfferId,
                ApplicationDate = DateTimeOffset.Now,
                Status = "Pending",
                SalaryExpected = 20000 // Set this to an appropriate value or fetch from user input if needed
            };

            // Call the application service to create the application
            await _applicationService.CreateApplicationAsync(createApplicationDto);

            // Redirect to the CardsOfJobsOffersPage action with the next job offer index
            return RedirectToAction("CardsOfJobsOffersPage", new { currentIndex = nextIndex });
        }

        [HttpPost]
        public async Task<IActionResult> DislikeJobOffer(int jobOfferId)
        {
            int userId = int.Parse(HttpContext.Session.GetString("userId"));

            // Logic to dislike the job offer and update the session or database
            await _jobOfferService.DeleteJobOfferAsync(jobOfferId);

            // Redirect to the page to show the next job offer
            return RedirectToAction("CardsOfJobsOffersPage");
        }


        // RECRUITER BUSINESS SECTION

        [HttpGet]
        public IActionResult FormNewJobOfferPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FormModificationJobOfferPage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AdministrationListJobOffersPage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ListCandidatesOfJobOfferPage()
        {
            return View();
        }

        /*[HttpPost]
        public async Task<IActionResult> CreateNewJobOffer(CreateJobOfferDto dto)
        {
            if (!ModelState.IsValid)
                return View("FormNewJobOfferPage", dto);

            await _jobOfferService.CreateJobOfferAsync(dto);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateJobOffer(int jobOfferId, UpdateJobOfferDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _jobOfferService.UpdateJobOfferAsync(3, dto);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteJobOffer(DeleteJobOfferDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _jobOfferService.DeleteJobOfferAsync(dto.JobOfferId);

            return Ok();
        }*/
    }
}
