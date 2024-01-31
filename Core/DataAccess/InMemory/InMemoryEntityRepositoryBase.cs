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

    public TEntity Delete(TEntity entity, bool isSoftDelete = true)
    {

        entity.DeletedAt = DateTime.UtcNow; // Soft delete
        if (!isSoftDelete)
            Entities.Remove(entity); // Hard delete

        return entity;
        //entity.DeletedAt = DateTime.UtcNow;

        //TEntity delete = Entities.First(b => b.Id.Equals(entity.Id));
        //Entities.Remove(delete);
        //return delete;
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
        return entity;

        //entity.UpdateAt = DateTime.UtcNow;
        //TEntity update = Entities.First(e => e.Id.Equals(entity.Id));
        //Entities.Remove(update);
        //Entities.Add(entity);
        //return entity;
    }
}
