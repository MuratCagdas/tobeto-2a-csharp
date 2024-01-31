using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfTransmissionDal :ITransmissionDal
{
    private readonly RentACarContext _context;
    public EfTransmissionDal(RentACarContext context)
    {
        _context = context;
    }
    public Transmission Add(Transmission entity)
    {
        _context.Transmissions.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public Transmission Delete(Transmission entity, bool isSoftDelete = true)
    {
        entity.DeletedAt = DateTime.Now;
        if (!isSoftDelete)
            _context.Transmissions.Remove(entity);

        _context.SaveChanges();
        return entity;
    }

    public Transmission? Get(Func<Transmission, bool> predicate)
    {
        Transmission? transmission = _context.Transmissions.FirstOrDefault(predicate);
        return transmission;
    }

    public IList<Transmission> GetList(Func<Transmission, bool>? predicate = null)
    {
        IQueryable<Transmission> query = _context.Set<Transmission>();
        if (predicate != null)
            query = query.Where(predicate).AsQueryable();

        return query.ToList();
    }

    public Transmission Update(Transmission entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        _context.Transmissions.Update(entity);
        _context.SaveChanges();
        return entity;
    }
}
