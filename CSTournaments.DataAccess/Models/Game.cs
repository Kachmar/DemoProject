using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSTournaments.DataAccess.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public Tournament Tournament { get; set; }

        public virtual List<Player> Players { get; set; }
    }
}