using System;
using System.Collections.Generic;
using CSTournament.Extensibility.Entities;

namespace CSTournament.Extensibility.Service
{
    public interface ITournamentService
    {
        Tournament GetDetails(Guid id);
        IReadOnlyCollection<Tournament> GetTournaments();
        Tournament Create(string name);
        void Delete(Guid id);
        void AssignPlayerToTournament(Guid tournamentId, Guid playerId);
        void AssignPlayerToGame(Guid gameId, Guid playerId);
    }
}