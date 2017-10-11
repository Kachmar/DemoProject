using System;

namespace CSTournament.Extensibility.Entities
{
    public class Player
    {
        public Player(Guid id, string name, uint age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public Guid Id { get; }

        public string Name { get; }

        public uint Age { get; }
    }
}