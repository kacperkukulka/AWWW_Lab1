using AWWW_Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AWWW_Lab1.Controllers {
    public class CommentsController : Controller {
        private readonly AppDbContext _context;
        
        public CommentsController(AppDbContext context) {
            _context = context;
        }

        public async Task<IActionResult> AddNew(int id) {
            var article = await _context.Articles
                .FirstOrDefaultAsync(x => x.Id == id);

            if(article != null) {
                ViewBag.ArticleId = id;
                return View();
            }
            return RedirectToAction("Index", "Articles");
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(Comment comment, int ArticleId) {
            var article = await _context.Articles
                .Include(x => x.Comments)
                .FirstOrDefaultAsync(x => x.Id == ArticleId);

            if (article != null) {
                comment.Id = 0;
                comment.Article = article;
                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Articles");
        }

        public async Task<IActionResult> Edit(int id) {
            var comment = await _context.Comments
                .FirstOrDefaultAsync(x => x.Id == id);

            if (comment != null) {
                return View(comment);
            }
            return RedirectToAction("Index", "Articles");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Comment newComment) {
            if (newComment != null) {
                _context.Comments.Update(newComment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Articles");
        }

        public async Task<IActionResult> Delete(int id) {
            var comment = await _context.Comments
                .FirstOrDefaultAsync(x => x.Id == id);
            if(comment != null) {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Articles");
        }
    }
}
