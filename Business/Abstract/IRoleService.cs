
using Core.Entities;

namespace Business.Abstract;

public interface IRoleService
{
    public List<Role> GetRoles(User user);
}
