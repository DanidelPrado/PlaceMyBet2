using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPI.Models;

namespace webAPI.Controllers
{
    public class EventosExamenController : ApiController
    {
        // GET: api/EventosExamen
        public IEnumerable<EventoDTO2> Get(string val)
        {
            EventoRepository repository = new EventoRepository();
            List<EventoDTO2> eventos = repository.retrievebyLocal(val);
            return eventos;
        }

        // GET: api/EventosExamen/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/EventosExamen
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/EventosExamen/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EventosExamen/5
        public void Delete(int id)
        {
        }
    }
}
