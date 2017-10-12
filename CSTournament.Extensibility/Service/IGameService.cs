namespace CSTournaments.Extensibility.Service
{
    public interface IGameService
    {
        void AssignPlayerToGame(int gameId, int playerId);
    }
}