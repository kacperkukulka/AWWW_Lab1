using AWWW_Lab1.Interfaces;
using AWWW_Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;

namespace AWWW_Lab1.Controllers {
    public abstract class UniqueController<T> : Controller 
            where T: class, IModel, new() {
        AppDbContext _context;
        string [] classNames = typeof(T).GetProperties().Select(i => i.Name).ToArray();

        public UniqueController(AppDbContext context) {
            _context = context;
        }

        public async Task<IActionResult> Index() {
            DbSet<T> dbSet = _context.Set<T>();
            return View(dbSet.ToList());
        }

        public async Task<IActionResult> AddNew() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(IFormCollection formCollection) {
            T t = new T();
            int i = 0;
            foreach(var a in formCollection) {
                if (i++ == formCollection.Count - 1)
                    break;
                var property = typeof(T).GetProperty(a.Key);
                property!.SetValue(t, Convert.ChangeType(a.Value[0]!, property.PropertyType));
            }
            await _context.Set<T>()!.AddAsync(t);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Info(int id) {
            var author = await _context.Set<T>()!.FirstOrDefaultAsync(i => i.Id == id);
            if (author == null)
                return RedirectToAction(nameof(Index));
            else
                return View(author);
        }
        /* 
        public IActionResult Edit(int id) {
            var author = _context.Authors.FirstOrDefault(i => i.Id == id);
            if (author == null)
                return RedirectToAction(nameof(Index));
            else
                return View(author);
        }

        [HttpPost]
        public IActionResult Edit([Bind()] Author newAuthor) {
            _context.Update(newAuthor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id) {
            _context.Remove(_context.Authors.Single(i => i.Id == id));
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }*/
    }
}
