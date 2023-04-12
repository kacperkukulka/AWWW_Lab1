using AWWW_Lab1.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AWWW_Lab1.Controllers {
    public class TeamsController : Controller {
        private AppDbContext _context;
        public TeamsController(AppDbContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index() {
            var teams = await _context.Teams
                .Include(x => x.League)
                .ToListAsync();
            return View(teams);
        }

        public async Task<IActionResult> AddNew() {
            var leagues = await _context.Leagues.ToListAsync();
            ViewBag.leagues = leagues;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(TeamVM teamvm) {
            League league = await _context.Leagues.FirstOrDefaultAsync(x => x.Id == teamvm.LeagueId);
            Team team = new Team {
                City = teamvm.City,
                Country = teamvm.Country,
                FoundingDate = teamvm.FoundingDate,
                Name = teamvm.Name,
                League = league
            };

            _context.Teams.Add(team);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
