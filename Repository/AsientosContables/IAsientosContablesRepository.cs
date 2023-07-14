using newcontableapi.Entities;

namespace newcontableapi.Repository
{
    public interface IAsientosContablesRepository
    {
        Task<List<AsientoContableDetalleResponse>> SelectAsientosContablesRepository(string FechaDesde, string FechaHasta, int IdPeriodoContable);
        Task<int> InsertAsientosContablesRepository(AsientosContables asientosContables);
        Task<int> InsertAsientosContablesDetallesRepository(int IdAsiento, List<AsientosContablesDetalles> asientosContablesDetalles);
        Task<int> UpdateAsientosContablesRepository(int IdAsiento, AsientosContables asientosContables);
        Task<int> UpdateAsientosContablesDetallesRepository(int IdAsientoDetalle, AsientosContablesDetalles asientosContablesDetalles);
    }
}