using Microsoft.AspNetCore.Mvc;
using UsuariosCRUDBackEnd.Models;

//Controlador donde se encuentran las apis, que utilizan el protocolo HTTP para comunicarse con el modelo de Gestor de usuarios

namespace UsuariosCRUDBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        //API que se utiliza obtener los usuarios de la base de datos y retorna una lista

        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            GestorUsuarios gUsuario = new GestorUsuarios();
            return gUsuario.ObtenerUsuario();
        }

  
        //API que se utiliza para añadir un usuario a la base de datos. Retorna un boolean para saber si se inserto o no

        // POST api/<UsuariosController>
        [HttpPost]
        public bool Post([FromBody] Usuario usuario)
        {
            GestorUsuarios gUsuario = new GestorUsuarios();
            bool res = gUsuario.AñadirUsuario(usuario);

            try
            {
                return res;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //API que se utiliza para actualizar los datos de un usuario

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Usuario usuario)
        {
            GestorUsuarios gUsuario = new GestorUsuarios();
            bool res = gUsuario.ActualizarUsuario(id,usuario);

            try
            {
                return res;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }

        }

        //API que se utiliza para borrar a un usuario mediante su ID

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            GestorUsuarios gUsuario = new GestorUsuarios();
            bool res = gUsuario.EliminarUsuario(id);

            try
            {
                return res;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //API que se utiliza para poder realizar el login
        [HttpPost("LoginUsuario")]
        public bool Login ([FromBody] Login login)
        {
            GestorUsuarios gUsuario = new GestorUsuarios();
            bool res = gUsuario.LoginUsuario(login);

            try
            {
                return res;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
