using AWWW_Lab1.Interfaces;

namespace AWWW_Lab1.Models
{
    public class League: IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Level { get; set; }
        public List<Team> Teams { get; set; } = new List<Team>();
    }
}
