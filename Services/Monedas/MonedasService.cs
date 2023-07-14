
using newcontableapi.Entities;
using newcontableapi.Repository;

namespace newcontableapi.Services
{
    public class MonedasService : IMonedasService
    {
        private readonly IMonedasRepository _monedasRepository;
        public MonedasService(IMonedasRepository monedasRepository)
        {
            _monedasRepository = monedasRepository;
        }

        public async Task<List<Monedas>> SelectMonedasService(int IdMoneda)
        {
            try
            {
                return await _monedasRepository.SelectMonedasRepository(IdMoneda);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<int> InsertMonedasService(Monedas monedas)
        {
            try
            {
                return await _monedasRepository.InsertMonedasRepository(monedas);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<int> UpdateMonedasService(int IdMoneda, Monedas monedas)
        {
            try
            {
                return await _monedasRepository.UpdateMonedasRepository(IdMoneda, monedas);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}