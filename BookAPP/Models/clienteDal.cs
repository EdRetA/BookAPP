using System;
using System.Collections.Generic;
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


        public List<clienteModel> CargarClientes()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select * from listaClientes", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                List<clienteModel> Lista = new List<clienteModel>();
                foreach (DataRow row in dt.Rows)
                {
                    Lista.Add(new clienteModel() { codigo = (int)row["Codigo"], nombre = row["Nombre"].ToString(), id = row["Cedula"].ToString(), correo = row["Email"].ToString() });
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
                List<clienteModel> Lista = new List<clienteModel>();
                return Lista;

            }
        }
    }
}