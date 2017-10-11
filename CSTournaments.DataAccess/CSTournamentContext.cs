using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CSTournaments.DataAccess.Models;

namespace CSTournaments.DataAccess
{
    public class CSTournamentContext : DbContext
    {
        public CSTournamentContext() : base("CSTournamentContext")
        {
            InitializeDatabase();
        }

        public DbSet<Tournament> Tournaments { get; set; }
        //public DbSet<Enrollment> Enrollments { get; set; }
        //public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        private void InitializeDatabase()
        {
            Database.SetInitializer(new DbInitializer());
            if (!Database.Exists())
            {
                Database.Initialize(true);
            }
        }
    }
}
