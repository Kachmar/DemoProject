using System;
using System.Collections.Generic;
using System.Web.Http;
using CSTournaments.Extensibility.Entities;
using CSTournaments.Extensibility.Exceptions;
using CSTournaments.Extensibility.Service;
using CSTournaments.WebApi.Dtos;

namespace CSTournaments.WebApi.Controllers
{
    [RoutePrefix("games")]
    public class GamesController : ApiController
    {
        private readonly IGameService gameService;

        public GamesController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        /// <summary>
        /// Gets all games.
        /// </summary>
        /// <returns>Returns collection of games..</returns>
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates new game with given name in specified id of the parent tournament
        /// </summary>
        /// <param name="gameClientData">The game data.</param>
        /// <returns>Instance of newly created game.</returns>
        [HttpPost]
        public Game Post([FromBody]GameClientData gameClientData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes game with given id.
        /// </summary>
        /// <param name="id">Game identifier.</param>
        /// <response code="200">Game is deleted.</response>
        /// <response code="400">Bad request.</response>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Assigns the player to the game.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <param name="playerId">The player identifier.</param>
        /// <response code="200">Player is assigned the Game.</response>
        /// <response code="400">Bad request.</response>
        [Route("{gameId}/players/{playerId}")]
        [HttpPatch]
        public IHttpActionResult AssignPlayerToGame([FromUri] int gameId, [FromUri] int playerId)
        {
            try
            {
                this.gameService.AssignPlayerToGame(gameId, playerId);
                return this.Ok();
            }
            catch (CSTournamentDomainException ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}