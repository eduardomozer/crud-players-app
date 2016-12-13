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
        private PlayerRepository _PlayerRepository;
        private PlayerRepository PlayerRepository
        {
            get { return _PlayerRepository ?? (_PlayerRepository = new PlayerRepository()); }
            set { _PlayerRepository = value; }
        }

        // GET api/player
        public HttpResponseMessage Get()
        {
            var players = PlayerRepository.GetAll();

            if (players == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Request.CreateResponse<IEnumerable<Player>>(HttpStatusCode.OK, players);
        }

        // GET api/player/:id
        public HttpResponseMessage Get(int id)
        {
            var player = PlayerRepository.GetById(id);

            if (player == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Request.CreateResponse(HttpStatusCode.OK, player);
        }

        // POST api/player
        public HttpResponseMessage Post([FromBody]Player player)
        {
            try
            {
                PlayerRepository.Create(player);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

        // PUT api/player
        public HttpResponseMessage Put([FromBody]Player player)
        {
            try
            {
                PlayerRepository.Update(player);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // DELETE api/player/:id
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                PlayerRepository.Delete(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}