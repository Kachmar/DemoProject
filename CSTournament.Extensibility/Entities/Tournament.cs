
namespace CSTournaments.Extensibility.Entities
{
    public class Tournament
    {
        public Tournament(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; }

        public string Name { get; }
    }
}