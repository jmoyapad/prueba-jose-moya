using DAO.Clases;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Usuarios
{
    public class ActividadBL
    {
        private ActividadesDAO _actRepository;


        public ActividadBL()
        {
            _actRepository = new ActividadesDAO();
        }

        public Message Get(int id)
        {

            return _actRepository.Select(id);
        }
    }
}
