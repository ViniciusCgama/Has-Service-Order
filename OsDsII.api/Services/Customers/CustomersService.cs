using OsDsII.api.Dtos;
using OsDsII.api.Repository;

namespace OsDsII.api.Services.Customers
{
    public sealed class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersService(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task CreateAsync(CreateCustomerDto customer)
        {

        }
    }
}