using AutoMapper;
using Business.Dtos.Model;
using Business.Requests.Users;
using Business.Responses.Users;
using Core.Entities;


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
        CreateMap<AddUsersRequest, User>();
        CreateMap<User, AddUsersResponse>();
    }
    public void getModel()
    {
        //Get By Id
        CreateMap<GetUsersByIdRequest, User>();
        CreateMap<User, GetByIdUsersResponse>();
        // Get List
        //CreateMap<Model, ModelListItemDto>();
        //CreateMap<IList<Model>, GetModelListResponse>()
        //    .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
    }
    public void deleteModel()
    {
        CreateMap<User, DeleteUsersResponse>();
    }
    public void updateModel()
    {
        CreateMap<UpdateUsersRequest, User>();

        CreateMap<User, UpdateUsersResponse>();
    }
}
