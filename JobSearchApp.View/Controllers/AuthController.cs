using JobSearchApp.BusinessLogic.DTOs;
using JobSearchApp.BusinessLogic.Interfaces;
using JobSearchApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobSearchApp.View.Controllers
{
    public class AuthController : Controller
    {
        private IUserService _userService;
        private ICompanyService _companyService;

        public AuthController(IUserService userService, ICompanyService companyService)
        {
            _userService = userService; 
            _companyService = companyService;
        }
        public IActionResult LoginPage()
        {
            ViewBag.Carrousel = "No";
            return View();
        }

        public IActionResult ForgotPasswordPage()
        {
            ViewBag.Carrousel = "No";
            return View();
        }

        public IActionResult SelectEntityOptionPage()
        {
            ViewBag.Carrousel = "No";
            return View();
        }

        public async Task<IActionResult> RegisterUserPage(string id)
        {
            ViewBag.Carrousel = "No";
            ViewBag.Role = id; // Role
            return View(await _companyService.GetAllCompaniesAsync());
        }

        [HttpPost]
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("userId");

            return RedirectToAction("HomePage", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> AuthenticateUser(string userName, string password)
        {
            UserDto user = await _userService.AuthenticateUserAsync(userName, password);

            if (user != null)
            {
                HttpContext.Session.SetString("userId", user.UserId.ToString());

                return RedirectToAction("HomeLoggedPage", "Home");
            }

            return RedirectToAction("LoginPage", "Auth");

        }

        [HttpPost]
        public async Task<IActionResult> RegisterCandidateOrRecruiter(string role, CreateUserDto user)
        {
            if (role == "candidate")
            {
                UserDto newUser = await _userService.CreateUserAsync(user, 3);

                HttpContext.Session.SetString("userId", newUser.UserId.ToString());

                return RedirectToAction("HomeLoggedPage", "Home");
            }
            else if (role == "recruiter")
            {
                UserDto newUser = await _userService.CreateUserAsync(user, 2);

                HttpContext.Session.SetString("userId", newUser.UserId.ToString());

                return RedirectToAction("HomeLoggedPage", "Home");
            }

            ViewBag.Role = role; // Role
            return RedirectToAction("RegisterUserPage", "Auth");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterBusiness(CreateCompanyDto company, CreateUserDto user)
        {
            CompanyDto newCompany = await _companyService.CreateCompanyAsync(company); // Crear la nueva Compañia
            UserDto newUser = await _userService.CreateUserAsync(user, newCompany.CompanyId, 4);

            HttpContext.Session.SetString("userId", newUser.UserId.ToString());

            return RedirectToAction("HomeLoggedPage", "Home");
        }
    }
}
