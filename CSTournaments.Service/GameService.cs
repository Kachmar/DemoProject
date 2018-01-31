using System.Configuration;
using System.Data.SqlClient;

using CSTournaments.Extensibility.DataAccess.Repositories;
using CSTournaments.Extensibility.Entities;
using CSTournaments.Extensibility.Exceptions;
using CSTournaments.Extensibility.Service;

namespace CSTournaments.Service
{
    internal class GameService : ServiceBase, IGameService
    {
        private readonly ITournamentRepository tournamentRepository;
        private readonly IGameRepository gameRepository;

        public GameService(IPlayerRepository playerRepository, ITournamentRepository tournamentRepository, IGameRepository gameRepository) : base(playerRepository)
        {
            this.tournamentRepository = tournamentRepository;
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

            if (player == null)
            {
                throw new CSTournamentDomainException($"No such player with Id {playerId}.");
            }

            TournamentInfo tournamentInfo = this.tournamentRepository.Get(game.Tournament.Id);

            if (!tournamentInfo.Players.Contains(player))
            {
                throw new CSTournamentDomainException($"Player with Id {playerId} is not assigned to the tournament with Id {game.Tournament.Id}.");
            }

            game.Players.Add(player);

            this.gameRepository.Save(game);
        }

        private TournamentInfo GetTournament(int tournamentId)
        {
            ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["LegacyDb"];
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                connection.Open();

                string query = $@"some query{tournamentId}";
                using (var command = new SqlCommand(query, connection))
                {
                    var result = (TournamentInfo)command.ExecuteScalar();
                    connection.Close();
                    return result;
                }
            }
        }

        private Game GetGame(int gameId)
        {
            ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["LegacyDb"];
            using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
            {
                connection.Open();

                string query = $@"some query{gameId}";
                using (var command = new SqlCommand(query, connection))
                {
                    var result = (Game)command.ExecuteScalar();
                    connection.Close();
                    return result;
                }
            }
        }
    }
}