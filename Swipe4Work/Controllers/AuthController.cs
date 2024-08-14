using Microsoft.AspNetCore.Mvc;
using Swipe4Work.BusinessLogic.Interfaces;
using Swipe4Work.Domain.Models;
using Swipe4Work.DataTransferObject;

namespace Swipe4Work.Controllers
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
            return View();
        }

        public IActionResult ForgotPasswordPage()
        {
            return View();
        }

        public IActionResult SelectEntityOptionPage() 
        {
            return View();
        }

        public IActionResult RegisterRecruiterOrCandidatePage() 
        { 
            return View();
        } 
        
        public IActionResult RegisterBusinessPage() 
        { 
            return View();
        }

        public IActionResult RegisterPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AuthenticateUser(string userName, string password)
        {
            User user = await _userService.AuthenticateUserAsync(userName, password);
            if (user != null) 
            { 
                return RedirectToAction("HomePage", "Home");
            }

            return RedirectToAction("LoginPage", "Auth");

        }

        //[HttpPost]
        //public async Task<IActionResult> RegisterCandidateOrRecruiter()
        //{

        //}

        [HttpPost]
        public async Task<IActionResult> RegisterBusiness(CreateCompanyDTO company, CreateUserDTO user)
        {
            CompanyDTO newCompany = await _companyService.CreateCompanyAsync(company); // Crear la nueva Compañia

            CreateUserDTO newUserCompany = user;
            newUserCompany.CompanyId = newCompany.CompanyId; // Asignar empresa
            newUserCompany.RoleId = 3; //Asignar Rol

            UserDTO newUser = await _userService.CreateUserAsync(user);


            return RedirectToAction("HomeBusinessOrRecruiterPage","Home", new { userId = newUser.UserId });
        }
    }
}
