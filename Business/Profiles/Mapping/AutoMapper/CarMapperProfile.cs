
using AutoMapper;
using Business.Dtos.Fuel;
using Business.Requests.Car;
using Business.Requests.Fuel;
using Business.Responses.Car;

using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class CarMapperProfile : Profile
{
    public CarMapperProfile()
    {
        addFuel();
        getFuel();
        deleteFuel();
        updateFuel();
    }

    public void addFuel()
    {
        CreateMap<AddCarRequest, Car>();
        CreateMap<Car, AddCarResponse>();
    }
    public void getFuel()
    {
        //Get By Id
        CreateMap<GetByIDCarResponse, Car>();
        CreateMap<Car, GetByIDCarResponse>();
        // Get List
        CreateMap<Car, GetCarListResponse>()
            .ForMember(
            destinationMember: dest => dest.Items,
            memberOptions: opt => opt.MapFrom(mapExpression: src => src));
    }
    public void deleteFuel()
    {
        CreateMap<DeletCarRequest, Car>();
        CreateMap<Car, DeleteCarResponse>();

    }
    public void updateFuel()
    {
        CreateMap<UpdateCarRequest, Car>();
        CreateMap<Car, UpdateCarResponse>();

    }
}
