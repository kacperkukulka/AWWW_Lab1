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
            return View(await dbSet.ToListAsync());
        }

        public IActionResult AddNew() {
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
            var property = await _context.Set<T>()!.FirstOrDefaultAsync(i => i.Id == id);
            if (property == null)
                return RedirectToAction(nameof(Index));
            else
                return View(property);
        }
         
        public async Task<IActionResult> Edit(int id) {
            var property = await _context.Set<T>()!.FirstOrDefaultAsync(i => i.Id == id);
            if (property == null)
                return RedirectToAction(nameof(Index));
            else
                return View(property);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(IFormCollection formCollection) {
            T t = new T();
            int i = 0;
            foreach (var a in formCollection) {
                if (i++ == formCollection.Count - 1)
                    break;
                var property = typeof(T).GetProperty(a.Key);
                property!.SetValue(t, Convert.ChangeType(a.Value[0]!, property.PropertyType));
            }
            _context.Update(t);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Delete(int id) {
            _context.Remove(_context.Set<T>()!.Single(i => i.Id == id));
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
