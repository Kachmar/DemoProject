using CSTournaments.Extensibility.DataAccess.Repositories;
using CSTournaments.Extensibility.Entities;
using CSTournaments.Extensibility.Exceptions;

namespace CSTournaments.Service
{
    internal abstract class ServiceBase
    {
        protected readonly IPlayerRepository PlayerRepository;

        public ServiceBase(IPlayerRepository playerRepository)
        {
            this.PlayerRepository = playerRepository;
        }

        protected Player GetPlayer(int playerId)
        {
            Player player = this.PlayerRepository.Get(playerId);
            if (player == null)
            {
                throw new CSTournamentDomainException($"No such player with Id {playerId}.");
            }
            return player;
        }
    }
}