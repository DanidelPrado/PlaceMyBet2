using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("api/Evento/{action}")]
    public class EventoController : ApiController
    {
        // GET: api/Evento
        [HttpGet]
        [ActionName("Get")]
        public IEnumerable<Evento> Get()
        {
            EventoRepository repository = new EventoRepository();
            List<Evento> eventos = repository.retrieve();
            return eventos;
        }
        [HttpGet]
        [ActionName("GetDTO")]
        public IEnumerable<EventoDTO> GetDTO()
        {
            var repository = new EventoRepository();
            List<EventoDTO> eventos = repository.retrieveDTO();
            return eventos;
        }

        // POST: api/Evento
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Evento/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Evento/5
        public void Delete(int id)
        {
        }
    }
}