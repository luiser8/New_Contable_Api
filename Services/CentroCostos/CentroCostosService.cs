
using newcontableapi.Entities;
using newcontableapi.Repository;

namespace newcontableapi.Services
{
    public class CentroCostosService : ICentroCostosService
    {
        private readonly ICentroCostosRepository _centroCostosRepository;
        public CentroCostosService(ICentroCostosRepository centroCostosRepository)
        {
            _centroCostosRepository = centroCostosRepository;
        }

        public async Task<List<CentroCostos>> SelectCentroCostosService(int IdCentroCosto)
        {
            try
            {
                return await _centroCostosRepository.SelectCentroCostosRepository(IdCentroCosto);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<int> InsertCentroCostosService(CentroCostos centroCostos)
        {
            try
            {
                return await _centroCostosRepository.InsertCentroCostosRepository(centroCostos);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<int> UpdateCentroCostosService(int IdCentroCosto, CentroCostos centroCostos)
        {
            try
            {
                return await _centroCostosRepository.UpdateCentroCostosRepository(IdCentroCosto, centroCostos);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}