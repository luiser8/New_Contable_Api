namespace newcontableapi.Entities
{
    public class Roles
    {
        public int IdRol { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaSistema { get; set; }
        public byte Activo { get; set; }
    }
}