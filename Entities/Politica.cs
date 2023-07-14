namespace newcontableapi.Entities
{
    public class Politica
    {
        public int IdPolitica { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? Ruta { get; set; }
        public DateTime FechaSistema { get; set; }
        public byte Activo { get; set; }
    }
}