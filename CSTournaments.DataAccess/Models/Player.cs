using System.ComponentModel.DataAnnotations;

namespace CSTournaments.DataAccess.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public int Age { get; set; }
    }
}