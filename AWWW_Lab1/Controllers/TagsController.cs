using AWWW_Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_Lab1.Controllers {
    public class TagsController : Controller {
        AppDbContext _context;

        public TagsController(AppDbContext context) {
            _context = context;
        }

        public IActionResult Index() {
            var a = _context.Tags.ToList();
            return View(_context.Tags.ToList());
        }

        public IActionResult AddNew() {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew([Bind("Name")] Tag tag) {
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
