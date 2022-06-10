using BL.Usuarios;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ValuesController : ApiController
    {
        private UsuariosBL usuarioBL = new UsuariosBL();

        // GET api/<controller>
        [HttpGet]       
        public Message Get()
        {
            int obtenerTodos = 0;
            return usuarioBL.Obtener(obtenerTodos);
        }

        [HttpGet]        
        // GET api/<controller>/5
        public Message Get(int id)
        {
            return usuarioBL.Obtener(id);
        }

        // POST api/<controller>
        public Message Post([FromBody] UsuariosModel model)
        {
            return usuarioBL.Agregar(model);
        }

        // PUT api/<controller>/5
        public Message Put(int id, [FromBody] UsuariosModel model)
        {
            return usuarioBL.Agregar(model);
        }

        // DELETE api/<controller>/5
        public Message Delete(int id)
        {
            return usuarioBL.Eliminar(id);
        }
        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
