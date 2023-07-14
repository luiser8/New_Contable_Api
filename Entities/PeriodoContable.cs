namespace newcontableapi.Entities
{
    public class PeriodoContable
    {
        public int IdPeriodoContable { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaSistema { get; set; }
        public byte Activo { get; set; }
    }
}