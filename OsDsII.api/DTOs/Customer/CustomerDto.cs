using OsDsII.api.Models;
using OsDsII.api.DTOs.ServiceOrder;

namespace OsDsII.api.Dtos.Customer
{
    public record CustomerDto(string Name, string Email, string Phone, List<ServiceOrderDto> ListServiceOrder);

}