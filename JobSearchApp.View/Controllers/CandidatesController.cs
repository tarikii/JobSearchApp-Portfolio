using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly IUserService _userService;
        private readonly IJobOfferService _jobOfferService;
        private readonly IMatchService _matchService;
        private readonly IApplicationService _applicationService;

        public CandidatesController(IUserService userService, IJobOfferService jobOfferService, IMatchService matchService, IApplicationService applicationService)
        {
            _userService = userService;
            _jobOfferService = jobOfferService;
            _matchService = matchService;
            _applicationService = applicationService;
        }

        public int GetUserId()
        {
            return int.Parse(HttpContext.Session.GetString("userId"));
        }

        public async Task<JobOfferDto> GetJobOffer()
        {
            int jobOfferId = int.Parse(HttpContext.Session.GetString("jobOfferIdForSeach"));

            return await _jobOfferService.GetJobOfferByIdAsync(jobOfferId);
        }

        [HttpGet]
        public async Task<IActionResult> CardsOfCandidatesPage(int? currentIndex)
        {
            JobOfferDto jobOffer = await GetJobOffer();
            ViewBag.NameOffer = jobOffer.Title;
            ViewBag.JobOfferId = jobOffer.JobOfferId;
            // Pillar Usuarios Candidatos
            IEnumerable<UserDto> candidates = await _userService.GetAllUsersCandidateAsync();

            //Pillar las lista de Dislikes de Candidatos
            var dislikedCandidates = HttpContext.Session.Get<List<int>>($"DislikedCandidates_{jobOffer.JobOfferId}") ?? new List<int>();

            //Pillar la lista de likes de Candidatos
            IEnumerable<MatchDto> matches = await _matchService.GetAllMatchesAsync();
            var likedCandidates = matches.Where(j => j.JobOfferId == jobOffer.JobOfferId).ToList();

            //Filtro de usuarios
            var filteredCandidates = candidates.Where(cd =>
                !dislikedCandidates.Contains(cd.UserId) &&
                !likedCandidates.Any(cl => cl.UserId == cd.UserId)).ToList();

            //Determinar el index actual
            int index = currentIndex ?? 0;

            // Adjust the index if it exceeds the count of filtered job offers
            if (index >= filteredCandidates.Count())
            {
                // If the list is empty, redirect to the HomeLoggedPage
                if (filteredCandidates.Count == 0)
                {
                    ViewBag.Users = "Checked";
                    return View();
                }

                // Reset index to 0 to show the first offer again
                index = 0;
            }

            UserDto currentCandidate = filteredCandidates.ElementAt(index);

            // Pass the current candidate and the next index to the view
            ViewBag.NextIndex = index + 1;
            return View(currentCandidate);
        }


        [HttpPost]
        public async Task<IActionResult> LikeCandidate(int userId, int nextIndex)
        {
            JobOfferDto jobOffer = await GetJobOffer();
            bool existsMatch = false;

            // Comprobar si se ha registrado la applicación del candidato en el match
            IEnumerable<MatchDto> matches = await _matchService.GetAllMatchesAsync();

            MatchDto? match = matches
                .Where(m => m.UserId == userId && m.JobOfferId == jobOffer.JobOfferId)
                .FirstOrDefault();

            // Comprobar si existe la postulación del candidato
            IEnumerable<ApplicationDto> aplications = await _applicationService.GetAllApplicationsAsync();

            ApplicationDto? application = aplications
                                            .Where(c => c.UserId == userId && c.JobOfferId == jobOffer.JobOfferId)
                                            .FirstOrDefault();

            if (application != null)
                existsMatch = true;

            // Create a new CreateMatchDto instance and populate it
            var createMatchDto = new CreateMatchDto
            {
                JobOfferId = jobOffer.JobOfferId,
                UserId = userId,
                IsAccepted = existsMatch
            };

            if (match == null)
            {
                await _matchService.CreateMatchAsync(createMatchDto);
            }

            // Redirect to the page to show the next job offer with the adjusted index
            return RedirectToAction("CardsOfCandidatesPage", new { currentIndex = nextIndex - 1 });
        }

        [HttpPost]
        public async Task<IActionResult> DislikeCandidate(int userId, int nextIndex)
        {
            JobOfferDto jobOffer = await GetJobOffer();

            // Retrieve disliked job offers from the session or initialize an empty list
            var dislikedOffers = HttpContext.Session.Get<List<int>>($"DislikedCandidates_{jobOffer.JobOfferId}") ?? new List<int>();

            // Add the job offer ID to the disliked list if not already present
            if (!dislikedOffers.Contains(userId))
            {
                dislikedOffers.Add(userId);
                // Save the updated list back to the session
                HttpContext.Session.Set($"DislikedCandidates_{jobOffer.JobOfferId}", dislikedOffers);
            }

            // Redirect to the page to show the next job offer with the adjusted index
            return RedirectToAction("CardsOfCandidatesPage", new { currentIndex = nextIndex - 1 });
        }
    }
}
