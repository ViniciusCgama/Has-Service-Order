using OsDsII.api.Dtos.Customer;

namespace OsDsII.api.Services.Customers
{
    public interface ICustomersService
    {
        public Task GetAllAsync();
        public Task DeleteAsync(int id);
        public Task<CustomerDto> GetCustomerAsync(int id);
        public Task UpdateAsync(int id);
        public Task CreateAsync(CreateCustomerDto customer);
    }
}