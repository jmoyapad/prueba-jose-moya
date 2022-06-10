using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    internal class ConnectionStrings
    {
        public static string ConnectionString => System.Configuration.ConfigurationManager.ConnectionStrings["prueba"].ConnectionString;
    }
}
