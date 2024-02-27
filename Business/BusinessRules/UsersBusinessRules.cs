
using Business.Abstract;
using Core.Entities;
using DataAccess.Abstract;

namespace Business.BusinessRules;

public class UsersBusinessRules
{
    private readonly IUsersDal _userDal;
    private readonly IRoleService _roleService;
    public UsersBusinessRules(IUsersDal userDal ,IRoleService roleService)
    {
        _userDal = userDal;
        _roleService = roleService;
    }
    public ICollection<Role> Roles(User user )
    {
        return _roleService.GetRoles(user);
    }
}
