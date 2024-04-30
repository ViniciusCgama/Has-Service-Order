using OsDsII.api.Data;
using OsDsII.api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace OsDsII.api.Repository
{
    public class CustomersRepository
    {
        private readonly DataContext _datacontext;

        public CustomersRepository(DataContext datacontext)
        {
            _datacontext = datacontext;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _datacontext.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _datacontext.Customers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _datacontext.Customers.Add(customer);
            await _datacontext.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(Customer customer)
        {
            _datacontext.Customers.Remove(customer);
            await _datacontext.SaveChangesAsync();

        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _datacontext.Customers.Update(customer);
            await _datacontext.SaveChangesAsync();  
        }
    }
}
