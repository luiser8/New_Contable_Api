namespace newcontableapi.Entities
{
    public class Auditoria
    {
        public int IdAuditoria { get; set; }
        public int IdUsuario { get; set; }
        public string? Accion { get; set; }
        public string? Tabla { get; set; }
        public byte Activo { get; set; }
        public DateTime FechaSistema { get; set; }
    }
}
