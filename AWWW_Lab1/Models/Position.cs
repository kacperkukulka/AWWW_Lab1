using AWWW_Lab1.Interfaces;

namespace AWWW_Lab1.Models
{
    public class Position: IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }  
        public List<Player> Players { get; set; }
        public List<MatchPlayer> MatchPlayers { get; set; }
    }
}
