using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class HardSoftSkillsController : Controller
    {
        private readonly IUserSkillService _userSkillService;

        public HardSoftSkillsController(IUserSkillService userSkillService)
        {
            _userSkillService = userSkillService;
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
            // Pendiente de ver como se creara la skill y como se mostrara
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewHardSkill(CreateSkillDto dto)
        {
            // Pendiente de ver como se creara la skill y como se mostrara
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSoftSkill(UpdateSkillDto dto)
        {
            // Pendiente de ver como se actualizara la skill y como se mostrara
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateHardSkill(UpdateSkillDto dto)
        {
            // Pendiente de ver como se actualizara la skill y como se mostrara
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSoftSkill()
        {
            // Pendiente de ver como se borrara la skill y como se mostrara
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteHardSkill()
        {
            // Pendiente de ver como se borrara la skill y como se mostrara
            return Ok();
        }
    }
}
