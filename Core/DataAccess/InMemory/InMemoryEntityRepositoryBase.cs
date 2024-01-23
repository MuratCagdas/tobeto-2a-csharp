using Core.Entities;

namespace Core.DataAccess.InMemory;

public abstract class InMemoryEntityRepositoryBase<TEntity, TEntityId>
    : IEntityRepository<TEntity, TEntityId>
    where TEntity : class, IEntity<TEntityId>, new()
{
    protected readonly HashSet<TEntity> Entities = new();

    protected abstract TEntityId generateId();

    public TEntity Add(TEntity entity)
    {
        entity.Id = generateId();
        entity.CreatedAt = DateTime.UtcNow;
        Entities.Add(entity);
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        entity.DeletedAt = DateTime.UtcNow;

        TEntity delete = Entities.First(b => b.Id.Equals(entity.Id));
        Entities.Remove(delete);
        return delete;
    }

    public TEntity? Get(Func<TEntity, bool> predicate)
    {
        TEntity? entity = Entities.FirstOrDefault(predicate);
        return entity;
    }

    public IList<TEntity> GetList(Func<TEntity, bool>? predicate = null)
    {
        IEnumerable<TEntity> query = Entities;

        if (predicate is not null)
            query = query.Where(predicate);

        return query.ToArray();
    }

    public TEntity Update(TEntity entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        TEntity update = Entities.First(e => e.Id.Equals(entity.Id));
        Entities.Remove(update);
        Entities.Add(entity);
        return entity;
    }
    //public void Add(TEntity entity)
    //{
    //    entity.Id = generateId();
    //    entity.CreatedAt = DateTime.UtcNow;
    //    _entities.Add(entity);
    //}

    //public void Delete(TEntity entity)
    //{
    //    TEntity delete = _entities.First(b => b.Id.Equals(entity.Id));
    //    _entities.Remove(delete);

    //    entity.DeletedAt = DateTime.UtcNow;
    //}

    //public TEntity? GetById(TEntityId id)
    //{
    //    TEntity? entity = _entities.FirstOrDefault(
    //        e => e.Id.Equals(id) && e.DeletedAt.HasValue == false
    //    );
    //    return entity;
    //}

    //public IList<TEntity> GetList()
    //{
    //    IList<TEntity> entities = _entities.Where(e => e.DeletedAt.HasValue == false).ToList();
    //    return entities;
    //}

    //public void Update(TEntity entity)
    //{
    //    TEntity update = _entities.First(e => e.Id.Equals(entity.Id));
    //    _entities.Remove(update);
    //    _entities.Add(entity);

    //    entity.UpdateAt = DateTime.UtcNow;
    //}
}
