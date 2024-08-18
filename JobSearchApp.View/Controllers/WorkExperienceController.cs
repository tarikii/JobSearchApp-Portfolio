using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class WorkExperienceController : Controller
    {
        private readonly IWorkExperienceService _workExperienceService;

        public WorkExperienceController(IWorkExperienceService workExperienceService)
        {
            _workExperienceService = workExperienceService;
        }
        public int GetUserId()
        {
            return int.Parse(HttpContext.Session.GetString("userId"));
        }

        public IActionResult FormNewExperiencePage()
        {
            return View();
        }
        
        public async Task<IActionResult> FormEditExperiencePage(int id)
        {
            WorkExperienceDto workExperience = await _workExperienceService.GetWorkExperienceByIdAsync(id);

            return View(workExperience);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewExperience(CreateWorkExperienceDto newWorkExperience)
        {
            WorkExperienceDto workExperience = await _workExperienceService.CreateWorkExperienceAsync(newWorkExperience, GetUserId());

            return RedirectToAction("ProfileOwnerUserPage", "Profile");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateExperience(UpdateWorkExperienceDto updateWorkExperience)
        {   
            WorkExperienceDto workExperience = await _workExperienceService.UpdateWorkExperienceAsync(updateWorkExperience.WorkExperienceId, updateWorkExperience);

            return RedirectToAction("ProfileOwnerUserPage", "Profile");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteExperience(int id)
        {
            bool workDeleted = await _workExperienceService.DeleteWorkExperienceAsync(id);

            return RedirectToAction("ProfileOwnerUserPage", "Profile");
        }
    }
}
