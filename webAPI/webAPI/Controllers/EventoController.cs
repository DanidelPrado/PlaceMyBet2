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
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Evento/5
        public void Put(int id, string l, string v)
        {
            EventoRepository repository = new EventoRepository();
            repository.Put(id, l, v);
        }

        // DELETE: api/Evento/5
        public void Delete(int id)
        {
            EventoRepository repository = new EventoRepository();
            repository.Delete(id);
        }
    }
}