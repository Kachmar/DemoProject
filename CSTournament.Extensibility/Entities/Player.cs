namespace CSTournaments.Extensibility.Entities
{
    public class Player
    {
        public Player(int id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        public int Id { get; }

        public string Name { get; }

        public int Age { get; }
    }
}