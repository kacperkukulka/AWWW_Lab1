using AWWW_Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Info(int id) {
            var category = _context.Categories.FirstOrDefault(i => i.Id == id);
            if (category == null)
                return RedirectToAction(nameof(Index));
            else
                return View(category);
        }

        public IActionResult Edit(int id) {
            var category = _context.Categories.FirstOrDefault(i => i.Id == id);
            if (category == null)
                return RedirectToAction(nameof(Index));
            else
                return View(category);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id, Name")] Category newCategory) {
            _context.Update(newCategory);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id) {
            _context.Remove(_context.Categories.Single(i => i.Id == id));
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
