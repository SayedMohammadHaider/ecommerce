using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectECommerce.Models;
using ProjectECommerce.Models.DB;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ECommerceContext _context;

        public HomeController(ECommerceContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> topProducts = _context.Products.Take(12);
            return View(topProducts);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
