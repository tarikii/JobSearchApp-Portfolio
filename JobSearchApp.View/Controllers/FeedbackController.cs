using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JobSearchApp.View.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IApplicationService _applicationService;
        
        public FeedbackController(IFeedbackService feedbackService, IApplicationService applicationService)
        {
            _feedbackService = feedbackService;
            _applicationService = applicationService;
        }

        public int GetUserId()
        {
            return int.Parse(HttpContext.Session.GetString("userId"));
        }

        [HttpGet]
        public async Task<IActionResult> FormNewFeedbackPage(int id)
        {
            ApplicationDto application = await _applicationService.GetApplicationByIdAsync(id);

            ViewBag.RecruiterId = GetUserId();

            return View(application);
        }

        [HttpGet]
        public async Task<IActionResult> ViewFeedbackCandidatePage(int id, string returnUrl = null)
        {
            FeedbackDto feedback = await _feedbackService.GetFeedbackByIdAsync(id);

            ViewBag.ReturnUrl = returnUrl ?? Url.Action("ListApplicationJobOfferPage", "Application");
            return View(feedback);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewFeedBack(CreateFeedbackDto newFeedback)
        {
            FeedbackDto feedback = await _feedbackService.CreateFeedbackAsync(newFeedback);
            ApplicationDto application = await _applicationService.GetApplicationByIdAsync(feedback.ApplicationId);

            return RedirectToAction("ListCandidatesPostulatedJobOfferPage", "JobOffers", new { id = application.JobOfferId }); 
        }
    }
}
