using newcontableapi.Entities;

namespace newcontableapi.Services
{
    public interface IMonedasService
    {
        Task<List<Monedas>> SelectMonedasService(int IdMoneda);
        Task<int> InsertMonedasService(Monedas monedas);
        Task<int> UpdateMonedasService(int IdMoneda, Monedas monedas);
    }
}