using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public int GetUserId()
        {
            return int.Parse(HttpContext.Session.GetString("userId"));
        }

        public async Task<IActionResult> ListApplicationJobOfferPage()
        {
            IEnumerable<ApplicationDto> myApplications = await _applicationService.GetAllApplicationsAsync();

            return View(myApplications.Where(u => u.UserId == GetUserId()));
        }
    }
}
