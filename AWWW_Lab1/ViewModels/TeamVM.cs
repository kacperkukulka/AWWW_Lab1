using AWWW_Lab1.Interfaces;

namespace AWWW_Lab1.Models {
    public class TeamVM : IModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime FoundingDate { get; set; }
        public int LeagueId { get; set; }
    }
}
