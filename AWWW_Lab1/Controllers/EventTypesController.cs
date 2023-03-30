using AWWW_Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_Lab1.Controllers {
    public class EventTypesController : Controller {
        AppDbContext _context;

        public EventTypesController(AppDbContext context) {
            _context = context;
        }

        public IActionResult Index() {
            var a = _context.EventTypes.ToList();
            return View(_context.EventTypes.ToList());
        }

        public IActionResult AddNew() {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew([Bind("Name")] EventType eventType) {
            _context.EventTypes.Add(eventType);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
