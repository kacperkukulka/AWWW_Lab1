using AWWW_Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_Lab1.Controllers {
    public class PositionsController : Controller {
        AppDbContext _context;

        public PositionsController(AppDbContext context) {
            _context = context;
        }

        public IActionResult Index() {
            var a = _context.Positions.ToList();
            return View(_context.Positions.ToList());
        }

        [HttpPost]
        public IActionResult Index([Bind("Name")] Position position) {
            _context.Positions.Add(position);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
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
