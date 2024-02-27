
using Core.Entities;
using System.Security.Claims;

namespace Core.Utilities.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user/*, ICollection<Role> roleClaims*/);
}
