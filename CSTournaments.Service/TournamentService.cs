using System.Collections.Generic;
using CSTournaments.Extensibility.DataAccess.Repositories;
using CSTournaments.Extensibility.Entities;
using CSTournaments.Extensibility.Exceptions;
using CSTournaments.Extensibility.Service;

namespace CSTournaments.Service
{
    internal class TournamentService : ServiceBase, ITournamentService
    {
        private readonly ITournamentRepository tournamentRepository;
        private readonly ITournamentValidator tournamentValidator;

        public TournamentService(ITournamentRepository tournamentRepository, ITournamentValidator tournamentValidator, IPlayerRepository playerRepository) : base(playerRepository)
        {
            this.tournamentRepository = tournamentRepository;
            this.tournamentValidator = tournamentValidator;
        }

        public IReadOnlyCollection<Tournament> GetTournaments()
        {
            return this.tournamentRepository.GetAll();
        }

        public Tournament GetDetails(int id)
        {
            return this.tournamentRepository.Get(id);
        }

        public Tournament Create(string name)
        {
            this.tournamentValidator.ValidateName(name);
            int id = this.tournamentRepository.Create(name);
            return new Tournament(id, name);
        }

        public void Delete(int id)
        {
            var tournament = this.tournamentRepository.Get(id);
            if (tournament == null)
            {
                ThrowNoTournamentException(id);
            }

            this.tournamentRepository.Delete(id);
        }

        public void AssignPlayerToTournament(int tournamentId, int playerId)
        {
            var tournament = this.tournamentRepository.Get(tournamentId);
            if (tournament == null)
            {
                ThrowNoTournamentException(tournamentId);
            }

            Player player = this.GetPlayer(playerId);

            if (tournament.Players.Contains(player))
            {
                throw new CSTournamentDomainException($"Player with Id {playerId} is already assigned to {tournamentId}.");
            }
            tournament.Players.Add(player);
            this.tournamentRepository.Update(tournament);
        }


        private static void ThrowNoTournamentException(int id)
        {
            throw new CSTournamentDomainException($"No such tournament with Id {id}.");
        }
    }
}