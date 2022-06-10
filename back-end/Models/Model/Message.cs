using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Message
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public object Result { get; set; }
        public bool HasError { get; set; }
        public Message()
        {
            this.Code = 0;
            this.Msg = string.Empty;
            this.Result = null;
            this.HasError = false;
        }
        public Message(Exception e)
        {
            this.Code = 2000;
            this.Msg = "Ha ocurrido un error de aplicación, por favor comunicarse con el administrador del sistema";
            this.Result = null;
            this.HasError = true;
        }
    }
}
