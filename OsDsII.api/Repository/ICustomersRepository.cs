using OsDsII.api.Models;

namespace OsDsII.api.Repository
{
    public interface ICustomersRepository
    {
        Task<List<Customer>> GetAllascyn();
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> CreateCustumerAsync(Customer customer);
        Task DeleteCustumerAsync(int id);
        Task UpdateCustumerAsync(Customer customer);
        Task AddCustomerAsync(Customer customer);
    }
}
