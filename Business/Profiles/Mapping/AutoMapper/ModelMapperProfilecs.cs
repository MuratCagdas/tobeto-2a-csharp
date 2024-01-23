
using Business.Dtos.Fuel;
using Business.Dtos.Model;
using Business.Requests.Fuel;
using AutoMapper;
using Business.Requests.Model;
using Business.Responses.Model;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

public class ModelMapperProfilecs:Profile
{
    public ModelMapperProfilecs()
    {
        addModel();
        getModel();
        deleteModel();
        updateModel();
    }
    public void addModel()
    {
        CreateMap<AddModelRequest, Model>();

        CreateMap<Model, ModelListItemDto>();
        CreateMap<IList<Model>, GetModelListResponse>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
    }
    public void getModel()
    {
        //Get By Id
        CreateMap<GetByIDModelResponse, Model>();
        CreateMap<Fuel, GetByIDModelResponse>();
        // Get List
        CreateMap<Fuel, ModelListItemDto>();
        CreateMap<Fuel, GetModelListResponse>()
            .ForMember(
            destinationMember: dest => dest.Items,
            memberOptions: opt => opt.MapFrom(mapExpression: src => src));
    }
    public void deleteModel()
    {
        CreateMap<DeleteFuelRequest, Fuel>();
    }
    public void updateModel()
    {
        CreateMap<UpdateFuelRequest, Fuel>();

        CreateMap<Fuel, FuelUpdateDto>().ReverseMap();
        CreateMap<FuelUpdateDto, UpdateModelResponse>()
            .ForMember(
            destinationMember: dest => dest.UpdatedAt,
            memberOptions: opt => opt.MapFrom(mapExpression: src => src));
    }
}
