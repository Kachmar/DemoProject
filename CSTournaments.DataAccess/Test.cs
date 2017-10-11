using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSTournaments.DataAccess
{
    public static class Test
    {
        public static void TestMethod()
        {
            CSTournamentContext context = new CSTournamentContext();
            var x = context.Tournaments.Where(p => true);
        }
    }
}
