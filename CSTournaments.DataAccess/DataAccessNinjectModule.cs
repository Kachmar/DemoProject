using CSTournaments.DataAccess.Repositories;
using CSTournaments.Extensibility.DataAccess.Repositories;
using Ninject.Modules;

namespace CSTournaments.DataAccess
{
    public class DataAccessNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ITournamentRepository>().To<TournamentRepository>();
            this.Bind<IGameRepository>().To<GameRepository>();
            this.Bind<IPlayerRepository>().To<PlayerRepository>();
        }
    }
}