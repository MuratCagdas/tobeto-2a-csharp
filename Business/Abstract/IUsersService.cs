using Business.Requests.Users;
using Business.Responses.Users;
using Core.Utilities.Security.JWT;

namespace Business.Abstract;

public interface IUsersService
{
    void Register(RegisterRequest request);
    AccessToken Login(LoginRequest request); //TODO: return type: JWT 
}
