using Dene.Core.Abstract;
using Dene.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Dene.Core.Data.Ef
{
    public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
    
         where TEntity : class, IEntity, new()
         where TContext : DbContext, new()
        {
            public TEntity Add(TEntity entity)
            {
                using (var context = new TContext())
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                    return addedEntity.Entity;
                }

            }

            public TEntity Delete(TEntity entity)
            {
                using (var context = new TContext())
                {
                    var DeletedEntity = context.Entry(entity);
                    DeletedEntity.State = EntityState.Deleted;
                    context.SaveChanges();
                    return DeletedEntity.Entity;
                }
            }

            public TEntity Get(Expression<Func<TEntity, bool>> filter)
            {
                using (var context = new TContext())
                {
                    return context.Set<TEntity>().SingleOrDefault(filter);
                }
            }

            public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
            {
                using (var context = new TContext())
                {
                    return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
                }
            }

            public TEntity Update(TEntity entity)
            {
                using (var context = new TContext())
                {
                    var updatedEntity = context.Entry(entity);
                    updatedEntity.State = EntityState.Modified;
                    context.SaveChanges();
                    return updatedEntity.Entity;
                }
            }

        }
    }
