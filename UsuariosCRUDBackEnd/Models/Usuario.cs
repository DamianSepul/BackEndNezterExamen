namespace UsuariosCRUDBackEnd.Models
{
    public class Usuario
    {
        // Modelo para la creación de un usuario
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string CodigoPostal { get; set; }
        public string Estado  { get; set; }
        public string Ciudad { get; set; }
        
        public Usuario()
        {
                
        }
        public Usuario(string nombre,string direccion ,string telefono, string codigopostal, 
            string estado, string ciudad)
        {
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            CodigoPostal = codigopostal;
            Estado = estado;
            Ciudad = ciudad;

        }

        public Usuario(int id, string nombre, string direccion, string telefono, string codigopostal , 
            string estado, string ciudad
            )
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            CodigoPostal = codigopostal;
            Estado = estado;
            Ciudad = ciudad;
        }
    }
}
