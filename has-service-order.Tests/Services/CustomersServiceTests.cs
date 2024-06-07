using AutoMapper;
using Moq;
using OsDsII.api.Dtos.Customer;
using OsDsII.api.Models;
using OsDsII.api.Repository;
using OsDsII.api.Services.Customers;

namespace has_service_order.Tests.Services
{
    public class CustomersServiceTests
    {
        private readonly Mock<ICustomersRepository> _mockCustomersRepository;
        private readonly Mock<IMapper> _mockMapper;

        private readonly CustomersService _service;

        public CustomersServiceTests()
        {
            _mockCustomersRepository = new Mock<ICustomersRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new CustomersService(_mockCustomersRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task ShouldReutnACustomer_WhenPassAnId()
        {
            int expectedUserId = 1;
            Customer customer = new Customer(1, "Vini", "vinimoscoumt@mail.com", "119");
            CustomerDto customerDto = new CustomerDto("Vini", "vinimoscoumt@mail.com", "119", null);

            _mockCustomersRepository.Setup(repository => repository.GetByIdAsync(expectedUserId)).ReturnsAsync(customer);
            var result = await _service.GetCustomerAsync(expectedUserId);
            _mockMapper.Setup(m => m.Map<CustomerDto>(customer)).Returns(customerDto);
            Assert.Equal(customerDto, result);
        }
    }
}
