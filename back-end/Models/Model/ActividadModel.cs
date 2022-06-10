using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class ActividadModel
    {
        public int IdActividad { get; set; }
        public DateTime CreateDate { get; set; }
        public string Nombre { get; set; }
        public string Actividad { get; set; }
    }
}
