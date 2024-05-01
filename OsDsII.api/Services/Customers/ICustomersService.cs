using OsDsII.api.Dtos;

namespace OsDsII.api.Services.Customers
{
    public interface ICustomersService
    {
        public Task GetAllAsync();
        public Task DeleteAsync(int id);
        public Task GetCustomerAsync(int id);
        public Task UpdateAsync(int id);
        public Task CreateAsync(CreateCustomerDto customer);
    }
}