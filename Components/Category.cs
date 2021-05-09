using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectECommerce.Models;
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
            LoginUserViewModel viewModel = new LoginUserViewModel();
            //read cookie from Request object  
            string userId = Request.Cookies["UserId"];

            IEnumerable<Product> products = _context.Products.AsEnumerable()
                   .GroupBy(a => a.Category)
                   .Select(g => g.First())
                   .ToList();
            User currentUser = _context.Users.Where(x => x.Id == Convert.ToInt32(userId)).FirstOrDefault();
            viewModel.Products = products;
            viewModel.UserId = userId;
            if (currentUser != null && currentUser.IsAdmin.HasValue)
            {
                viewModel.IsAdmin = currentUser.IsAdmin.Value;
            }
            else
            {
                viewModel.IsAdmin = false;
            }
            return View(viewModel);
        }
    }
}
