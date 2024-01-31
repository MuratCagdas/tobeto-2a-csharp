using Business.Requests.Users;
using Business.Responses.Users;

namespace Business.Abstract;

public interface IUsersService
{
    public AddUsersResponse Add(AddUsersRequest request);
    public GetUsersListResponse GetList(GetUsersListRequest request);
    public GetByIdUsersResponse GetById(GetUsersByIdRequest id);
    public DeleteUsersResponse Delete(DeleteUsersRequest request);
    public UpdateUsersResponse Update(UpdateUsersRequest request);
}
