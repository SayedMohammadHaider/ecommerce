using Microsoft.AspNetCore.Mvc;
using ProjectECommerce.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectECommerce.Controllers
{
    public class AddressController : Controller
    {
        private readonly ECommerceContext _context;

        public AddressController(ECommerceContext context)
        {
            _context = context;
        }
        public IActionResult Index(string searching)
        {
            Int32 userId = Convert.ToInt32(Request.Cookies["UserId"]);

            IEnumerable<Address> addressList = null;//_context.Addresses.ToList();
            if (searching != null)
            {
                addressList = _context.Addresses.Where(x => x.Name.Contains(searching) && x.UserId == userId).ToList();
            }
            else
            {
                addressList = _context.Addresses.Where(x => x.UserId == userId);
            }
            return View(addressList);
        }

        public IActionResult Details(long? id)
        {
            if (id == null || id == 0)
            {
                return View();
            }
            Address address = _context.Addresses.Find(id);
            return View(address);
        }

        // Get - Create
        public IActionResult Create()
        {
            return View();
        }

        // Post - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Address address)
        {
            address.UserId = Convert.ToInt32(Request.Cookies["UserId"]);
            _context.Addresses.Add(address);
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
            var address = _context.Addresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        // Post - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Address address)
        {
            address.UserId = Convert.ToInt32(Request.Cookies["UserId"]);
            _context.Addresses.Update(address);
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
            var address = _context.Addresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        // Post - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAddress(long? id)
        {
            var address = _context.Addresses.Find(id);
            if (address == null)
            {
                return NotFound();
            }
            _context.Addresses.Remove(address);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
