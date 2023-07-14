
using newcontableapi.Entities;
using newcontableapi.Repository;

namespace newcontableapi.Services
{
    public class AsientosContablesService : IAsientosContablesService
    {
        private readonly IAsientosContablesRepository _asientosContablesRepository;
        public AsientosContablesService(IAsientosContablesRepository asientosContablesRepository)
        {
            _asientosContablesRepository = asientosContablesRepository;
        }

        public async Task<List<AsientoContableDetalleResponse>> SelectAsientosContablesService(string FechaDesde, string FechaHasta, int IdPeriodoContable)
        {
            try
            {
                return await _asientosContablesRepository.SelectAsientosContablesRepository(FechaDesde, FechaHasta, IdPeriodoContable);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<int> InsertAsientosContablesService(AsientosContables asientosContables)
        {
            int IdAsientoDetalleSave = 0;
            try
            {
                int IdAsientoSave = await _asientosContablesRepository.InsertAsientosContablesRepository(asientosContables);
                if (IdAsientoSave != 0)
                {
                    IdAsientoDetalleSave = await _asientosContablesRepository.InsertAsientosContablesDetallesRepository(IdAsientoSave, asientosContables.AsientosContablesDetalles);
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
            return IdAsientoDetalleSave;
        }

        public async Task<int> UpdateAsientosContablesService(int IdAsiento, AsientosContables asientosContables)
        {
            try
            {
                return await _asientosContablesRepository.UpdateAsientosContablesRepository(IdAsiento, asientosContables);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<int> UpdateAsientosContablesDetallesService(int IdAsientoDetalle, AsientosContablesDetalles asientosContablesDetalles)
        {
            try
            {
                return await _asientosContablesRepository.UpdateAsientosContablesDetallesRepository(IdAsientoDetalle, asientosContablesDetalles);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}