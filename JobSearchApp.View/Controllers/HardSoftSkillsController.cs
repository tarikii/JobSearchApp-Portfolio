using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class HardSoftSkillsController : Controller
    {
        private readonly IUserService _userService;

        public HardSoftSkillsController(IUserService userService)
        {
            _userService = userService;
        }

        public int GetUserId()
        {
            return int.Parse(HttpContext.Session.GetString("userId"));
        }

        [HttpGet]
        public async Task<IActionResult> ListHardSoftSkillsPage()
        {
            return View(await _userService.GetUserByIdAsync(GetUserId()));
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
