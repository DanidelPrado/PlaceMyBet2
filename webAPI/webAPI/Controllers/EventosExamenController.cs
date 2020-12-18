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


        // POST: api/EventosExamen
        public void Post([FromBody] Evento evento, [FromBody] Mercado mercado)
        {
            EventoRepository repository2 = new EventoRepository();
            repository2.Save(evento);
            MercadoRepository repository = new MercadoRepository();
            repository.Save(mercado);
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
