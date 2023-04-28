using System;
using System.Collections.Generic;
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
            if (libroObj.reservas==0)
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
                return ("Libro actualizado satisfactoriamente");
            }
            else
            {
                if (libroObj.reservas>libroObj.recarga)
                {
                    SqlCommand cmd = new SqlCommand("asignarLibro", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo", libroObj.codigo);
                    cmd.Parameters.AddWithValue("@cantidad", libroObj.recarga);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    return ("Apartados actualizados satisfactoriamente");
                }
                else { 
                SqlCommand cmd = new SqlCommand("asignarLibro", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", libroObj.codigo);
                cmd.Parameters.AddWithValue("@cantidad", libroObj.reservas);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    SqlCommand cmd2 = new SqlCommand("libroinsertupdatedelete", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@codigo", libroObj.codigo);
                    cmd2.Parameters.AddWithValue("@nombre", libroObj.nombre);
                    cmd2.Parameters.AddWithValue("@empresa", libroObj.empresa);
                    cmd2.Parameters.AddWithValue("@precio", libroObj.precio);
                    cmd2.Parameters.AddWithValue("@stock", (libroObj.stock + (libroObj.recarga-libroObj.reservas)));
                    cmd2.Parameters.AddWithValue("@accion", "Update");
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    
                    return ("Apartados actualizados satisfactoriamente");
                }
            }
            
        }

        public List<string> ConsultarApartados(libroModel libroD)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select nomCliente from vapartados Where CodLibro=@CodLibro and asignado=0", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@CodLibro", libroD.codigo);
                con.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                List<string> Listaclientes = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    Listaclientes.Add(row["nomCliente"].ToString());
                }
                return Listaclientes;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                List<string> ListaEntradas = new List<string>();
                return ListaEntradas;
            }
        }

        
    }
}