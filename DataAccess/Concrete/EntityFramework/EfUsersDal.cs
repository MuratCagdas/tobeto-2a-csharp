using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework;

public class EfUsersDal : EfEntityRepositoryBase<User, int, RentACarContext>, IUsersDal
{
    public EfUsersDal(RentACarContext context) : base(context)
    {

    }
}
