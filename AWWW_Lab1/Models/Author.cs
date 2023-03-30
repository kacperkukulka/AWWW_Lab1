using AWWW_Lab1.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace AWWW_Lab1.Models
{
    public class Author: IModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Article> Articles { get; set; }
    }
}
