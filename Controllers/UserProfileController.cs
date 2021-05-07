using Microsoft.AspNetCore.Mvc;
using ProjectECommerce.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly ECommerceContext _context;

        public UserProfileController(ECommerceContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            int userId = Convert.ToInt32(Request.Cookies["UserId"]);
            var userDetails = _context.Users.Where(x => x.Id == userId).FirstOrDefault();
            return View(userDetails);
        }
    }
}
