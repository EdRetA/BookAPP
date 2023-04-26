using System;
using System.Data;
using System.Data.SqlClient;

namespace BookAPP.Models
{
    public class clienteDal
    {
        static string conectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BookAPPCS"].ConnectionString;

        SqlConnection con = new SqlConnection(conectionString);

        public string AgregarCliente(clienteModel clienteObj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("clienteinsertupdatedelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", clienteObj.codigo);
                cmd.Parameters.AddWithValue("@nombre", clienteObj.nombre);
                cmd.Parameters.AddWithValue("@id", clienteObj.id);
                cmd.Parameters.AddWithValue("@fnacimiento", clienteObj.fnacimiento);
                cmd.Parameters.AddWithValue("@correo", clienteObj.correo);
                cmd.Parameters.AddWithValue("@accion", "Insert");             
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Cliente agregado satisfactoriamente");
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return (ex.Message.ToString());
            }
        }
    }
}