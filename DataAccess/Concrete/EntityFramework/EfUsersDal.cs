using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfUsersDal : EfEntityRepositoryBase<user, int, RentACarContext>, IUsersDal
{
    public EfUsersDal(RentACarContext context) : base(context)
    {
    }
}
