using newcontableapi.Entities;

namespace newcontableapi.Services
{
    public interface ICentroCostosService
    {
        Task<List<CentroCostos>> SelectCentroCostosService(int IdCentroCosto);
        Task<int> InsertCentroCostosService(CentroCostos centroCostos);
        Task<int> UpdateCentroCostosService(int IdCentroCosto, CentroCostos centroCostos);
    }
}