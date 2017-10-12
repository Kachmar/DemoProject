using System.Collections.Generic;

namespace CSTournaments.Extensibility.Entities
{
    public class Game
    {
        public Game(int id, string name, Tournament tournament)
        {
            this.Name = name;
            this.Tournament = tournament;
            this.Id = id;
            this.Players = new List<Player>();
        }

        public int Id { get; }

        public string Name { get; }

        public Tournament Tournament { get; }

        public List<Player> Players { get; set; }
    }
}