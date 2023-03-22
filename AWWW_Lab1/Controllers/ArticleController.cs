using Microsoft.AspNetCore.Mvc;
using AWWW_Lab1.Models;

namespace AWWW_Lab1.Controllers {
    public class ArticleController : Controller {
        public IActionResult Index(int id=1) {
            var article = new List<Article> {
                new Article{
                    Id = 1,
                    Title = "Artykuł 1",
                    Content = "Lorem1 ipsum...",
                    CreationDate = DateTime.Now
                },
                new Article{
                    Id = 2,
                    Title = "Artykuł 2",
                    Content = "Lorem2 ipsum...",
                    CreationDate = DateTime.Now
                },
                new Article{
                    Id = 3,
                    Title = "Artykuł 3",
                    Content = "Lorem3 ipsum...",
                    CreationDate = DateTime.Now
                }
            };
            
            return View(article[id-1]);
        }
    }
}
