using AWWW_Lab1.Interfaces;

namespace AWWW_Lab1.Models {
    public class PlayerVM : IModel {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public Team? Team { get; set; }
        public List<int> PositionsId { get; set; }
        public List<MatchPlayer> MatchPlayers { get; set; }
    }
}
