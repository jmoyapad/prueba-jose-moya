using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Models.Model
{
    public class UsuariosModel
    {
        public int IdUsuario { get; set; }
        [DisplayName("Nombre")]
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        [DisplayName("E-mail")]
        public string CorreoElectronico { get; set; }
        [DisplayName("Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [DisplayName("Teléfono")]
        public string Telefono { get; set; }
        [DisplayName("País")]
        public string IdPais { get; set; }
        [DisplayName("Recibe Información?")]
        public bool RecibeInformacion { get; set; }
        [DisplayName("Activo")]
        public bool Activo { get; set; }

    }
}
