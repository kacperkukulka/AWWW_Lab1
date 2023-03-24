using AWWW_Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_Lab1.Controllers {
    public class LeaguesController : Controller {
        AppDbContext _context;

        public LeaguesController(AppDbContext context) {
            _context = context;
        }

        public IActionResult Index() {
            var a = _context.Leagues.ToList();
            return View(_context.Leagues.ToList());
        }

        public IActionResult AddNew() {
            return View(_context.Teams.ToList());
        }

        [HttpPost]
        public IActionResult AddNew([Bind("Name")] League league) {
            _context.Leagues.Add(league);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
