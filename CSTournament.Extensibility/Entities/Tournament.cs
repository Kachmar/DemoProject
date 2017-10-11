using System;
using System.Collections.Generic;

namespace CSTournament.Extensibility.Entities
{
    public class Tournament
    {
        public Tournament(Guid id, string name)
        {
            Id = id;
            Name = name;
            Players = new List<Player>();
            Games = new List<Game>();
        }

        public Guid Id { get; }

        public string Name { get; }

        public List<Player> Players { get; set; }

        public List<Game> Games { get; set; }
    }
}