using CrudPlayersModel;
using CrudPlayersModel.Repositories;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudPlayers.Controllers
{
    public class PlayerController : ApiController
    {
        private IPlayerRepository PlayerRepository;

        public PlayerController()
        {
            PlayerRepository = new PlayerRepository();
        }

        // GET api/player
        public HttpResponseMessage Get()
        {
            var players = PlayerRepository.GetPlayers();

            if (players == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Request.CreateResponse<IEnumerable<Player>>(HttpStatusCode.OK, players);
        }

        // GET api/player/5
        public HttpResponseMessage Get(int id)
        {
            var player = PlayerRepository.GetPlayerById(id);

            if (player == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, player);
        }

        // POST api/player
        public HttpResponseMessage Post([FromBody]Player player)
        {
            try
            {
                PlayerRepository.CreatePlayer(player);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

        // PUT api/player/5
        public HttpResponseMessage Put([FromBody]Player player)
        {
            try
            {
                PlayerRepository.UpdatePlayer(player);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // DELETE api/player/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                PlayerRepository.DeletePlayer(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}