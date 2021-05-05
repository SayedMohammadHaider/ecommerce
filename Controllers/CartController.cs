using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectECommerce.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectECommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly ECommerceContext _context;

        public CartController(ECommerceContext context)
        {
            _context = context;
        }
        public IActionResult Index(string manageQuantity)
        {
            IEnumerable<Cart> cartList = _context.Carts.Include(x => x.Product).Include(x => x.User);
            return View(cartList);
        }

        public IActionResult ManageQuantity(int id)
        {
            var list = _context.Carts.Where(x => x.Id == id);
            return View();
        }
    }
}
