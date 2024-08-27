using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.BusinessLogic.Services;
using JobSearchApp.BusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class QuestionAndAnswerController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;

        public QuestionAndAnswerController(IQuestionService questionService, IAnswerService answerService)
        {
            _questionService = questionService;
            _answerService = answerService;
        }

        public int GetUserId()
        {
            return int.Parse(HttpContext.Session.GetString("userId"));
        }

        [HttpGet]
        public async Task<IActionResult> QuestionAndAnswerPage(int? selectedQuestionId)
        {
            // Fetch all questions
            IEnumerable<QuestionDto> allQuestions = await _questionService.GetAllQuestionsAsync();

            // Fetch all answers
            IEnumerable<AnswerDto> allAnswers = await _answerService.GetAllAnswersAsync();

            // Get the answers only that the user made
            IEnumerable<AnswerDto> userAnswers = allAnswers
                .Where(a => a.UserId == GetUserId());

            // Combine questions with their corresponding answers
            IEnumerable<QuestionAnswerDto> userQuestionsAndAnswers = allQuestions
                .Select(q => new QuestionAnswerDto
                {
                    QuestionId = q.QuestionId,
                    QuestionText = q.QuestionText,
                    Answer = userAnswers.FirstOrDefault(a => a.QuestionId == q.QuestionId)
                });

            ViewBag.SelectedQuestionId = selectedQuestionId;
            return View(userQuestionsAndAnswers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewAnswer(CreateAnswerDto dto)
        {
            int userId = GetUserId();
            dto.UserId = userId; // Ensure user ID is included in the DTO
            await _answerService.CreateAnswerAsync(dto, userId);

            // Redirect back to the QuestionAndAnswerPage with the selected question ID
            return RedirectToAction("QuestionAndAnswerPage", new { selectedQuestionId = dto.QuestionId });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAnswer(UpdateAnswerDto dto)
        {
            await _answerService.UpdateAnswerAsync(dto.AnswerId, dto);

            // Redirect back to the QuestionAndAnswerPage with the selected question ID
            return RedirectToAction("QuestionAndAnswerPage", new { selectedQuestionId = dto.QuestionId });
        }

    }
}
