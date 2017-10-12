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

        [HttpGet]
        public IEnumerable<Game> Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Game Post([FromBody]GameClientData gameClientData)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

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