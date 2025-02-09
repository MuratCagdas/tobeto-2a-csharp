﻿using Business.Dtos.Brand;
using Business.Dtos.Fuel;

namespace Business.Responses.Fuel;

public class GetFuelListResponse
{
    public ICollection<FuelListItemDto> Items { get; set; }

    public GetFuelListResponse()
    {
        Items = Array.Empty<FuelListItemDto>();
    }
    public GetFuelListResponse(ICollection<FuelListItemDto> ıtems)
    {
        Items = ıtems;
    }
}