using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectECommerce.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectECommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly ECommerceContext _context;

        public OrderController(ECommerceContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searching)
        {
            int userId = Convert.ToInt32(Request.Cookies["UserId"]);
            IEnumerable<Order> orderList = null;
            int parsedInt;
            bool isValidNumber = int.TryParse(searching, out parsedInt);
            if (searching != null && isValidNumber)
            {
                orderList = _context.Orders.Include(x => x.Address).Include(x => x.OrderDetails).Where(x => x.UserId == userId && x.Id == parsedInt);
            }
            else if (searching == null)
            {
                orderList = _context.Orders.Include(x => x.Address).Include(x => x.OrderDetails).Where(x => x.UserId == userId);
            }
            return View(orderList);
        }
        public IActionResult OrderDetails(int orderId)
        {
            Order orderDetails = _context.Orders.Include(x => x.Address).Include(x => x.OrderDetails).ThenInclude(x => x.Product).Where(x => x.Id == orderId).FirstOrDefault();
            return View(orderDetails);
        }
    }
}
