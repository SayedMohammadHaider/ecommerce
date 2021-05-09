using Microsoft.AspNetCore.Mvc;
using ProjectECommerce.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectECommerce.Controllers
{
    public class ProductListController : Controller
    {
        private readonly ECommerceContext _context;

        public ProductListController(ECommerceContext context)
        {
            _context = context;
        }
        public IActionResult Index(string searching)
        {
            IEnumerable<Product> productList = null;//_context.Addresses.ToList();
            if (searching != null)
            {
                productList = _context.Products.Where(x => x.Name.Contains(searching)).ToList();
            }
            else
            {
                productList = _context.Products;
            }

            return View(productList);
        }

        public IActionResult Details(long? id)
        {
            if (id == null || id == 0)
            {
                return View();
            }
            Product product = _context.Products.Find(id);
            return View(product);
        }

        // Get - Create
        public IActionResult Create()
        {
            return View();
        }

        // Post - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // Get - Edit
        public IActionResult Edit(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Post - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Get - Delete
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Post - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAddress(long? id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
