using System;
using System.Collections.Generic;
using System.Web.Http;
using CSTournaments.Extensibility.Entities;
using CSTournaments.WebApi.Dtos;

namespace CSTournaments.WebApi.Controllers
{
    [RoutePrefix("players")]
    public class PlayersController : ApiController
    {
        /// <summary>
        /// Gets all players.
        /// </summary>
        /// <returns>Returns collection of players.</returns>
        [HttpGet]
        public IEnumerable<Player> Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates new player with given name and age
        /// </summary>
        /// <param name="player">The player data.</param>
        /// <returns>Instance of newly created player.</returns>
        [HttpPost]
        public Player Post([FromBody] PlayerClientData player)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes player with given id.
        /// </summary>
        /// <param name="id">Player identifier.</param>
        /// <response code="200">Player is deleted.</response>
        /// <response code="400">Bad request.</response>
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}