using System;
using System.Data;
using System.Data.SqlClient;

namespace BookAPP.Models
{
    public class libroDal
    {
        static string conectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BookAPPCS"].ConnectionString;

        SqlConnection con = new SqlConnection(conectionString);

        public string AgregarLibro(libroModel libroObj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("libroinsertupdatedelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", libroObj.codigo);
                cmd.Parameters.AddWithValue("@nombre", libroObj.nombre);
                cmd.Parameters.AddWithValue("@empresa", libroObj.empresa);
                cmd.Parameters.AddWithValue("@precio", libroObj.precio);
                cmd.Parameters.AddWithValue("@stock", 0);
                cmd.Parameters.AddWithValue("@accion", "Insert");
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Libro agregado satisfactoriamente");
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

        public string ActualizarLibro(libroModel libroObj)
        {
            SqlCommand cmd = new SqlCommand("libroinsertupdatedelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", libroObj.codigo);
            cmd.Parameters.AddWithValue("@nombre", libroObj.nombre);
            cmd.Parameters.AddWithValue("@empresa", libroObj.empresa);
            cmd.Parameters.AddWithValue("@precio", libroObj.precio);
            cmd.Parameters.AddWithValue("@stock", (libroObj.stock + libroObj.recarga));
            cmd.Parameters.AddWithValue("@accion", "Update");
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return ("Libro agregado satisfactoriamente");
        }
    }
}