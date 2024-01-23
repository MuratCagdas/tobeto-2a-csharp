using AutoMapper;
using Business.Dtos.transmission;
using Business.Requests.Transmission;
using Business.Responses.Transmission;
using Entities.Concrete;

namespace Business.Profiles.Mapping.AutoMapper;

internal class TransmissionMapperProfile :Profile
{
    public TransmissionMapperProfile()
    {
        addTransmission();
        getTransmission();
        deleteTransmission();
        updateTransmission();
    }
    public void addTransmission()
    {
        CreateMap<AddTransmissionRequest, Transmission>();
        CreateMap<Transmission, AddTransmissionResponse>();
        CreateMap<DeleteTransmissionRequest, Transmission>();

    }
    public void getTransmission()
    {
        //Get By Id
        CreateMap<GetByIDTransmissionResponse, Transmission>();
        CreateMap<Transmission, GetByIDTransmissionResponse>();
        // Get List
        CreateMap<Transmission, TransmissionListItemDto>();
        CreateMap<IList<Transmission>, GetTransmissionListResponse>()
            .ForMember(
            destinationMember: dest => dest.Items,
            memberOptions: opt => opt.MapFrom(mapExpression: src => src));
    }
    public void deleteTransmission()
    {
        CreateMap<DeleteTransmissionRequest, Transmission>();
    }
    public void updateTransmission()
    {
        CreateMap<UpdateTransmissionRequest, Transmission>();
    }

}
