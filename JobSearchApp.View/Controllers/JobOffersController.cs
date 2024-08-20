using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Infrastructure.Extensions;
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

            // The filtered list works while the session is on, once the app closes, the list resets
            // It should not do this, the list should mantain even if the app closes

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
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListOfJobsAppliedPage()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult>ApplyFilterJobOffers()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SaveJobOfferIdAndSearchCandidate(int id)
        {
            HttpContext.Session.Set("jobOfferIdForSeach", id);

            return RedirectToAction("CardsOfCandidatesPage", "Candidates");
        }

        [HttpPost]
        public async Task<IActionResult> LikeJobOffer(int jobOfferId, int nextIndex)
        {
            // Create a new CreateApplicationDto instance and populate it
            var createApplicationDto = new CreateApplicationDto
            {
                UserId = GetUserId(),
                JobOfferId = jobOfferId,
                ApplicationDate = DateTimeOffset.Now,
                Status = "Pending",
                SalaryExpected = 20000 // Set this to an appropriate value or fetch from user input if needed
            };

            // Retrieve liked job offers from the session or initialize an empty list
            var likedApplications = HttpContext.Session.Get<List<CreateApplicationDto>>($"LikedApplications_{GetUserId()}") ?? new List<CreateApplicationDto>();

            // Add the CreateApplicationDto to the liked list if not already present
            if (!likedApplications.Any(app => app.JobOfferId == jobOfferId))
            {
                likedApplications.Add(createApplicationDto);
                // Save the updated list back to the session
                HttpContext.Session.Set($"LikedApplications_{GetUserId()}", likedApplications);

                // Creates the application in the database with the userId
                await _applicationService.CreateApplicationAsync(createApplicationDto);
            }

            // Redirect to the page to show the next job offer with the adjusted index
            return RedirectToAction("CardsOfJobsOffersPage", new { currentIndex = nextIndex - 1 });
        }

        [HttpPost]
        public async Task<IActionResult> DislikeJobOffer(int jobOfferId, int nextIndex)
        {
            // Retrieve disliked job offers from the session or initialize an empty list
            var dislikedOffers = HttpContext.Session.Get<List<int>>($"DislikedOffers_{GetUserId()}") ?? new List<int>();

            // Add the job offer ID to the disliked list if not already present
            if (!dislikedOffers.Contains(jobOfferId))
            {
                dislikedOffers.Add(jobOfferId);
                // Save the updated list back to the session
                HttpContext.Session.Set($"DislikedOffers_{GetUserId()}", dislikedOffers);
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

        // MODIFICATION NEEDS TO GET CHECKED OUT, FORM POPS UP, BUT MODIFICATION IS NOT BEING DONE
        [HttpGet]
        public async Task<IActionResult> FormModificationJobOfferPage(int jobOfferId)
        {
            int userId = int.Parse(HttpContext.Session.GetString("userId"));

            UserDto user = await _userService.GetUserByIdAsync(userId);

            ViewBag.CompanyId = user.CompanyId;

            var jobOffer = await _jobOfferService.GetJobOfferByIdAsync(jobOfferId);
            if (jobOffer == null)
            {
                return NotFound();
            }

            var updateJobOfferDto = new UpdateJobOfferDto
            {
                JobOfferId = jobOffer.JobOfferId,
                Title = jobOffer.Title,
                Location = jobOffer.Location,
                JobType = jobOffer.JobType,
                ExperienceLevel = jobOffer.ExperienceLevel,
                ExpiredDate = jobOffer.ExpiredDate,
                MinSalary = jobOffer.MinSalary ?? 0,
                MaxSalary = jobOffer.MaxSalary ?? 0
            };

            return View(updateJobOfferDto);
        }

        [HttpGet]
        public async Task<IActionResult> AdministrationListJobOffersPage(int id = 0)
        {
            if (id == 1)
            {
                ViewBag.Title = "Selecciona una Oferta para buscar Candidatos";
                ViewBag.SearchCandidate = "True";
            }
            else
            {
                ViewBag.Title = "Administración de Ofertas de Trabajo";
                ViewBag.SearchCandidate = "False";
            }

            UserDto user = await _userService.GetUserByIdAsync(GetUserId());

            IEnumerable<JobOfferDto> jobOffers = await _jobOfferService.GetJobOfferByCompanyIdAsync(user.CompanyId);

            return View(jobOffers);
        }

        [HttpGet]
        public IActionResult ListCandidatesOfJobOfferPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewJobOffer(CreateJobOfferDto dto)
        {
            JobOfferDto newJobOffer = await _jobOfferService.CreateJobOfferAsync(dto);

            return RedirectToAction("AdministrationListJobOffersPage", "JobOffers");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateJobOffer(UpdateJobOfferDto dto)
        {
            if (!ModelState.IsValid)
            {
                // If validation fails, reload the view with the dto
                return View("FormModificationJobOfferPage", dto);
            }

            // Update the job offer using the jobOfferId
            await _jobOfferService.UpdateJobOfferAsync(3, dto);

            // Redirect to a page after successful update, like a list or detail view
            return RedirectToAction("AdministrationListJobOffersPage");
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
