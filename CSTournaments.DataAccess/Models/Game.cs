using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CSTournaments.DataAccess.Models;

namespace CSTournament.Extensibility.Entities
{
    public class Game
    {
        [Key]
        public Guid Id { get; }

        [StringLength(100)]
        public string Name { get; }

        public Tournament Tournament { get; }

        public List<Player> Players { get; set; }
    }
}