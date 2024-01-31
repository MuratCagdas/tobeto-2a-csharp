﻿using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfIndividualDal : IindividualCustomerDal
{
    private readonly RentACarContext _context;
    public EfIndividualDal(RentACarContext context)
    {
        _context = context;
    }
    public IndividualCustomer Add(IndividualCustomer entity)
    {
        _context.IndividualCustomers.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public IndividualCustomer Delete(IndividualCustomer entity, bool isSoftDelete = true)
    {
        entity.DeletedAt = DateTime.Now;
        if (!isSoftDelete)
            _context.IndividualCustomers.Remove(entity);

        _context.SaveChanges();
        return entity;
    }

    public IndividualCustomer? Get(Func<IndividualCustomer, bool> predicate)
    {
        IndividualCustomer? individualCustomer = _context.IndividualCustomers.FirstOrDefault(predicate);
        return individualCustomer;
    }

    public IList<IndividualCustomer> GetList(Func<IndividualCustomer, bool>? predicate = null)
    {
        IQueryable<IndividualCustomer> query = _context.Set<IndividualCustomer>();
        if (predicate != null)
            query = query.Where(predicate).AsQueryable();

        return query.ToList();
    }

    public IndividualCustomer Update(IndividualCustomer entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        _context.IndividualCustomers.Update(entity);
        _context.SaveChanges();
        return entity;
    }
}
