using System;
using System.Collections.Generic;
using System.Web.Http;
using CSTournament.Extensibility;
using CSTournament.Extensibility.Entities;
using CSTournament.Extensibility.Exceptions;
using CSTournament.Extensibility.Service;

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

        [Route("{tournament_id}")]
        [HttpGet]
        public Tournament Get(Guid id)
        {
            return tournamentService.GetDetails(id);
        }

        [HttpGet]
        public IEnumerable<Tournament> Get()
        {
            return tournamentService.GetTournaments();
        }

        [HttpPost]
        public Tournament Post([FromBody]string name)
        {
            try
            {
                return tournamentService.Create(name);
            }
            catch (CSTournamentDomainException)
            {
                return null;
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                tournamentService.Delete(id);
                return Ok();
            }
            catch (CSTournamentDomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{tournament_id}/players/{player_id}")]
        [HttpPatch]
        public IHttpActionResult AssignPlayerToTournament([FromUri] Guid tournamentId, [FromUri] Guid playerId)
        {
            try
            {
                tournamentService.AssignPlayerToTournament(tournamentId, playerId);
                return Ok();
            }
            catch (CSTournamentDomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{game_id}/players/{player_id}")]
        [HttpPatch]
        public IHttpActionResult AssignPlayerToGame([FromUri] Guid gameId, [FromUri] Guid playerId)
        {
            try
            {
                tournamentService.AssignPlayerToGame(gameId, playerId);
                return Ok();
            }
            catch (CSTournamentDomainException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}