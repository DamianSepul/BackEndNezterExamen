using System.Data;
using System.Data.SqlClient;
using UsuariosCRUDBackEnd;
namespace UsuariosCRUDBackEnd.Models
{
    public class GestorUsuarios
    {
        //Modelo donde se gestionan los usuarios y se conectan con la base de datos

        string con = "Data Source=RegistroUsuarios.mssql.somee.com;Initial Catalog=RegistroUsuarios;user id=userExamen_SQLLogin_1;pwd=ye5qjmym2z;";

        //Funcion que se utiliza para realizar el login como administrador
        public bool LoginUsuario(Login login)
        {
            bool res = false;
           
            
            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Usuarios_Login";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string usuario = dr.GetString(0).Trim();
                    string contrasena = dr.GetString(1).Trim();

                    if (login.Usuario == usuario && login.Contrasena == contrasena)
                    {
                        res= true;
                    }
                }

                dr.Close();
                conn.Close();
            }

            return res;


        }

        //Funcion para obtener todos los usuarios excluyendo al administrador
        public List<Usuario> ObtenerUsuario()
        {
            List<Usuario> lista = new List<Usuario>();
       

            using (SqlConnection conn = new SqlConnection(con))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Usuarios_Obtener";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    
                    string nombre = dr.GetString(0).Trim();
                    string direccion = dr.GetString(1).Trim();
                    string telefono = dr.GetString(2).Trim();
                    string codigopostal = dr.GetString(3).Trim();
                    string estado = dr.GetString(4).Trim();
                    string ciudad = dr.GetString(5).Trim();
                    int id = dr.GetInt32(6);
                    Usuario usuario = new Usuario(id,nombre,direccion,telefono,codigopostal,estado, ciudad);

                    lista.Add(usuario);
                }
                dr.Close();
                conn.Close();
            }
            return lista;
        }

        //Funcion para añadir un usuario con sus respectivos datos
        public bool AñadirUsuario(Usuario usuario)
        {
            bool res = false;

         

            using (SqlConnection conn = new SqlConnection(con))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Usuarios_Agregar";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@CodigoPostal", usuario.CodigoPostal);
                cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
                cmd.Parameters.AddWithValue("@Ciudad", usuario.Ciudad);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }

                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }
                return res;
            }
        }

        //Funcion que toma el id para poder actualizar un usuario
        public bool ActualizarUsuario(int id, Usuario usuario)
        {
            bool res = false;

        

            using (SqlConnection conn = new SqlConnection(con))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Usuarios_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                cmd.Parameters.AddWithValue("@CodigoPostal", usuario.CodigoPostal);
                cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
                cmd.Parameters.AddWithValue("@Ciudad", usuario.Ciudad);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }

                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }


            }
            return res;
        }


        //Funcion que toma el id para eliminar un usuario
        public bool EliminarUsuario(int id)
        {
            bool res = false;

     

            using (SqlConnection conn = new SqlConnection(con))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Usuarios_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
             

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }

                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }


            }
            return res;
        }
    }


    

    
}
