using System;
using System.Data.SqlClient;

namespace BookAPP.Models
{
    public class apartadoDal
    {
        static string conectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BookAPPCS"].ConnectionString;

        SqlConnection con = new SqlConnection(conectionString);

        //public string AgregarApartado(apartadoModel apartadoObj)
        //{
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_insEntrada", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@producto", entrada.productoN);
        //        cmd.Parameters.AddWithValue("@lote", entrada.lote);
        //        cmd.Parameters.AddWithValue("@ffabricacion", entrada.ffabricacion);
        //        cmd.Parameters.AddWithValue("@fvencimiento", entrada.fvencimiento);
        //        cmd.Parameters.AddWithValue("@fingreso", entrada.fingreso);
        //        cmd.Parameters.AddWithValue("@cantidad", entrada.cantidad);
        //        cmd.Parameters.AddWithValue("@proveedor", entrada.proveedor);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();
        //        return ("Entrada de producto agregada satisfactoriamente");
        //    }
        //    catch (Exception ex)
        //    {
        //        if (con.State == ConnectionState.Open)
        //        {
        //            con.Close();
        //        }
        //        return (ex.Message.ToString());
        //    }
        //}
    }
}