using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace BookAPP.Models
{
    public class vlibrousuarioDal
    {
        static string conectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BookAPPCS"].ConnectionString;

        SqlConnection con = new SqlConnection(conectionString);

        public List<vlibrousuarioModel> BuscarEntrada(vlibrousuarioModel reservaD)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("Select idapartado,CodLibro,titulo,precio from vlibrousuario Where codigo=@codigo and asignado=1", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@codigo", reservaD.codigo);                
                con.Open();
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
                List<vlibrousuarioModel> reserva = new List<vlibrousuarioModel>();
                foreach (DataRow row in dt.Rows)
                {
                    reserva.Add(new vlibrousuarioModel() { idapartado = (int)row["idapartado"], CodLibro = (int)row["CodLibro"], titulo = row["titulo"].ToString(), precio = (int)row["precio"], codigo= reservaD.codigo });
                }
                return reserva;
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                List<vlibrousuarioModel> reserva = new List<vlibrousuarioModel>();
                return reserva;
            }
        }


    }
}