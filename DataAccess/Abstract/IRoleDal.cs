

using Core.DataAccess;
using Core.Entities;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IRoleDal : IEntityRepository<Role, int>
{
}
