using CSTournaments.Extensibility.DataAccess.Repositories;
using CSTournaments.Extensibility.Entities;
using CSTournaments.Extensibility.Exceptions;
using CSTournaments.Extensibility.Service;

namespace CSTournaments.Service
{
    internal class GameService : ServiceBase, IGameService
    {
        private readonly IGameRepository gameRepository;

        public GameService(IPlayerRepository playerRepository, IGameRepository gameRepository) : base(playerRepository)
        {
            this.gameRepository = gameRepository;
        }

        public void AssignPlayerToGame(int gameId, int playerId)
        {
            Game game = this.gameRepository.Get(gameId);
            if (game == null)
            {
                throw new CSTournamentDomainException($"No such game with Id {gameId}.");
            }

            Player player = this.GetPlayer(playerId);

            if (!game.Tournament.Players.Contains(player))
            {
                throw new CSTournamentDomainException($"Player with Id {playerId} is not assigned to the tournament with Id {game.Tournament.Id}.");
            }
        }
    }
}