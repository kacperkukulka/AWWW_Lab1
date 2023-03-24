using AWWW_Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_Lab1.Controllers {
    public class AuthorsController : Controller {
        AppDbContext _context;

        public AuthorsController(AppDbContext context) {
            _context = context;
        }
        
        public IActionResult Index() {
            var a = _context.Authors.ToList();
            return View(_context.Authors.ToList());
        }

        public IActionResult AddNew() {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew([Bind("FirstName, LastName")]Author author) {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
