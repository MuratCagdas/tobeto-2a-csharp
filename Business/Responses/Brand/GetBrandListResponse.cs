﻿using Business.Dtos.Brand;

namespace Business.Responses.Brand;

public class GetBrandListResponse
{
    public ICollection<BrandListItemDto> Items { get; set; }
    public GetBrandListResponse() 
    { 
        Items = Array.Empty<BrandListItemDto>();
    }
    public GetBrandListResponse(ICollection<BrandListItemDto> ıtems)
    {
        Items = ıtems;
    }
}