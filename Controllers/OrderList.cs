using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectECommerce.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectECommerce.Controllers
{
    public class OrderList : Controller
    {
        private readonly ECommerceContext _context;

        public OrderList(ECommerceContext context)
        {
            _context = context;
        }
        public IActionResult Index(string searching)
        {
            IEnumerable<Order> orderList = null;
            int parsedInt;
            bool isValidNumber = int.TryParse(searching, out parsedInt);
            if (searching != null && isValidNumber)
            {
                orderList = _context.Orders.Include(x => x.Address).Include(x => x.OrderDetails).Where(x => x.Id == parsedInt);
            }
            else if (searching == null)
            {
                orderList = _context.Orders.Include(x => x.Address).Include(x => x.OrderDetails);
            }
            return View(orderList);
        }
    }
}
