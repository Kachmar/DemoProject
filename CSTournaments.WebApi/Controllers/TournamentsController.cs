using System.Collections.Generic;
using System.Web.Http;
using CSTournaments.Extensibility.Entities;
using CSTournaments.Extensibility.Exceptions;
using CSTournaments.Extensibility.Service;

namespace CSTournaments.WebApi.Controllers
{
    [RoutePrefix("tournaments")]
    public class TournamentsController : ApiController
    {
        private readonly ITournamentService tournamentService;

        public TournamentsController(ITournamentService tournamentService)
        {
            this.tournamentService = tournamentService;
        }

        [HttpGet]
        public Tournament Get(int id)
        {
            return this.tournamentService.GetDetails(id);
        }

        [HttpGet]
        public IEnumerable<Tournament> Get()
        {
            return this.tournamentService.GetTournaments();
        }

        [HttpPost]
        public Tournament Post([FromBody]string name)
        {
            try
            {
                return this.tournamentService.Create(name);
            }
            catch (CSTournamentDomainException)
            {
                return null;
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                this.tournamentService.Delete(id);
                return this.Ok();
            }
            catch (CSTournamentDomainException ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [Route("{tournamentId}/players/{playerId}")]
        [HttpPatch]
        public IHttpActionResult AssignPlayerToTournament([FromUri] int tournamentId, [FromUri] int playerId)
        {
            try
            {
                this.tournamentService.AssignPlayerToTournament(tournamentId, playerId);
                return this.Ok();
            }
            catch (CSTournamentDomainException ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}