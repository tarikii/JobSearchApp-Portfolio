using JobSearchApp.BusinessLogic.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class HardSoftSkillsController : Controller
    {
        [HttpGet]
        public IActionResult ListHardSoftSkillsPage()
        {
            return View();
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
