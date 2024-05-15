using AutoMapper;
using OsDsII.api.Repository;

namespace OsDsII.api.Services.ServiceOrder
{
    public class ServiceOrder
    {
        private readonly IServiceOrderRepository _serviceOrderRepository;
        private readonly IMapper _mapper;

        public ServiceOrder(ICustomersRepository customersRepository, IMapper mapper, IServiceOrderRepository serviceOrder)
        {
            _serviceOrderRepository = serviceOrder;
            _mapper = mapper;
        }




    }
}
