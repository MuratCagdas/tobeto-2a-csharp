

using Business.Abstract;
using Core.Entities;
using DataAccess.Concrete.EntityFramework;

namespace Business.Concrete;

public class RoleManager : IRoleService
{
    private readonly EfRoleDal _efRoleDal;

    public RoleManager(EfRoleDal efRoleDal)
    {
        _efRoleDal = efRoleDal;
    }

    public List<Role> GetRoles(User user)
    {
        return _efRoleDal.GetByRole(user);
    }
}
