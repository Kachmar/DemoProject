using System.Collections.Generic;
using CSTournaments.Extensibility.Entities;

namespace CSTournaments.Extensibility.DataAccess.Repositories
{
    public interface ITournamentRepository
    {
        List<Tournament> GetAll();

        int Create(string tournamentName);

        Tournament Get(int id);

        void Delete(int id);

        void Update(Tournament tournament);
    }
}