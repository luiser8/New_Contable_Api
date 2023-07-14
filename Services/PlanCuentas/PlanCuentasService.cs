
using newcontableapi.Entities;
using newcontableapi.Repository;

namespace newcontableapi.Services
{
    public class PlanCuentasService : IPlanCuentasService
    {
        private readonly IPlanCuentasRepository _planCuentasRepository;
        public PlanCuentasService(IPlanCuentasRepository planCuentasRepository)
        {
            _planCuentasRepository = planCuentasRepository;
        }

        public async Task<List<PlanCuentas>> SelectPlanCuentasService(int IdPlanCuenta)
        {
            try
            {
                return await _planCuentasRepository.SelectPlanCuentasRepository(IdPlanCuenta);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<int> InsertPlanCuentasService(PlanCuentas planCuentas)
        {
            try
            {
                return await _planCuentasRepository.InsertPlanCuentasRepository(planCuentas);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<int> UpdatePlanCuentasService(int IdPlanCuenta, PlanCuentas planCuentas)
        {
            try
            {
                return await _planCuentasRepository.UpdatePlanCuentasRepository(IdPlanCuenta, planCuentas);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}