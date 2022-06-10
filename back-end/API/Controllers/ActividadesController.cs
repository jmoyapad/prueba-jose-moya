using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BL;
using BL.Usuarios;
using Models.Model;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ActividadesController : ApiController
    {

        // GET: api/Actividades
        private ActividadBL _actividadBL = new ActividadBL();

        // GET api/<controller>
        [HttpGet]
        public Message Get()
        {
            int obtenerTodos = 0;
            return _actividadBL.Get(obtenerTodos);
        }

        [HttpGet]
        // GET api/<controller>/5
        public Message Get(int id)
        {
            return _actividadBL.Get(id);
        }

        // POST: api/Actividades
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Actividades/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Actividades/5
        public void Delete(int id)
        {
        }
    }
}
