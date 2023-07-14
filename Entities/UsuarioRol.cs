namespace newcontableapi.Entities
{
    public class UsuarioRol
    {
        public int IdUsuarioRol { get; set; }
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public byte Activo { get; set; }
    }
}