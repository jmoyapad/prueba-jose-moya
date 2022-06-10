using Dapper;
using DAO.Interfaces;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAO.Clases
{
    public class ActividadesDAO : ISelect
    {
        public Message Select(int id)
        {
            Message rs = new Message();

            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionStrings.ConnectionString))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@id_usuario", id);

                    var reader = connection.QueryMultiple("SP_OBTENER_ACTIVIDADES", param: parameters, commandType: CommandType.StoredProcedure);


                    rs = new Message()
                    {
                        Code = 1000,
                        HasError = false,
                        Msg = string.Empty,
                        Result = reader.Read<ActividadModel>().ToList()
                    };

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                rs = new Message(ex);
            }

            return rs;
        }
    }
}
