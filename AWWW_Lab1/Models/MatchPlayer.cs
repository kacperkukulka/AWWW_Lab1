namespace AWWW_Lab1.Models
{
    public class MatchPlayer
    {
        public int Id { get; set; }
        public Match Match { get; set; }
        public Player Player { get; set; }
        public Position Position { get; set; }
        public List<MatchEvent> MatchEvents { get; set; }
    }
}
