
using Business.Dtos.Fuel;

namespace Business.Responses.Car;

public class GetCarListResponse
{
    public ICollection<FuelListItemDto> Items { get; set; }

    public GetCarListResponse()
    {
        Items = Array.Empty<FuelListItemDto>();
    }
    public GetCarListResponse(ICollection<FuelListItemDto> ıtems)
    {
        Items = ıtems;
    }
}