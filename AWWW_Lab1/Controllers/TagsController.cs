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

        public IActionResult Info(int id) {
            var tag = _context.Tags.FirstOrDefault(i => i.Id == id);
            if (tag == null)
                return RedirectToAction(nameof(Index));
            else
                return View(tag);
        }

        public IActionResult Edit(int id) {
            var tag = _context.Tags.FirstOrDefault(i => i.Id == id);
            if (tag == null)
                return RedirectToAction(nameof(Index));
            else
                return View(tag);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id, Name")] Tag newTag) {
            _context.Update(newTag);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id) {
            _context.Remove(_context.Tags.Single(i => i.Id == id));
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
