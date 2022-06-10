using BL.Usuarios;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuariosController : ApiController
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
        [HttpDelete]
        public Message Delete( int id)
        {
            return usuarioBL.Eliminar(id);
        }
    }
}
