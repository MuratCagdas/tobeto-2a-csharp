using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfFuelDal :IFuelDal
{
    private readonly RentACarContext _context;
    public EfFuelDal(RentACarContext context)
    {
        _context = context;
    }
    public Fuel Add(Fuel entity)
    {
        _context.Fuels.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public Fuel Delete(Fuel entity, bool isSoftDelete = true)
    {
        entity.DeletedAt = DateTime.Now;
        if (!isSoftDelete)
            _context.Fuels.Remove(entity);

        _context.SaveChanges();
        return entity;
    }

    public Fuel? Get(Func<Fuel, bool> predicate)
    {
        Fuel? fuel = _context.Fuels.FirstOrDefault(predicate);
        return fuel;
    }

    public IList<Fuel> GetList(Func<Fuel, bool>? predicate = null)
    {
        IQueryable<Fuel> query = _context.Set<Fuel>();
        if (predicate != null)
            query = query.Where(predicate).AsQueryable();

        return query.ToList();
    }

    public Fuel Update(Fuel entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        _context.Fuels.Update(entity);
        _context.SaveChanges();
        return entity;
    }
}
