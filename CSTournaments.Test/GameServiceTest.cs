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
        private static readonly int GameId = 5;
        private static readonly int TournamentId = 6;
        private static readonly int PlayerId = 7;
        private Game game;
        private Tournament tournament;
        private Player player;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
        }

        [SetUp]
        public void TestInitialize()
        {
            this.tournament = new Tournament(TournamentId, "TournamentTest");
            this.game = new Game(GameId, "GameTest", this.tournament);
            this.tournament.Games.Add(this.game);
            this.player = new Player(PlayerId, "John", 30);
        }

        [Category(CategoryName)]
        [TestCase(TestName = AssignPlayerToGameMethod + "Game does not exist.")]
        public void AssignPlayerToGameNoGameFoundThrowsException()
        {
            var gameService = new GameService(null, this.GetGameRepositoryMock(false));
            Assert.That(
                ()
                => gameService.AssignPlayerToGame(GameId, TournamentId),
                Throws.Exception.With.Message.EqualTo(String.Format(NoSuchGameMessage, GameId)));
        }

        [Category(CategoryName)]
        [TestCase(TestName = AssignPlayerToGameMethod + "Player is not assigned to the tournament.")]
        public void AssignPlayerToGameNotAssignedThrowsException()
        {
            var gameService = new GameService(this.GetPlayerRepositoryMock(), this.GetGameRepositoryMock(true));
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
            var gameService = new GameService(this.GetPlayerRepositoryMock(), this.GetGameRepositoryMock(true));
            gameService.AssignPlayerToGame(GameId, PlayerId);
        }


        private IGameRepository GetGameRepositoryMock(bool gameExists)
        {
            Mock<IGameRepository> mock = this.MockRepository.Create<IGameRepository>();
            mock.Setup(gameRepository => gameRepository.Get(GameId)).Returns(gameExists ? this.game : null);
            return mock.Object;
        }

        private IPlayerRepository GetPlayerRepositoryMock()
        {
            Mock<IPlayerRepository> mock = this.MockRepository.Create<IPlayerRepository>();
            mock.Setup(playerRepository => playerRepository.Get(PlayerId)).Returns(this.player);
            return mock.Object;
        }
    }
}