using System.Collections.Generic;

namespace CSTournaments.Extensibility.Entities
{
    public class Tournament
    {
        public Tournament(int id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.Players = new List<Player>();
            this.Games = new List<Game>();
        }

        public int Id { get; }

        public string Name { get; }

        public List<Player> Players { get; set; }

        public List<Game> Games { get; set; }
    }
}