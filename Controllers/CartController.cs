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
            Int32 userId = Convert.ToInt32(Request.Cookies["UserId"]);
            IEnumerable<Cart> cartList = _context.Carts.Where(x => x.UserId == userId).Include(x => x.Product);
            return View(cartList);
        }

        public IActionResult ManageQuantity(int id, int quantity)
        {
            Int32 userId = Convert.ToInt32(Request.Cookies["UserId"]);
            if (userId == 0)
            {
                return RedirectToAction("Index", "Login");
            }
            Cart addDataToCart = new Cart();
            var cartDetails = _context.Carts.Where(x => x.ProductId == id && x.UserId == userId).FirstOrDefault();
            if (cartDetails != null)
            {
                cartDetails.Quantity = (Convert.ToInt32(cartDetails.Quantity) + quantity).ToString();
                _context.Carts.Update(cartDetails);
            }
            else
            {
                addDataToCart.ProductId = id;
                addDataToCart.Quantity = quantity.ToString();
                addDataToCart.UserId = userId;
                _context.Carts.Add(addDataToCart);
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteItemFromCart(int id)
        {
            var cartDetails = _context.Carts.Where(x => x.Id == id).FirstOrDefault();
            _context.Carts.Remove(cartDetails);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
