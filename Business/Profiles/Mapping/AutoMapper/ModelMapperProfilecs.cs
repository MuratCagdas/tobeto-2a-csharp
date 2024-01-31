
using Business.Dtos.Model;
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
        CreateMap<Model, AddModelResponse>();
    }
    public void getModel()
    {
        //Get By Id
        CreateMap<GetModelByIdRequest, Model>();
        CreateMap<Model, GetByIDModelResponse>();
        // Get List
        CreateMap<Model, ModelListItemDto>();
        CreateMap<IList<Model>, GetModelListResponse>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
    }
    public void deleteModel()
    {
        CreateMap<Model, DeleteModelResponse>();
    }
    public void updateModel()
    {
        CreateMap<UpdateModelRequest, Model>();

        CreateMap<Model, UpdateModelResponse>();
    }
}
