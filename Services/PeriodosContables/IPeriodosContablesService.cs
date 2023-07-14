using newcontableapi.Entities;

namespace newcontableapi.Services
{
    public interface IPeriodosContablesService
    {
        Task<List<PeriodoContable>> SelectPeriodoContableService(int IdPeriodoContable);
        Task<int> InsertPeriodoContableService(PeriodoContable periodoContable);
        Task<int> UpdatePeriodoContableService(int IdPeriodoContable, PeriodoContable periodoContable);
    }
}