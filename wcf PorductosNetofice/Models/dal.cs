using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace wcf_PorductosNetofice.Models
{
    public class dal
    {
        public void insertar(int accion, ObjProducto producto)
        {
            string Obser = System.DateTime.Now.ToString();
            SqlConnection con = new SqlConnection();//("Password=administracion;User ID=mod_administracion;Data Source=everest");
            con.ConnectionString = ConfigurationManager.ConnectionStrings["InterfazEAI"].ConnectionString;
            SqlCommand cmd = new SqlCommand("CrudProductoNetofice", con);

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ejecutar", SqlDbType.Int)).Value = accion;
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = producto.Id;
                cmd.Parameters.Add(new SqlParameter("@Codigo", SqlDbType.VarChar)).Value = producto.Codigo;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar)).Value = producto.Descripcion;
                cmd.Parameters.Add(new SqlParameter("@Cantidad", SqlDbType.Int)).Value = producto.Cantidad;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.Bit)).Value = producto.Estado;
                cmd.Parameters.Add(new SqlParameter("@Fecha_Creacion", SqlDbType.DateTime)).Value = producto.Fecha_Creacion;
                cmd.Parameters.Add(new SqlParameter("@Usuario", SqlDbType.VarChar)).Value = producto.Usuario;
                cmd.Parameters.Add(new SqlParameter("@TransactionId", SqlDbType.VarChar)).Value = producto.TransactionId;


                int i = cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw new Exception("Insert: " + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }


        public ObjProducto editarListar(int accion, int Id)
        {
            string Obser = System.DateTime.Now.ToString();
            SqlConnection con = new SqlConnection();//("Password=administracion;User ID=mod_administracion;Data Source=everest");
            con.ConnectionString = ConfigurationManager.ConnectionStrings["InterfazEAI"].ConnectionString;
            SqlCommand cmd = new SqlCommand("CrudProductoNetofice", con);

            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@ejecutar", SqlDbType.Int)).Value = accion;
                cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = Id;

                dtAdapter.SelectCommand = cmd;
                dtAdapter.Fill(dt);

                ObjProducto objp = new ObjProducto();
                foreach (DataRow item in dt.Rows)
                {


                    objp.Id = Convert.ToInt32(item["Id"]);
                    objp.Codigo = Convert.ToString(item["Codigo"]);
                    objp.Descripcion = Convert.ToString(item["Descripcion"]);
                    objp.Cantidad = Convert.ToInt32(item["Cantidad"]);
                    objp.Estado = Convert.ToBoolean(item["Estado"]);
                    objp.Fecha_Creacion = Convert.ToDateTime(item["Fecha_Creacion"]);
                    objp.Usuario = Convert.ToString(item["Usuario"]);
                    objp.TransactionId = Convert.ToString(item["TransactionId"]);
                }

                return objp;
            }
            catch (SqlException ex)
            {
                throw new Exception("Insert: " + ex.Message.ToString());
            }
            finally
            {
                con.Close();
            }
        }
    }
}