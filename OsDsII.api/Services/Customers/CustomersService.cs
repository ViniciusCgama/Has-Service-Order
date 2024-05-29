using AutoMapper;
using OsDsII.api.Dtos;
using OsDsII.api.Models;
using OsDsII.api.Repository;
using Microsoft.EntityFrameworkCore;
using OsDsII.api.Services.Exceptions;
using OsDsII.api.Data;
using OsDsII.api.Dtos.Customer;
namespace OsDsII.api.Services.Customers
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;

        public CustomersService(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }


        public async Task GetCustomerAsync(int id)
        {
            var customer = await _customersRepository.GetByIdAsync(id);

            if (customer is null)
            {
                throw new NotFoundException("Customer not found");
            }
        }

        public async Task CreateAsync(CreateCustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            var customerExists = await _customersRepository.FindUserByEmailAsync(customer.Email);
            if (customerExists != null && !customerExists.Equals(customer))
            {
                throw new ConflictException("Customer already exists");
            }

            await _customersRepository.AddCustomerAsync(customer);
        }

        public async Task UpdateAsync(int id)
        {
            var customer = _mapper.Map<Customer>(id);

            var customerExists = await _customersRepository.FindUserByEmailAsync(customer.Email);
            if (customerExists != null && !customerExists.Equals(customer))
            {
                throw new ConflictException("Customer already exists");
            }

            await _customersRepository.UpdateCustomerAsync(customer);
        }

        public Task UpdateAsync(CustomerDto customer)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = _customersRepository.GetByIdAsync(id);
            if (customer is null)
            {
                throw new NotFoundException("Customer not found");
            }
            await _customersRepository.DeleteCustomerAsync(id);

        }

        public async Task <List<Customer>> GetAllCustomerAsync()
        {
            return await _customersRepository.GetAllCustomersAsync();
        }

        public Task GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}