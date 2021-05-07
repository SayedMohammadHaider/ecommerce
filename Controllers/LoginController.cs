using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectECommerce.Models;
using ProjectECommerce.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly ECommerceContext _context;

        public LoginController(ECommerceContext context)
        {
            _context = context;
        }

        public IActionResult Index(LoginViewModel loginViewModel)
        {
            LoginViewModel viewModel = new LoginViewModel();
            var loginDetails = _context.Users.Where(x => loginViewModel.UserDetails != null && x.Username == loginViewModel.UserDetails.Username && x.Password == loginViewModel.UserDetails.Password).FirstOrDefault();
            if (loginDetails != null)
            {
                CookieOptions option = new CookieOptions();
                Response.Cookies.Append("UserId", loginDetails.Id.ToString());
                return RedirectToAction("Index", "Home");
                //viewModel.ErrorMessage = "";
                //viewModel.UserDetails = loginDetails;
            }
            else if (loginDetails == null && loginViewModel.UserDetails != null)
            {
                viewModel.ErrorMessage = "Invalid Username or password";
                viewModel.UserDetails = null;
            }
            return View(viewModel);
        }

        public IActionResult Registration()
        {
            User registrationDetails = new User();
            return View();
        }
    }
}
