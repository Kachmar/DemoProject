using System;
using System.Collections.Generic;
using CSTournament.Extensibility.Entities;
using CSTournament.Extensibility.Exceptions;
using CSTournament.Extensibility.Service;

namespace CSTournaments.Service
{
    internal class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository tournamentRepository;
        private readonly ITournamentValidator tournamentValidator;
        private readonly IPlayerRepository playerRepository;
        private readonly IGameRepository gameRepository;

        public TournamentService(ITournamentRepository tournamentRepository, ITournamentValidator tournamentValidator, IPlayerRepository playerRepository, IGameRepository gameRepository)
        {
            this.tournamentRepository = tournamentRepository;
            this.tournamentValidator = tournamentValidator;
            this.playerRepository = playerRepository;
            this.gameRepository = gameRepository;
        }

        public IReadOnlyCollection<Tournament> GetTournaments()
        {
            return tournamentRepository.GetAll();
        }

        public Tournament GetDetails(Guid id)
        {
            return tournamentRepository.Get(id);
        }

        public Tournament Create(string name)
        {
            tournamentValidator.ValidateName(name);
            Guid id = tournamentRepository.Create(name);
            return new Tournament(id, name);
        }

        public void Delete(Guid id)
        {
            var tournament = tournamentRepository.Get(id);
            if (tournament == null)
            {
                ThrowNoTournamentException(id);
            }

            tournamentRepository.Delete(id);
        }


        public void AssignPlayerToTournament(Guid tournamentId, Guid playerId)
        {
            var tournament = tournamentRepository.Get(tournamentId);
            if (tournament == null)
            {
                ThrowNoTournamentException(tournamentId);
            }

            Player player = GetPlayer(playerId);

            if (tournament.Players.Contains(player))
            {
                throw new CSTournamentDomainException($"Player with Id {playerId} is already assigned to {tournamentId}.");
            }
            tournament.Players.Add(player);
            tournamentRepository.Update(tournament);
        }

        public void AssignPlayerToGame(Guid gameId, Guid playerId)
        {
            Game game = gameRepository.Get(gameId);
            if (game == null)
            {
                throw new CSTournamentDomainException($"No such game with Id {gameId}.");
            }

            Player player = GetPlayer(playerId);

            if (!game.Tournament.Players.Contains(player))
            {
                throw new CSTournamentDomainException($"Player with Id {playerId} is not assigned to the tournament with Id {game.Tournament.Id}.");
            }
        }

        private Player GetPlayer(Guid playerId)
        {
            Player player = playerRepository.Get(playerId);
            if (player == null)
            {
                throw new CSTournamentDomainException($"No such player with Id {playerId}.");
            }
            return player;
        }

        private static void ThrowNoTournamentException(Guid id)
        {
            throw new CSTournamentDomainException($"No such tournament with Id {id}.");
        }
    }

    internal interface IGameRepository
    {
        Game Get(Guid gameId);
    }

    internal interface IPlayerRepository
    {
        Player Get(Guid playerId);
    }

    public interface ITournamentValidator
    {
        void ValidateName(string tournamentName);
    }

    class TournamentValidator : ITournamentValidator
    {
        public void ValidateName(string tournamentName)
        {
            if (String.IsNullOrEmpty(tournamentName))
            {
                throw new CSTournamentDomainException("Tournament Name cannot be empty.");
            }
        }
    }

    public interface ITournamentRepository
    {
        List<Tournament> GetAll();
        Guid Create(string tournamentName);
        Tournament Get(Guid id);
        void Delete(Guid id);
        void Update(Tournament tournament);
    }
}