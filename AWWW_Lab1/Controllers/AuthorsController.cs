using AWWW_Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWWW_Lab1.Controllers {
    public class AuthorsController : Controller {
        AppDbContext _context;

        public AuthorsController(AppDbContext context) {
            _context = context;
        }
        
        public async Task<IActionResult> Index() {
            var lista = await _context.Authors.ToListAsync();
            return View(lista);
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

        public IActionResult Info(int id) {
            var author = _context.Authors.FirstOrDefault(i => i.Id == id);
            if (author == null)
                return RedirectToAction(nameof(Index));
            else
                return View(author);
        }

        public IActionResult Edit(int id) {
            var author = _context.Authors.FirstOrDefault(i => i.Id == id);
            if (author == null)
                return RedirectToAction(nameof(Index));
            else
                return View(author);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id, FirstName, LastName")] Author newAuthor) {
            _context.Update(newAuthor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id) {
            _context.Remove(_context.Authors.Single(i => i.Id == id));
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
