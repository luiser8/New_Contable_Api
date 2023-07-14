
using newcontableapi.Entities;

namespace newcontableapi.Repository
{
    public interface ICentroCostosRepository
    {
        Task<List<CentroCostos>> SelectCentroCostosRepository(int IdCentroCosto);
        Task<int> InsertCentroCostosRepository(CentroCostos centroCostos);
        Task<int> UpdateCentroCostosRepository(int IdCentroCosto, CentroCostos centroCostos);
    }
}