using System.Collections.Generic;

namespace CSTournaments.Extensibility.Entities
{
    public class TournamentInfo : Tournament
    {
        public TournamentInfo(int id, string name) : base(id, name)
        {
            this.Players = new List<Player>();
            this.Games = new List<Game>();
        }

        public List<Player> Players { get; set; }

        public List<Game> Games { get; set; }
    }
}