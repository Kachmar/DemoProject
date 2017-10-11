using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CSTournament.Extensibility.Entities;

namespace CSTournaments.DataAccess.Models
{
    public class Tournament
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public virtual List<Player> Players { get; set; }

        public virtual List<Game> Games { get; set; }
    }
}