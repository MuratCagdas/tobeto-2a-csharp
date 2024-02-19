using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfIndividualDal : EfEntityRepositoryBase<IndividualCustomer, int, RentACarContext>, IindividualCustomerDal
{
    public EfIndividualDal(RentACarContext context) : base(context)
    {
    }
}
