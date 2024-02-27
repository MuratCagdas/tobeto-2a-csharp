

using System.Security.Claims;

namespace Core.Extensions;

public static class RoleExtension
{
    public static void AddRoles(this ICollection<Claim> claims, string[] roles)
    {
        roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
    }
}
