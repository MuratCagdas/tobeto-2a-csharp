
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal :ICarDal
{
    private readonly RentACarContext _context;
    public EfCarDal(RentACarContext context)
    {
        _context = context;
    }
    public Car Add(Car entity)
    {
        _context.Cars.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public Car Delete(Car entity, bool isSoftDelete = true)
    {
        entity.DeletedAt = DateTime.Now;
        if (!isSoftDelete)
            _context.Cars.Remove(entity);

        _context.SaveChanges();
        return entity;
    }

    public Car? Get(Func<Car, bool> predicate)
    {
        Car? car = _context.Cars.FirstOrDefault(predicate);
        return car;
    }

    public IList<Car> GetList(Func<Car, bool>? predicate = null)
    {
        IQueryable<Car> query = _context.Set<Car>();
        if (predicate != null)
            query = query.Where(predicate).AsQueryable();

        return query.ToList();
    }

    public Car Update(Car entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        _context.Cars.Update(entity);
        _context.SaveChanges();
        return entity;
    }
}
