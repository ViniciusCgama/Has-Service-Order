using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OsDsII.api.Data;
using OsDsII.api.Dtos;
using OsDsII.api.Models;
using OsDsII.api.Repository;
using OsDsII.api.Services.Customers;
using OsDsII.api.Services.Http.Exceptions;

namespace OsDsII.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly Mapper _mapper;
        private readonly ICustomersRepository _customersRepository;
        private readonly ICustomersService _customersService;

        public CustomersController(DataContext dataContext, Mapper mapper, ICustomersRepository customersRepository, ICustomersService customersService)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _customersRepository = customersRepository;
            _customersService = customersService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetAllAsync()
        {
            try {

                List<Customer> customers = await _dataContext.Customers.ToListAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }




        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                Customer customer = await _dataContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
                if (customer is null)
                {
                    return NotFound("Customer not found");
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCustomerAsync(CreateCustomerDto customer)
        {
            try
            {
                await _customersService.CreateAsync(customer); // assíncrono porém void

                return Created(nameof(CustomersController), customer);
            }
            catch (BaseException ex)
            {
                return ex.GetResponse();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]


        public async Task<IActionResult> DeleteCustomerAsync(int id)
        {
            try
            {
                Customer customer = await _dataContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
                if (customer is null)
                {
                    return NotFound("Customer not found");
                }
                _dataContext.Customers.Remove(customer);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public async Task<IActionResult> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                Customer currentCustomer = await _dataContext.Customers.FirstOrDefaultAsync(c => c.Id == customer.Id);
                if (customer is null)
                {
                    return NotFound("Customer not found");
                }
                _dataContext.Customers.Update(customer);
                await _dataContext.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

     

    }
}