using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IindividualCustomerDal : IEntityRepository<IndividualCustomer, int>
{
}
