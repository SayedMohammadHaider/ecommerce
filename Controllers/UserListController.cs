using Microsoft.AspNetCore.Mvc;
using ProjectECommerce.Models.DB;
using System.Collections.Generic;
using System.Linq;

namespace ProjectECommerce.Controllers
{
    public class UserListController : Controller
    {

        private readonly ECommerceContext _context;

        public UserListController(ECommerceContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searching)
        {
            IEnumerable<User> userList = null;//_context.Addresses.ToList();
            if (searching != null)
            {
                userList = _context.Users.Where(x => x.Name.Contains(searching)).ToList();
            }
            else
            {
                userList = _context.Users;
            }
            return View(userList);
        }

        public IActionResult Details(long? id)
        {
            if (id == null || id == 0)
            {
                return View();
            }
            User address = _context.Users.Find(id);
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
        public IActionResult Create(User user)
        {
            _context.Users.Add(user);
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
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // Post - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            _context.Users.Update(user);
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
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // Post - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAddress(long? id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
