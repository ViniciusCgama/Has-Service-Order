using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OsDsII.api.Data;
using OsDsII.api.Models;

namespace OsDsII.api.Repository
{
    public class ServiceOrderRepository : IServiceOrderRepository
    {

        private readonly DataContext _dataContext;

        public ServiceOrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<ServiceOrder>> GetAllAsync()
        {
            return await _dataContext.ServiceOrders.ToListAsync();
        }

        public async Task<ServiceOrder> GetByIdAsync(int id)
        {
            return await _dataContext.ServiceOrders.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ServiceOrder> AddAsync(ServiceOrder serviceOrder)
        {
            _dataContext.ServiceOrders.Add(serviceOrder);
            await _dataContext.SaveChangesAsync();
            return serviceOrder;
        }

        public async Task FinishAsync(ServiceOrder serviceOrder)
        {
            _dataContext.ServiceOrders.Update(serviceOrder);
            await _dataContext.SaveChangesAsync();
        }

        public async Task CancelAsync(ServiceOrder serviceOrder)
        {
            _dataContext.ServiceOrders.Update(serviceOrder);
            await _dataContext.SaveChangesAsync();
        }


    }
}

