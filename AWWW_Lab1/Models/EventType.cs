using AWWW_Lab1.Interfaces;

namespace AWWW_Lab1.Models
{
    public class EventType: IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MatchEvent> MatchEvents { get; set; }

    }
}
