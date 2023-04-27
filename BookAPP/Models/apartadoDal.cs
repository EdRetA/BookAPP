using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BookAPP.Models
{
    public class apartadoDal
    {
        static string conectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BookAPPCS"].ConnectionString;

        SqlConnection con = new SqlConnection(conectionString);

        public string AgregarApartado(apartadoModel apartadoObj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_insApartado", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fklibro", apartadoObj.fklibro);
                cmd.Parameters.AddWithValue("@nombre", apartadoObj.nombre);                
                
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ("Libro apartado satisfactoriamente");
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

        public List<string> BuscarClientes()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select nombre from vClientes", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                List<string> Lista = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    Lista.Add(row["nombre"].ToString());
                }
                return Lista;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                return new List<string>(new string[] { "Error" });
            }
        }
    }
}