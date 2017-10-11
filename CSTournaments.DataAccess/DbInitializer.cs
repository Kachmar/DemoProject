using System.Data.Entity;

namespace CSTournaments.DataAccess
{
    public class DbInitializer : CreateDatabaseIfNotExists<CSTournamentContext>
    {
        protected override void Seed(CSTournamentContext context)
        {
            base.Seed(context);
        }
    }
}