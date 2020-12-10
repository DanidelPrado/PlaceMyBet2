using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPI.Models;

namespace webAPI.Controllers
{
    public class EventoController : ApiController
    {
        // GET: api/Evento
        public IEnumerable<Evento> Get()
        {
            EventoRepository repository = new EventoRepository();
            List<Evento> eventos = repository.retrieve();
            return eventos;
        }

        // POST: api/Evento
        public void Post([FromBody] Evento ev)
        {
            EventoRepository repository = new EventoRepository();
            repository.Save(ev);
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