using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfUsersDal :IUsersDal
{
    private readonly RentACarContext _context;
    public EfUsersDal(RentACarContext context)
    {
        _context = context;
    }
    public Users Add(Users entity)
    {
        _context.Users.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public Users Delete(Users entity, bool isSoftDelete = true)
    {
        entity.DeletedAt = DateTime.Now;
        if (!isSoftDelete)
            _context.Users.Remove(entity);

        _context.SaveChanges();
        return entity;
    }

    public Users? Get(Func<Users, bool> predicate)
    {
        Users? users = _context.Users.FirstOrDefault(predicate);
        return users;
    }

    public IList<Users> GetList(Func<Users, bool>? predicate = null)
    {
        IQueryable<Users> query = _context.Set<Users>();
        if (predicate != null)
            query = query.Where(predicate).AsQueryable();

        return query.ToList();
    }

    public Users Update(Users entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        _context.Users.Update(entity);
        _context.SaveChanges();
        return entity;
    }
}
