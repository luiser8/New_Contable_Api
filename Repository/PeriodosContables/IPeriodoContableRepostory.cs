
using newcontableapi.Entities;

namespace newcontableapi.Repository
{
    public interface IPeriodoContableRepostory
    {
        Task<List<PeriodoContable>> SelectPeriodoContableRepository(int IdPeriodoContable);
        Task<int> InsertPeriodoContableRepository(PeriodoContable periodoContable);
        Task<int> UpdatePeriodoContableRepository(int IdPeriodoContable, PeriodoContable periodoContable);
    }
}