using CSTournaments.Extensibility.Entities;

namespace CSTournaments.Extensibility.DataAccess.Repositories
{
    public interface IPlayerRepository
    {
        Player Get(int playerId);
    }
}