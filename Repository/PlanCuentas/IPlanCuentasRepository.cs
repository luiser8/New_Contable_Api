
using newcontableapi.Entities;

namespace newcontableapi.Repository
{
    public interface IPlanCuentasRepository
    {
        Task<List<PlanCuentas>> SelectPlanCuentasRepository(int IdPlanCuenta);
        Task<int> InsertPlanCuentasRepository(PlanCuentas planCuentas);
        Task<int> UpdatePlanCuentasRepository(int IdPlanCuenta, PlanCuentas planCuentas);
    }
}