namespace UsuariosCRUDBackEnd.Models
{
    public class Login
    {
        //Modelo para realizar un login como administrador
        public string Usuario { get; set; }

        public string Contrasena { get; set; }

        public Login(string usuario, string contrasena)
        {
            Usuario = usuario;
            Contrasena = contrasena;    
        }

        public Login()
        {

        }
    }
}
