using System.Data.Entity;

namespace CSTournaments.DataAccess
{
    public class DbInitializer : CreateDatabaseIfNotExists<CSTournamentContext>
    {
    }
}