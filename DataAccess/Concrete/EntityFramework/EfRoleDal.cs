

using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework;

public class EfRoleDal : EfEntityRepositoryBase<Role, int, RentACarContext>, IRoleDal
{
    private readonly RentACarContext _Context;
    public EfRoleDal(RentACarContext context) : base(context)
    {
        _Context = context;
    }
    public List<Role> GetByRole(User user)
    {
        var queryResult = from r in _Context.Roles
                          join ur in _Context.UserRoles on r.Id equals ur.RoleId
                          where ur.UserId == user.Id
                          select new Role
                          {
                              Id = r.Id,
                              RoleName = r.RoleName
                          };
        
        return queryResult.ToList();
    }

}
