using CSTournaments.Extensibility.Entities;

namespace CSTournaments.Extensibility.DataAccess.Repositories
{
    public interface IGameRepository
    {
        Game Get(int gameId);
    }
}