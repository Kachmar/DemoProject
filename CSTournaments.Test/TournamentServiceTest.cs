using System;
using CSTournaments.Service;
using Moq;
using NUnit.Framework;

namespace CSTournaments.Test
{
    [TestFixture]
    public class TournamentServiceTest : UnitTestBase
    {
        private const string CategoryName = "TournamentService. " + nameof(TournamentService) + ". ";
        private const string AssignPlayerToGameMethod = nameof(TournamentService.AssignPlayerToGame) + ". ";
        private Guid existingGameId = Guid.NewGuid();

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
        }

        [SetUp]
        public void TestInitialize()
        {
        }

        [Category(CategoryName)]
        [TestCase(TestName = AssignPlayerToGameMethod + "Game does not exist.")]
        public void Test()
        {
            TournamentService tournamentService = new TournamentService(GetTournamentRepositoryMock(), GetTournamentValidatorMock(), GetPlayerRepositoryMock(), GetGameRepositoryMock());

            tournamentService.AssignPlayerToGame();
        }

        private IGameRepository GetGameRepositoryMock()
        {
            Mock<IGameRepository> mock = MockRepository.Create<IGameRepository>();

        }

        private IPlayerRepository GetPlayerRepositoryMock()
        {
            throw new System.NotImplementedException();
        }

        private ITournamentValidator GetTournamentValidatorMock()
        {
            throw new System.NotImplementedException();
        }

        private ITournamentRepository GetTournamentRepositoryMock()
        {
            throw new System.NotImplementedException();
        }
    }
}