namespace newcontableapi.Entities
{
    public class AsientosContablesDetalles
    {
        public int IdAsientoDetalle { get; set; }
        public int IdAsiento { get; set; }
        public int IdPlanCuenta { get; set; }
        public int IdCentroCosto { get; set; }
        public int IdMoneda { get; set; }
        public string? Descripcion { get; set; }
        public byte Tipo { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public string? Referencia { get; set; }
        public DateTime FechaAsientoDetalle { get; set; }
        public DateTime FechaSistema { get; set; }
        public bool Activo { get; set; }
    }
    public class AsientoContableDetalleResponse
    {
        public int IdAsientoDetalle { get; set; }
        public int NroComprobante { get; set; }
        public int IdPeriodoContable { get; set; }
        public string? PeriodoContable { get; set; }
        public int IdPlanCuenta { get; set; }
        public string? CodPlanCuenta { get; set; }
        public string? PlanCuenta { get; set; }
        public int IdCentroCosto { get; set; }
        public string? CentroCosto { get; set; }
        public int IdMoneda { get; set; }
        public string? Moneda { get; set; }
        public string? Descripcion { get; set; }
        public byte Tipo { get; set; }
        public decimal Debe { get; set; }
        public decimal Haber { get; set; }
        public string? Referencia { get; set; }
        public DateTime FechaAsiento { get; set; }
        public DateTime FechaAsientoDetalle { get; set; }
        public DateTime FechaSistema { get; set; }
        public bool AsientoActivo { get; set; }
    }
}
