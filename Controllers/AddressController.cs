using Microsoft.AspNetCore.Mvc;
using ProjectECommerce.Models;
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
        private Address _address = null;

        public AddressController(ECommerceContext context)
        {
            _context = context;
            _address = new Address();
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
        public IActionResult Create(AddressViewModel address)
        {
            _address.AddressLine1 = address.AddressLine1;
            _address.AddressLine2 = address.AddressLine2;
            _address.City = address.City;
            _address.Area = address.Area;
            _address.Pincode = address.Pincode;
            _address.Country = address.Country;
            _address.Landmark = address.Landmark;
            _address.Name = address.Name;
            _address.Email = address.Email;
            _address.Mobile = address.Mobile;
            _address.UserId = Convert.ToInt32(Request.Cookies["UserId"]);
            _context.Addresses.Add(_address);
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
            AddressViewModel viewModel = new AddressViewModel();
            viewModel.Id = address.Id;
            viewModel.AddressLine1 = address.AddressLine1;
            viewModel.AddressLine2 = address.AddressLine2;
            viewModel.City = address.City;
            viewModel.Area = address.Area;
            viewModel.Pincode = address.Pincode;
            viewModel.Country = address.Country;
            viewModel.Landmark = address.Landmark;
            viewModel.Name = address.Name;
            viewModel.Email = address.Email;
            viewModel.Mobile = address.Mobile;
            if (address == null)
            {
                return NotFound();
            }
            return View(viewModel);
        }

        // Post - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AddressViewModel address)
        {
            _address.Id = address.Id;
            _address.AddressLine1 = address.AddressLine1;
            _address.AddressLine2 = address.AddressLine2;
            _address.City = address.City;
            _address.Area = address.Area;
            _address.Pincode = address.Pincode;
            _address.Country = address.Country;
            _address.Landmark = address.Landmark;
            _address.Name = address.Name;
            _address.Email = address.Email;
            _address.Mobile = address.Mobile;
            _address.UserId = Convert.ToInt32(Request.Cookies["UserId"]);
            _context.Addresses.Update(_address);
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
