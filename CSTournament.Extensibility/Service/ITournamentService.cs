using System.Collections.Generic;
using CSTournaments.Extensibility.Entities;

namespace CSTournaments.Extensibility.Service
{
    public interface ITournamentService
    {
        TournamentInfo GetDetails(int id);

        IReadOnlyCollection<Tournament> GetTournaments();

        Tournament Create(string name);

        void Delete(int id);

        void AssignPlayerToTournament(int tournamentId, int playerId);
    }
}