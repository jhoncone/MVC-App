using MiBotica.SolPedido.Entidades.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiBotica.SolPedido.AccesoDatos.Core
{
    public class UsuarioDA:List<Usuario>
    {

        public List<Usuario> ListaUsuarios()
        {
            List<Usuario> listaEntidad = new List<Usuario>();
            Usuario entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paUsuarioLista", conexion))

                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);


                        listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return listaEntidad;
        }

        public Usuario DetalleUsuario(int id)
        {
            
            //List<Usuario> listaEntidad = new List<Usuario>();
            Usuario entidad = null;
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                string sqlQuery = "SELECT * FROM Usuario WHERE IdUsuario= " + id;
                //using (SqlCommand comando = new SqlCommand("paUsuarioDetalle", conexion))
                using (SqlCommand comando = new SqlCommand(sqlQuery, conexion))

                {
                    // comando.CommandType = System.Data.CommandType.StoredProcedure;
                
                   // SqlCommand cmd = new SqlCommand(sqlQuery, conexion);
                    conexion.Open();
                     //comando.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        entidad = LlenarEntidad(reader);


                        //listaEntidad.Add(entidad);
                    }
                }
                conexion.Close();
            }
            return entidad;
        }

        public Usuario LlenarEntidad(IDataReader reader)
        {
            Usuario usuario = new Usuario(); reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='IdUsuario'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["IdUsuario"]))
                    usuario.IdUsuario = Convert.ToInt32(reader["IdUsuario"]);
            }
            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Clave'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Clave"])) ;
                   // usuario.Clave  = reader["Clave"];
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='CodUsuario'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["CodUsuario"]))
                    usuario.CodUsuario = Convert.ToString(reader["CodUsuario"]);
            }

            reader.GetSchemaTable().DefaultView.RowFilter = "ColumnName='Nombres'";
            if (reader.GetSchemaTable().DefaultView.Count.Equals(1))
            {
                if (!Convert.IsDBNull(reader["Nombres"]))
                    usuario.Nombres = Convert.ToString(reader["Nombres"]);
            }

            return usuario;

        }

        public void InsertarUsuario(Usuario usuario)
        {
            //usuario = new Usuario();
            //usuario.get
            //throw new NotImplementedException();
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paUsuario_insertar", conexion))

                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    //SqlDataReader reader = comando.ExecuteReader();


                    // String str = "PANKAJ";
                    //byte[] byteArr = { 0, 16, 104, 213 };
                    //  String cod = IdUsuario;
                    //usuario.CodUsuario = Convert.ToString("CodUsuario");
                    // usuario.CodUsuario = "jchavez";
                    //usuario.Clave = byteArr;
                    //usuario.Nombres = Convert.ToString("Nombres");
                     //usuario.Nombres = "Chavez saume Julios";
                    comando.Parameters.AddWithValue("@CodUsuario", usuario.CodUsuario);
                    comando.Parameters.AddWithValue("@Clave", usuario.Clave);
                    comando.Parameters.AddWithValue("@Nombres", usuario.Nombres);
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();

                    // while (reader.Read())
                    //{
                    //  entidad = LlenarEntidad(reader);


                    //listaEntidad.Add(entidad);
                    // }
                }
                conexion.Close();
            }
        }


        public void EditarUsuario(int id, Usuario usuario)
        {
            //throw new NotImplementedException();
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
                using (SqlCommand comando = new SqlCommand("paModificarUsuario", conexion))

                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    conexion.Open();
                    comando.Parameters.AddWithValue("@IdUsuario", id);
                    comando.Parameters.AddWithValue("@CodUsuario", usuario.CodUsuario);
                    comando.Parameters.AddWithValue("@Clave", usuario.Clave);
                    comando.Parameters.AddWithValue("@Nombres", usuario.Nombres);
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();


                }
                conexion.Close();
            }

        }

        public void DeleteUsuario(int id, Usuario usuario)
        {
            using (SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["cnnSql"]].ConnectionString))
            {
    
                 using (SqlCommand comando = new SqlCommand("spDeleteUsuario", conexion))
                {
                    

                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@IdUsuario", id);
                    conexion.Open();
                    
                    //comando.Parameters.AddWithValue("@CodUsuario", null);
                    //comando.Parameters.AddWithValue("@Clave", usuario.Clave);
                   //comando.Parameters.AddWithValue("@Nombres", null);
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();


                }
                conexion.Close();
            }
        }

        //  public class ListaUsuarios : List<Usuario>
        //{
        // }
    }
}
