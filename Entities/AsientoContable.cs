namespace newcontableapi.Entities
{
    public class AsientosContables
    {
        public int IdAsiento { get; set; }
        public int IdPeriodoContable { get; set; }
        public DateTime FechaAsiento { get; set; }
        public DateTime FechaSistema { get; set; }
        public byte Activo { get; set; }
        public virtual List<AsientosContablesDetalles>? AsientosContablesDetalles { get; set; }
    }
}