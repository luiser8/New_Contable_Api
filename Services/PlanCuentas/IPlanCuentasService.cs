using newcontableapi.Entities;

namespace newcontableapi.Services
{
    public interface IPlanCuentasService
    {
        Task<List<PlanCuentas>> SelectPlanCuentasService(int IdPlanCuenta);
        Task<int> InsertPlanCuentasService(PlanCuentas planCuentas);
        Task<int> UpdatePlanCuentasService(int IdPlanCuenta, PlanCuentas planCuentas);
    }
}