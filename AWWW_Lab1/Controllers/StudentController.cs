using Microsoft.AspNetCore.Mvc;
using AWWW_Lab1.Models;

namespace AWWW_Lab1.Controllers {
    public class StudentController : Controller {
        public IActionResult Index(int id=1) {
            var student = new List<Student>{
                new Student {
                    Id = 1,
                    FirstName = "Kacper",
                    LastName = "Kukułka",
                    indexNumber = 134990,
                    birthDate = DateTime.Now,
                    Faculty = "Informatyka"
                },
                new Student {
                    Id = 2,
                    FirstName = "Martyna",
                    LastName = "Nowacka",
                    indexNumber = 131232,
                    birthDate = DateTime.Now,
                    Faculty = "Informatyka"
                },
                new Student {
                    Id = 3,
                    FirstName = "Dawid",
                    LastName = "Płuciennik",
                    indexNumber = 124990,
                    birthDate = DateTime.Now,
                    Faculty = "Zarządzanie"
                }
            };
            
            return View(student[id-1]);
        }
    }
}
