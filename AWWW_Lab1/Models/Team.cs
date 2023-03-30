using AWWW_Lab1.Interfaces;

namespace AWWW_Lab1.Models
{
    public class Team: IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime FoundingDate { get; set; }
        public League League { get; set; }
        public List<Player> Players { get; set; }
        public List<Match> HomeMatches { get; set; }
        public List<Match> AwayMatches { get; set; }
    }
}
