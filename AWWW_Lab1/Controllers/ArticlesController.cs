using Microsoft.AspNetCore.Mvc;
using AWWW_Lab1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;

namespace AWWW_Lab1.Controllers {
    public class ArticlesController : Controller {
        private readonly AppDbContext _context;

        public ArticlesController(AppDbContext context){
            _context = context;
        }

        public async Task<IActionResult> Index() {
            var allArticles = await _context.Articles
                .Include(x => x.Author)
                .Include(x => x.Category)
                .Include(x => x.Tags)
                .Include(x => x.Comments)
                .ToListAsync();
            return View(allArticles);
        }

        public async Task<IActionResult> AddNew() {
            ViewBag.Authors = await _context.Authors.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();
            var tags = await _context.Tags.ToListAsync();
            ViewBag.Tags = new SelectList(tags, nameof(Tag.Id), nameof(Tag.Name));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNew(Article article, int CategoryId, List<int> TagsId, int AuthorId) {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == CategoryId);
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == AuthorId);
            if (category == null || author == null)
                return RedirectToAction("Index");

            var tags = await _context.Tags.Where(x => TagsId.Contains(x.Id)).ToListAsync();
            article.Category = category;
            article.Author = author;
            article.Tags = tags;
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id) {
            var article = await _context.Articles
                .Where(x => x.Id == id)
                .Include(x => x.Author)
                .Include(x => x.Category)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync();
            if (article == null)
                return RedirectToAction("Index");
            ViewBag.Authors = await _context.Authors.ToListAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Tags = await _context.Tags.ToListAsync();
            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Article article, int CategoryId, List<int> TagsId, int AuthorId) {
            var newArticle = await _context.Articles
                .Where(x => x.Id == article.Id)
                .Include(x => x.Author)
                .Include(x => x.Category)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync();

            if (newArticle == null)
                return RedirectToAction("Index");

            newArticle.Title = article.Title;
            newArticle.Lead = article.Lead;
            newArticle.CreationDate = article.CreationDate;
            newArticle.Content = article.Content;

            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == CategoryId);
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == AuthorId);
            if (category == null || author == null)
                return RedirectToAction("Index");

            article.Category = category;
            article.Author = author;

            newArticle.Tags.Clear();
            var tags = await _context.Tags.Where(x => TagsId.Contains(x.Id)).ToListAsync();
            newArticle.Tags = tags;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id) {
            var toDelete = await _context.Articles.FirstOrDefaultAsync(x => x.Id == id);
            if(toDelete != null) {
                _context.Articles.Remove(toDelete);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
