﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPI.Models;

namespace webAPI.Controllers
{
    public class ApuestaController : ApiController
    {
        // GET: api/Apuesta
        public IEnumerable<Apuesta> Get()
        {
            var repository = new ApuestaRepository();
            List<Apuesta> apuestas = repository.retrieve();
            return apuestas;
        }

        // POST: api/Apuesta
        public void Post([FromBody] Apuesta apuesta)
        {
            var repo = new ApuestaRepository();
            repo.Save(apuesta);
        }

        // PUT: api/Apuesta/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Apuesta/5
        public void Delete(int id)
        {
        }
    }
}
