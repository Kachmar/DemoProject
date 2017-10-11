using System;
using System.Collections.Generic;

namespace CSTournament.Extensibility.Entities
{
    public class Game
    {
        public Game(Guid id, string name, Tournament tournament)
        {
            Name = name;
            Tournament = tournament;
            Id = id;
            Players = new List<Player>();
        }

        public Guid Id { get; }

        public string Name { get; }

        public Tournament Tournament { get; }

        public List<Player> Players { get; set; }
    }
}