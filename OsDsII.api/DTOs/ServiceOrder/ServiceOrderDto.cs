using OsDsII.api.Models;

namespace OsDsII.api.DTOs.ServiceOrder
{
    public record ServiceOrderDto(
    string Description,
    double Price,
    StatusServiceOrder Status,
    DateTimeOffset OpeningDate,
    DateTimeOffset FinishDate
    );
}

