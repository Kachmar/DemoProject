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
        [HttpGet]
        public IEnumerable<Player> Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public Game Post([FromBody] PlayerClientData player)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}