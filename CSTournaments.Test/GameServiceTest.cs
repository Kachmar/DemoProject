using System;
using CSTournaments.Extensibility.DataAccess.Repositories;
using CSTournaments.Extensibility.Entities;
using CSTournaments.Service;
using Moq;
using NUnit.Framework;

namespace CSTournaments.Test
{
    [TestFixture]
    public class GameServiceTest : UnitTestBase
    {
        private const string CategoryName = "CSTournaments.Service. " + nameof(GameService) + ". ";
        private const string AssignPlayerToGameMethod = nameof(GameService.AssignPlayerToGame) + ". ";
        private const string NoSuchGameMessage = "No such game with Id {0}.";
        private const string PlayerIsNotAssignedMessage = "Player with Id {0} is not assigned to the tournament with Id {1}.";
        private const string NoSuchPlayerMessage = "No such player with Id {0}.";
        private static readonly int GameId = 5;
        private static readonly int TournamentId = 6;
        private static readonly int PlayerId = 7;
        private Game game;
        private TournamentInfo tournament;
        private Player player;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
        }

        [SetUp]
        public void TestInitialize()
        {
            this.tournament = new TournamentInfo(TournamentId, "TournamentTest");
            this.game = new Game(GameId, "GameTest", this.tournament);
            this.player = new Player(PlayerId, "John", 30);
        }

        [Category(CategoryName)]
        [TestCase(TestName = AssignPlayerToGameMethod + "Game does not exist.")]
        public void AssignPlayerToGameNoGameFoundThrowsException()
        {
            var gameService = new GameService(null, null, this.GetGameRepositoryMock(false));
            Assert.That(
                ()
                => gameService.AssignPlayerToGame(GameId, PlayerId),
                Throws.Exception.With.Message.EqualTo(String.Format(NoSuchGameMessage, GameId)));
        }

        [Category(CategoryName)]
        [TestCase(TestName = AssignPlayerToGameMethod + "Player does not exist.")]
        public void AssignPlayerToGameNoPlayerFoundThrowsException()
        {
            var gameService = new GameService(this.GetPlayerRepositoryMock(false), null, this.GetGameRepositoryMock(true));
            Assert.That(
                ()
                    => gameService.AssignPlayerToGame(GameId, PlayerId),
                Throws.Exception.With.Message.EqualTo(String.Format(NoSuchPlayerMessage, PlayerId)));
        }

        [Category(CategoryName)]
        [TestCase(TestName = AssignPlayerToGameMethod + "Player is not assigned to the tournament.")]
        public void AssignPlayerToGameNotAssignedThrowsException()
        {
            var gameService = new GameService(this.GetPlayerRepositoryMock(true), this.GetTournamentRepositoryMock(), this.GetGameRepositoryMock(true));
            Assert.That(
                () =>
                gameService.AssignPlayerToGame(GameId, PlayerId),
                Throws.Exception.With.Message.EqualTo(String.Format(PlayerIsNotAssignedMessage, PlayerId, TournamentId)));
        }

        [Category(CategoryName)]
        [TestCase(TestName = AssignPlayerToGameMethod + "Player is assigned to the game successfully.")]
        public void AssignPlayerToGameSuccess()
        {
            this.tournament.Players.Add(this.player);
            var gameService = new GameService(this.GetPlayerRepositoryMock(true), this.GetTournamentRepositoryMock(), this.GetGameRepositoryMock(true));
            gameService.AssignPlayerToGame(GameId, PlayerId);
        }

        private ITournamentRepository GetTournamentRepositoryMock()
        {
            Mock<ITournamentRepository> mock = this.MockRepository.Create<ITournamentRepository>();
            mock.Setup(tournamentRepository => tournamentRepository.Get(TournamentId)).Returns(this.tournament);
            return mock.Object;
        }

        private IGameRepository GetGameRepositoryMock(bool gameExists)
        {
            Mock<IGameRepository> mock = this.MockRepository.Create<IGameRepository>();
            mock.Setup(gameRepository => gameRepository.Get(GameId)).Returns(gameExists ? this.game : null);
            return mock.Object;
        }

        private IPlayerRepository GetPlayerRepositoryMock(bool playerExists)
        {
            Mock<IPlayerRepository> mock = this.MockRepository.Create<IPlayerRepository>();
            mock.Setup(playerRepository => playerRepository.Get(PlayerId)).Returns(playerExists ? this.player : null);
            return mock.Object;
        }
    }
}