using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.BusinessLogic.Services;
using JobSearchApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class HardSoftSkillsController : Controller
    {
        private readonly IUserSkillService _userSkillService;
        private readonly ISkillService _skillService;

        public HardSoftSkillsController(IUserSkillService userSkillService, ISkillService skillService)
        {
            _userSkillService = userSkillService;
            _skillService = skillService;
        }

        public int GetUserId()
        {
            return int.Parse(HttpContext.Session.GetString("userId"));
        }

        [HttpGet]
        public async Task<IActionResult> ListHardSoftSkillsPage()
        {
            int userId = GetUserId();

            // Fetch all user skills
            IEnumerable<UserSkillDto> allUserSkills = await
                _userSkillService.GetAllUserSkillsAsync();

            // Filter user skills based on userId
            IEnumerable<UserSkillDto> userSkills = allUserSkills
                .Where(i => i.UserId == userId);

            return View(userSkills);
        }

        [HttpGet]
        public async Task<IActionResult> EditListHardSoftSkillsPage()
        {
            int userId = GetUserId();

            // Fetch all user skills
            IEnumerable<UserSkillDto> allUserSkills = await
                _userSkillService.GetAllUserSkillsAsync();

            // Filter user skills based on userId
            IEnumerable<UserSkillDto> userSkills = allUserSkills
                .Where(i => i.UserId == userId);

            return View(userSkills);
        }
        [HttpPost]
        public async Task<IActionResult> CreateNewSoftSkill(CreateSkillDto dto)
        {
            // Create the skill
            var newSkill = await _skillService.CreateSkillAsync(dto);

            // Link the skill with the user
            var createUserSkillDto = new CreateUserSkillDto
            {
                UserId = GetUserId(),
                SkillId = newSkill.SkillId,
            };

            var newUserSkill = await _userSkillService.CreateUserSkillAsync(createUserSkillDto);

            // Redirect or return to the list page after successful creation
            return RedirectToAction("EditListHardSoftSkillsPage", "HardSoftSkills");
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewHardSkill(CreateSkillDto dto)
        {
            // Create the skill hard
            var newSkill = await _skillService.CreateSkillAsync(dto);

            // Link the skill with the user
            var createUserSkillDto = new CreateUserSkillDto
            {
                UserId = GetUserId(),
                SkillId = newSkill.SkillId,
            };

            var newUserSkill = await _userSkillService.CreateUserSkillAsync(createUserSkillDto);

            // Redirect or return to the list page after successful creation
            return RedirectToAction("EditListHardSoftSkillsPage", "HardSoftSkills");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSoftSkill(UpdateSkillDto dto)
        {
            try
            {
                SkillDto skill = await _skillService.UpdateSkillAsync(dto.SkillId, dto);

                return Json(new { skillName = skill.SkillName });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> UpdateHardSkill(UpdateSkillDto dto)
        {
            try
            {
                SkillDto skill = await _skillService.UpdateSkillAsync(dto.SkillId, dto);

                return Json(new { skillName = skill.SkillName });
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSoftSkill(int id)
        {
            await _skillService.DeleteSkillAsync(id);
            await _userSkillService.DeleteUserSkillAsync(id);

            return RedirectToAction("EditListHardSoftSkillsPage", "HardSoftSkills");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteHardSkill(int id)
        {
            await _skillService.DeleteSkillAsync(id);
            await _userSkillService.DeleteUserSkillAsync(id);

            return RedirectToAction("EditListHardSoftSkillsPage", "HardSoftSkills");
        }
    }
}
