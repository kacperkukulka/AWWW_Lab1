﻿namespace AWWW_Lab1.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }
        public int Minute { get; set; }
        public Match Match { get; set; }
        public EventType EventType { get; set; }
        public MatchPlayer? MatchPlayer { get; set; }

    }
}
