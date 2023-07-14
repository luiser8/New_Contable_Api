namespace newcontableapi.Entities
{
    public class CentroCostos
    {
        public int IdCentroCosto { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaSistema { get; set; }
        public byte Activo { get; set; }
    }
}