using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfCustomersDal :ICustomersDal
{
    private readonly RentACarContext _context;
    public EfCustomersDal(RentACarContext context)
    {
        _context = context;
    }
    public Customers Add(Customers entity)
    {
        _context.Customers.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public Customers Delete(Customers entity, bool isSoftDelete = true)
    {
        entity.DeletedAt = DateTime.Now;
        if (!isSoftDelete)
            _context.Customers.Remove(entity);

        _context.SaveChanges();
        return entity;
    }

    public Customers? Get(Func<Customers, bool> predicate)
    {
        Customers? customer = _context.Customers.FirstOrDefault(predicate);
        return customer;
    }

    public IList<Customers> GetList(Func<Customers, bool>? predicate = null)
    {
        IQueryable<Customers> query = _context.Set<Customers>();
        if (predicate != null)
            query = query.Where(predicate).AsQueryable();

        return query.ToList();
    }

    public Customers Update(Customers entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        _context.Customers.Update(entity);
        _context.SaveChanges();
        return entity;
    }
}
