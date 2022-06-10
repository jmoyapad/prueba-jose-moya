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
    public class UsuariosDAO : IAdd, IDelete, ISelect, IUpdate
    {
        public Message Add(UsuariosModel usr)
        {
            Message rs = new Message();

            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionStrings.ConnectionString))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@nombre ", usr.Nombre);
                    parameters.Add("@apellidos", usr.Apellidos);
                    parameters.Add("@correo_electronico", usr.CorreoElectronico);
                    parameters.Add("@fecha_nacimiento", usr.FechaNacimiento);
                    parameters.Add("@telefono", usr.Telefono);
                    parameters.Add("@id_pais", usr.IdPais);
                    parameters.Add("@recibe_informacion", usr.RecibeInformacion);
                    var reader = connection.QueryMultiple("SP_AGREGAR_USUARIO", param: parameters, commandType: CommandType.StoredProcedure);

                   
                    rs = reader.Read<Message>().FirstOrDefault();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                rs = new Message(ex);
         
            }

            return rs;
        }

        public Message Delete(int id)
        {
            Message rs = new Message();

            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionStrings.ConnectionString))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@id_usuario", id);
                   
                    var reader = connection.QueryMultiple("SP_ELIMINAR_USUARIO", param: parameters, commandType: CommandType.StoredProcedure);


                    rs = reader.Read<Message>().FirstOrDefault();

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                rs = new Message(ex);
            }

            return rs;
        }

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

                    var reader = connection.QueryMultiple("SP_OBTENER_USUARIO", param: parameters, commandType: CommandType.StoredProcedure);


                    rs = new Message()
                    {
                        Code = 1000,
                        HasError = false,
                        Msg = string.Empty,
                        Result = reader.Read<UsuariosModel>().ToList()
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

        public Message Update(UsuariosModel usr)
        {
            Message rs = new Message();

            try
            {
                using (IDbConnection connection = new SqlConnection(ConnectionStrings.ConnectionString))
                {
                    connection.Open();

                    var parameters = new DynamicParameters();
                    parameters.Add("@id_usuario ", usr.IdUsuario);
                    parameters.Add("@nombre ", usr.Nombre);
                    parameters.Add("@apellidos", usr.Apellidos);
                    parameters.Add("@correo_electronico", usr.CorreoElectronico);
                    parameters.Add("@fecha_nacimiento", usr.FechaNacimiento);
                    parameters.Add("@telefono", usr.Telefono);
                    parameters.Add("@id_pais", usr.IdPais);
                    parameters.Add("@recibe_informacion", usr.RecibeInformacion);
                    var reader = connection.QueryMultiple("SP_MODIFICAR_USUARIO", param: parameters, commandType: CommandType.StoredProcedure);


                    rs = reader.Read<Message>().FirstOrDefault();

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
