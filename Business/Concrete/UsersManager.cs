

using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Users;
using Business.Responses.Users;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class UsersManager : IUsersService
{
    private readonly IUsersDal _usersDal;
    private readonly UsersBusinessRules _usersBusinessRules;
    private readonly IMapper _mapper;

    public UsersManager(IUsersDal usersDal, UsersBusinessRules usersBusinessRules, IMapper mapper)
    {
        _usersDal = usersDal;
        _usersBusinessRules = usersBusinessRules;
        _mapper = mapper;
    }
    public AddUsersResponse Add(AddUsersRequest request)
    {
        // mapping
        var usersToAdd = _mapper.Map<Users>(request);

        // data operations
        Users updatedUsers = _usersDal.Add(usersToAdd);

        // mapping & response
        var response = _mapper.Map<AddUsersResponse>(updatedUsers);
        return response;
    }

    public DeleteUsersResponse Delete(DeleteUsersRequest request)
    {
        Users? usersToDelete = _usersDal.Get(predicate: model => model.Id == request.Id);
        //_modelBusinessRules.CheckIfModelExists(modelToDelete); 

        Users deletedUsers = _usersDal.Delete(usersToDelete!); 

        var response = _mapper.Map<DeleteUsersResponse>(
            deletedUsers
        );
        return response;
    }

    public GetByIdUsersResponse GetById(GetUsersByIdRequest request)
    {
        Users? users = _usersDal.Get(predicate: model => model.Id == request.Id);
        //_modelBusinessRules.CheckIfModelExists(model);

        var response = _mapper.Map<GetByIdUsersResponse>(users);
        return response;
    }

    public GetUsersListResponse GetList(GetUsersListRequest request)
    {
        IList<Users> brandList = _usersDal.GetList();
        GetUsersListResponse response = _mapper.Map<GetUsersListResponse>(brandList);
        return response;
    }

    public UpdateUsersResponse Update(UpdateUsersRequest request)
    {
        Users? usersToUpdate = _usersDal.Get(predicate: user => user.Id == request.Id); 
        usersToUpdate = _mapper.Map(request, usersToUpdate); 
        Users updatedUsers = _usersDal.Update(usersToUpdate!); 

        var response = _mapper.Map<UpdateUsersResponse>(
            updatedUsers 
        );
        return response;
    }
}
