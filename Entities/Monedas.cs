namespace newcontableapi.Entities
{
    public class Monedas
    {
        public int IdMoneda { get; set; }
        public string? Simbolo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaSistema { get; set; }
        public byte Activo { get; set; }
    }
}