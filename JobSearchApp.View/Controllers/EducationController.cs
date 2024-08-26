using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public int GetUserId()
        {
            return int.Parse(HttpContext.Session.GetString("userId"));
        }
        public IActionResult FormNewEducationPage()
        {
            return View();
        }

        public async Task<IActionResult> FormEditEducationPage(int id)
        {
            var education = await _educationService.GetEducationByIdAsync(id);

            return View(education);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateEducation(UpdateEducationDto updateEducation)
        {
            EducationDto education = await _educationService.UpdateEducationAsync(updateEducation.EducationId, updateEducation);

            return RedirectToAction("ProfileOwnerUserPage", "Profile");
        }


        [HttpPost]
        public async Task<IActionResult> CreateNewEducation(CreateEducationDto newEducation)
        {

            EducationDto education = await _educationService.CreateEducationAsync(newEducation, GetUserId());

            return RedirectToAction("ProfileOwnerUserPage", "Profile");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            bool educationDeleted = await _educationService.DeleteEducationAsync(id);

            return RedirectToAction("ProfileOwnerUserPage", "Profile");
        }
    }
}
