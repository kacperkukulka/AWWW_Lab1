namespace AWWW_Lab1.Models
{
    public class Position
    {
        public int ID { get; set; }
        public string Name { get; set; }  
        public List<Player> Players { get; set; }
        public List<MatchPlayer> MatchPlayers { get; set; }
    }
}
