using AWWW_Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AWWW_Lab1.Controllers {
    public class LeaguesController : UniqueController<League> {

        public LeaguesController(AppDbContext context): base(context) {
        }
    }
}
