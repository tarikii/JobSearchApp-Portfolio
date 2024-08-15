using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.BusinessLogic.Services;
using JobSearchApp.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Reflection.Metadata;
using System;

namespace JobSearchApp.View.Controllers
{
    public class JobOffersController : Controller
    {
        private IUserService _userService;
        private IJobOfferService _jobOfferService;
        private ICompanyService _companyService;
        private IApplicationService _applicationService;

        public JobOffersController(IUserService userService, 
            IJobOfferService jobOfferService,
            IApplicationService applicationService)
        {
            _userService = userService;
            _jobOfferService = jobOfferService;
            _applicationService = applicationService;
        }


        // CANDIDATE SECTION
        [HttpGet]
        public IActionResult CardsOfJobsOffersPage()
        {
            // Retrieve the list of disliked job offers for the current user
            // get current user id from context/session


            // Fetch the updated job offers


            // Pass the updated job offers to the view
            return View();
        }

        [HttpGet]
        public IActionResult FilterJobOffersPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListOfJobsAppliedPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ApplyFilterJobOffers()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LikeJobOffer(int userId, int jobOfferId)
        {
            UserDto user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
                return NotFound("User not found");

            JobOfferDto jobOffer = await _jobOfferService.GetJobOfferByIdAsync(jobOfferId);

            if (jobOffer == null)
                return NotFound("Job offer not found");

            var createApplication = new CreateApplicationDto
            {
                UserId = userId,
                JobOfferId = jobOffer.JobOfferId,
                ApplicationDate = DateTime.Now,
                Status = "En proceso",
                SalaryExpected = 20000
            };

            await _applicationService.CreateApplicationAsync(createApplication);

            return RedirectToAction("CardsOfJobsOffersPage");
        }

        [HttpPost]
        public async Task<IActionResult> DislikeJobOffer(int userId, int jobOfferId)
        {
            UserDto user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
                return NotFound("User not found");

            JobOfferDto jobOffer = await _jobOfferService.GetJobOfferByIdAsync(jobOfferId);

            if (jobOffer == null)
                return NotFound("Job offer not found");

            return Ok();
        }


        // RECRUITER BUSINESS SECTION

        [HttpGet]
        public IActionResult FormNewJobOfferPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FormModificationJobOfferPage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AdministrationListJobOffersPage()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ListCandidatesOfJobOfferPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewJobOffer(CreateJobOfferDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _jobOfferService.CreateJobOfferAsync(dto);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateJobOffer(int jobOfferId, UpdateJobOfferDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _jobOfferService.UpdateJobOfferAsync(3, dto);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteJobOffer(DeleteJobOfferDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _jobOfferService.DeleteJobOfferAsync(dto.JobOfferId);

            return Ok();
        }
    }
}
