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
        //Ejercicio 1
        public IEnumerable<EventoDTO2> Get(string val)
        {
            EventoRepository repository = new EventoRepository();
            List<EventoDTO2> eventos = repository.retrievebyRival(val);
            return eventos;
        }


        // POST: api/EventosExamen
        //Ejercicio 2
        public void Post([FromBody] Evento evento, [FromBody] Mercado mercado)
        {
            EventoRepository repository = new EventoRepository();
            repository.Save(evento,mercado);
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
