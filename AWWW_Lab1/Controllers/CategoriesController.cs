using AWWW_Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_Lab1.Controllers {
    public class CategoriesController : Controller {
        AppDbContext _context;

        public CategoriesController(AppDbContext context) {
            _context = context;
        }

        public IActionResult Index() {
            var a = _context.Categories.ToList();
            return View(_context.Categories.ToList());
        }

        public IActionResult AddNew() {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew([Bind("Name")] Category category) {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
