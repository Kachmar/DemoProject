using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CSTournaments.DataAccess.Models;

namespace CSTournaments.DataAccess
{
    public class CSTournamentContext : DbContext
    {
        public CSTournamentContext() : base("CSTournamentContext")
        {
            this.InitializeDatabase();
        }

        public DbSet<Tournament> Tournaments { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        private void InitializeDatabase()
        {
            Database.SetInitializer(new DbInitializer());
            if (!this.Database.Exists())
            {
                this.Database.Initialize(true);
            }
        }
    }
}