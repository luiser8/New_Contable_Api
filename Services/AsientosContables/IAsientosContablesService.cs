using newcontableapi.Entities;

namespace newcontableapi.Services
{
    public interface IAsientosContablesService
    {
        Task<List<AsientoContableDetalleResponse>> SelectAsientosContablesService(string FechaDesde, string FechaHasta, int IdPeriodoContable);
        Task<int> InsertAsientosContablesService(AsientosContables asientosContables);
        Task<int> UpdateAsientosContablesService(int IdAsiento, AsientosContables asientosContables);
        Task<int> UpdateAsientosContablesDetallesService(int IdAsientoDetalle, AsientosContablesDetalles asientosContablesDetalles);
    }
}