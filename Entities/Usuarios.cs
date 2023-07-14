namespace newcontableapi.Entities
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Correo { get; set; }
        public string? CuentaLocal { get; set; }
        public string? Contrasena { get; set; }
        public string? TokenAcceso { get; set; }
        public string? TokenRefresco { get; set; }
        public DateTime TokenCreado { get; set; }
        public DateTime TokenExpiracion { get; set; }
        public DateTime FechaSistema { get; set; }
        public byte Activo { get; set; }
    }

    public class UsuariosDto
    {
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Correo { get; set; }
        public string? CuentaLocal { get; set; }
        public string? Contrasena { get; set; }
        public string? TokenAcceso { get; set; }
        public string? TokenRefresco { get; set; }
        public DateTime TokenCreado { get; set; }
        public DateTime TokenExpiracion { get; set; }
        public int IdRol { get; set; }
    }

    public class LoginUsuarios
    {
        public string? CuentaLocal { get; set; }
        public string? Contrasena { get; set; }
    }

    public class UsuariosAcceso
    {
        public int IdUsuario { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Correo { get; set; }
        public string? CuentaLocal { get; set; }
        public string? TokenAcceso { get; set; }
        public string? TokenRefresco { get; set; }
        public DateTime TokenCreado { get; set; }
        public DateTime TokenExpiracion { get; set; }
        public byte Activo { get; set; }
        public RolUsuario? RolUsuario { get; set; }
        public List<PoliticasUsuario>? PoliticasUsuarios { get; set; }
    }

    public class UsuariosRolPoliticas
    {
        public int IdUsuario { get; set; }
        public RolUsuario? RolUsuario { get; set; }
        public List<PoliticasUsuario>? PoliticasUsuarios { get; set; }
    }

    public class RolUsuario
    {
        public int IdRol { get; set; }
        public string? CodRol { get; set; }
        public string? DesRol { get; set; }
        public byte ActRol { get; set; }
    }

    public class PoliticasUsuario
    {
        public int IdPolitica { get; set; }
        public string? CodPolitica { get; set; }
        public string? DesPolitica { get; set; }
        public string? RutaPolitica { get; set; }
        public byte ActPolitica { get; set; }
    }
}