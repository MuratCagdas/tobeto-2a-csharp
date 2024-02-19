using Core.DataAccess;
using Core.Entities;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IUsersDal  : IEntityRepository<user, int>
{
}
