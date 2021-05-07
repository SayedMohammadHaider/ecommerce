using Microsoft.AspNetCore.Mvc;
using ProjectECommerce.Models;
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

        public IActionResult Index(string name)
        {
            ProductViewModel productView = new ProductViewModel();
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                productView.Products = _context.Products;
                productView.CategoryName = "All Products";
            }
            else
            {
                productView.Products = _context.Products.Where(x => x.Category == name);
                productView.CategoryName = name;
            }
            return View(productView);
        }



        public IActionResult ProductDetails(int id, int quantity = 1, string quantityType = null)
        {
            ProductDetailsViewModel viewModel = new ProductDetailsViewModel();
            viewModel.Prooduct = _context.Products.Where(x => x.Id == id).FirstOrDefault();
            if (quantityType == "add")
            {
                quantity++;
            }
            else if (quantityType == "sub")
            {
                if (quantity > 1)
                {
                    quantity--;
                }
            }
            viewModel.Quantity = quantity;
            return View(viewModel);
        }
    }
}
