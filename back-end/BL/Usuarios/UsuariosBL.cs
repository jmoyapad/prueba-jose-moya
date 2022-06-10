using DAO.Clases;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Usuarios
{
    public class UsuariosBL
    {
        private UsuariosDAO _usrRepository;
        

        public UsuariosBL()
        {
            _usrRepository = new UsuariosDAO();
        }

        public Message Agregar(UsuariosModel usr)
        {

            return _usrRepository.Add(usr);
        }

        public Message Actualizar(UsuariosModel usr)
        {

            return _usrRepository.Update(usr);
        }

        public Message Eliminar(int idUsuario)
        {
            return _usrRepository.Delete(idUsuario);
        }

        public Message Obtener(int idUsuario) {

            return _usrRepository.Select(idUsuario);        
        }
    }
}
