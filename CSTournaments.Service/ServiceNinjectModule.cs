using CSTournament.Extensibility.DataAccess;
using CSTournament.Extensibility.Service;
using Ninject.Modules;

namespace CSTournaments.Service
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITournamentService>().To<TournamentService>();
            Bind<IGuidProvider>().To<GuidProvider>();
        }
    }
}