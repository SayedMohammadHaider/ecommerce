using Microsoft.AspNetCore.Mvc;
using ProjectECommerce.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectECommerce.Components
{
    public class Category : ViewComponent
    {

        private readonly ECommerceContext _context;

        public Category(ECommerceContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            IEnumerable<Product> products = _context.Products.AsEnumerable()
                   .GroupBy(a => a.Category)
                   .Select(g => g.First())
                   .ToList();
            return View(products);
        }
    }
}
