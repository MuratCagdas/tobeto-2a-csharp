using AutoMapper;
using Business.Dtos.Model;
using Business.Requests.Users;
using Business.Responses.Users;
using Entities.Concrete;


namespace Business.Profiles.Mapping.AutoMapper;

public class UsersMapperProfile :Profile
{
    public UsersMapperProfile()
    {
        addModel();
        getModel();
        deleteModel();
        updateModel();
    }
    public void addModel()
    {
        CreateMap<AddUsersRequest, Users>();
        CreateMap<Users, AddUsersResponse>();
    }
    public void getModel()
    {
        //Get By Id
        CreateMap<GetUsersByIdRequest, Users>();
        CreateMap<Users, GetByIdUsersResponse>();
        // Get List
        //CreateMap<Model, ModelListItemDto>();
        //CreateMap<IList<Model>, GetModelListResponse>()
        //    .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
    }
    public void deleteModel()
    {
        CreateMap<Users, DeleteUsersResponse>();
    }
    public void updateModel()
    {
        CreateMap<UpdateUsersRequest, Users>();

        CreateMap<Users, UpdateUsersResponse>();
    }
}
