using System.Collections.Generic;
using System.Web.Http;
using CSTournaments.Extensibility.Entities;
using CSTournaments.Extensibility.Exceptions;
using CSTournaments.Extensibility.Service;

namespace CSTournaments.WebApi.Controllers
{
    /// <summary>
    /// Api for managing CS tournaments
    /// </summary>
    [RoutePrefix("tournaments")]
    public class TournamentsController : ApiController
    {
        private readonly ITournamentService tournamentService;

        public TournamentsController(ITournamentService tournamentService)
        {
            this.tournamentService = tournamentService;
        }

        /// <summary>
        /// Gets the tournament details by specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Tournament full details.</returns>
        [HttpGet]
        public TournamentInfo Get(int id)
        {
            return this.tournamentService.GetDetails(id);
        }

        /// <summary>
        /// Gets all tournaments.
        /// </summary>
        /// <returns>Returns collection of tournaments</returns>
        [HttpGet]
        public IEnumerable<Tournament> Get()
        {
            return this.tournamentService.GetTournaments();
        }

        /// <summary>
        /// Creates new tournament with given name
        /// </summary>
        /// <param name="name">The name of tournament.</param>
        /// <returns>Instance of newly created tournament.</returns>
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

        /// <summary>
        /// Deletes the tournament with given identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <response code="200">Tournament deleted.</response>
        /// <response code="400">Bad request.</response>
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

        /// <summary>
        /// Assigns the player to tournament.
        /// </summary>
        /// <param name="tournamentId">The tournament identifier.</param>
        /// <param name="playerId">The player identifier.</param>
        /// <response code="200">Player is assigned Tournament.</response>
        /// <response code="400">Bad request.</response>
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