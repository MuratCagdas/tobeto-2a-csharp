using AutoMapper;
using Business.Dtos.Fuel;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class FuelMapperProfile :Profile
{
    public FuelMapperProfile()
    {
        addFuel();
        getFuel();
        deleteFuel();
        updateFuel();
    }
    public void addFuel()
    {
        CreateMap<AddFuelRequest, Fuel>();
        CreateMap<Fuel, AddFuelResponse>();
    }
    public void getFuel()
    {
        //Get By Id
        CreateMap<GetByIDFuelResponse, Fuel>();
        CreateMap<Fuel, GetByIDFuelResponse>();
        // Get List
        CreateMap<Fuel, FuelListItemDto>();
        CreateMap<Fuel, GetFuelListResponse>()
            .ForMember(
            destinationMember: dest => dest.Items,
            memberOptions: opt => opt.MapFrom(mapExpression: src => src));
    }
    public void deleteFuel()
    {
        CreateMap<DeleteFuelRequest, Fuel>();
        CreateMap<Fuel, DeleteFuelResponse>();

    }
    public void updateFuel()
    {
        CreateMap<UpdateFuelRequest, Fuel>();

        CreateMap<Fuel, FuelUpdateDto>().ReverseMap();
        CreateMap<FuelUpdateDto, UpdateFuelResponse>()
            .ForMember(
            destinationMember: dest => dest.FuelUpdate,
            memberOptions: opt => opt.MapFrom(mapExpression: src => src));
    }

}
