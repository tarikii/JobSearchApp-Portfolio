using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class JobOffersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IJobOfferService _jobOfferService;
        private readonly ICompanyService _companyService;
        private readonly IApplicationService _applicationService;

        public JobOffersController(IUserService userService, 
            IJobOfferService jobOfferService,
            IApplicationService applicationService)
        {
            _userService = userService;
            _jobOfferService = jobOfferService;
            _applicationService = applicationService;     
        }

        public int GetUserId()
        {
            return int.Parse(HttpContext.Session.GetString("userId"));
        }


        // CANDIDATE SECTION
        [HttpGet]
        public async Task<IActionResult> CardsOfJobsOffersPage(int? currentIndex)
        {
            // Get user ID from the session
            int userId = int.Parse(HttpContext.Session.GetString("userId"));

            // Fetch the list of job offers
            IEnumerable<JobOfferDto> jobOffers = await _jobOfferService.GetAllJobOffersAsync();

            // Retrieve disliked job offers from the session
            var dislikedOffers = HttpContext.Session.Get<List<int>>($"DislikedOffers_{userId}") ?? new List<int>();

            // Retrieve liked job applications from the session
            var likedApplications = HttpContext.Session.Get<List<CreateApplicationDto>>($"LikedApplications_{userId}") ?? new List<CreateApplicationDto>();

            // Filter out both disliked job offers and liked job offers (using JobOfferId from CreateApplicationDto)
            var filteredJobOffers = jobOffers.Where(offer =>
                !dislikedOffers.Contains(offer.JobOfferId) &&
                !likedApplications.Any(app => app.JobOfferId == offer.JobOfferId)).ToList();

            // Determine the current index
            int index = currentIndex ?? 0;

            // Adjust the index if it exceeds the count of filtered job offers
            if (index >= filteredJobOffers.Count())
            {
                // If the list is empty, redirect to the HomeLoggedPage
                if (filteredJobOffers.Count == 0)
                {
                    return View("HomeLoggedPage", "Home");
                }

                // Reset index to 0 to show the first offer again
                index = 0;
            }

            // Get the current job offer based on the index
            JobOfferDto currentJobOffer = filteredJobOffers.ElementAt(index);

            // Pass the current job offer and the next index to the view
            ViewBag.NextIndex = index + 1;
            return View(currentJobOffer);
        }

        [HttpGet]
        public async Task<IActionResult> FilterJobOffersPage()
        {
            return View(_userService.GetUserByIdAsync(GetUserId()));
        }

        [HttpGet]
        public async Task<IActionResult> ListOfJobsAppliedPage()
        {
            return View(await _userService.GetUserByIdAsync(GetUserId()));
        }

        [HttpGet]
        public async Task<IActionResult>ApplyFilterJobOffers()
        {
            return View(_userService.GetUserByIdAsync(int.Parse(HttpContext.Session.GetString("userId"))));
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

            // Retrieve liked job offers from the session or initialize an empty list
            var likedApplications = HttpContext.Session.Get<List<CreateApplicationDto>>($"LikedApplications_{userId}") ?? new List<CreateApplicationDto>();

            // Add the CreateApplicationDto to the liked list if not already present
            if (!likedApplications.Any(app => app.JobOfferId == jobOfferId))
            {
                likedApplications.Add(createApplicationDto);
                // Save the updated list back to the session
                HttpContext.Session.Set($"LikedApplications_{userId}", likedApplications);

                // Creates the application in the database with the userId
                await _applicationService.CreateApplicationAsync(createApplicationDto);
            }

            // Redirect to the page to show the next job offer with the adjusted index
            return RedirectToAction("CardsOfJobsOffersPage", new { currentIndex = nextIndex - 1 });
        }

        [HttpPost]
        public async Task<IActionResult> DislikeJobOffer(int jobOfferId, int nextIndex)
        {
            // Get user ID from the session
            int userId = int.Parse(HttpContext.Session.GetString("userId"));

            // Retrieve disliked job offers from the session or initialize an empty list
            var dislikedOffers = HttpContext.Session.Get<List<int>>($"DislikedOffers_{userId}") ?? new List<int>();

            // Add the job offer ID to the disliked list if not already present
            if (!dislikedOffers.Contains(jobOfferId))
            {
                dislikedOffers.Add(jobOfferId);
                // Save the updated list back to the session
                HttpContext.Session.Set($"DislikedOffers_{userId}", dislikedOffers);
            }

            // Redirect to the page to show the next job offer with the adjusted index
            return RedirectToAction("CardsOfJobsOffersPage", new { currentIndex = nextIndex - 1 });
        }



        // RECRUITER BUSINESS SECTION

        [HttpGet]
        public async Task<IActionResult> FormNewJobOfferPage()
        {
            int userId = int.Parse(HttpContext.Session.GetString("userId"));

            UserDto user = await _userService.GetUserByIdAsync(userId);

            ViewBag.CompanyId = user.CompanyId;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FormModificationJobOfferPage()
        {
            int userId = int.Parse(HttpContext.Session.GetString("userId"));

            UserDto user = await _userService.GetUserByIdAsync(userId);

            ViewBag.CompanyId = user.CompanyId;

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

        [HttpPost]
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
        }
    }
}
