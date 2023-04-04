using AWWW_Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_Lab1.Controllers {
    public class TagsController : UniqueController<Tag> {
        public TagsController(AppDbContext context): base(context) {
        }
    }
}
