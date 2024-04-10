using OsDsII.api.Models;

namespace OsDsII.api.Repository
{
    public interface IServiceOrderRepository
    {
        Task<List<ServiceOrder>> GetAllAsync();
        Task<ServiceOrder> GetByIdAsync(int id);
        Task<ServiceOrder> AddAsync(ServiceOrder serviceOrder);
        Task FinishAsync(ServiceOrder serviceOrder);
        Task CancelAsync(ServiceOrder serviceOrder);
    }
}   
    