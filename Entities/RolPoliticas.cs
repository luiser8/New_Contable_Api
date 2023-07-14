namespace newcontableapi.Entities
{
    public class RolPoliticas
    {
        public int IdRolPolitica { get; set; }
        public int IdRol { get; set; }
        public int IdPolitica { get; set; }
        public byte Activo { get; set; }
    }
}