
using newcontableapi.Entities;
using newcontableapi.Repository;

namespace newcontableapi.Services
{
    public class PeriodosContablesService : IPeriodosContablesService
    {
        private readonly IPeriodoContableRepostory _periodoContableRepostory;
        public PeriodosContablesService(IPeriodoContableRepostory periodoContableRepostory)
        {
            _periodoContableRepostory = periodoContableRepostory;
        }

        public async Task<List<PeriodoContable>> SelectPeriodoContableService(int IdPeriodoContable)
        {
            try
            {
                return await _periodoContableRepostory.SelectPeriodoContableRepository(IdPeriodoContable);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<int> InsertPeriodoContableService(PeriodoContable periodoContable)
        {
            try
            {
                return await _periodoContableRepostory.InsertPeriodoContableRepository(periodoContable);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<int> UpdatePeriodoContableService(int IdPeriodoContable, PeriodoContable periodoContable)
        {
            try
            {
                return await _periodoContableRepostory.UpdatePeriodoContableRepository(IdPeriodoContable, periodoContable);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}