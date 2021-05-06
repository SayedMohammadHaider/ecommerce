using Microsoft.AspNetCore.Mvc;
using ProjectECommerce.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {

        private readonly ECommerceContext _context;

        public ProductController(ECommerceContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> prodList = _context.Products;
            return View(prodList);
        }



        public IActionResult ProductDetails()
        {
            return View();
        }
    }
}
