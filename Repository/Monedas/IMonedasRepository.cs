
using newcontableapi.Entities;

namespace newcontableapi.Repository
{
    public interface IMonedasRepository
    {
        Task<List<Monedas>> SelectMonedasRepository(int IdMoneda);
        Task<int> InsertMonedasRepository(Monedas monedas);
        Task<int> UpdateMonedasRepository(int IdMoneda, Monedas monedas);
    }
}