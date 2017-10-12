using CSTournaments.Extensibility.Service;
using Ninject.Modules;

namespace CSTournaments.Service
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ITournamentService>().To<TournamentService>();
            this.Bind<IGameService>().To<GameService>();
            this.Bind<ITournamentValidator>().To<TournamentValidator>();
        }
    }
}