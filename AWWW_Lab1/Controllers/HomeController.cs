using Microsoft.AspNetCore.Mvc;

namespace AWWW_Lab1.Controllers {
    public class HomeController : Controller {
        AppDbContext _context;

        public HomeController(AppDbContext context) {
            _context = context;
        }

        public IActionResult Index() {
            ViewBag.Title = "Home";
            return View(_context.Articles);
        }
    }
}
