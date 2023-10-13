using Dene.Core.Data.Entities;
using System.Linq.Expressions;


namespace Dene.Core.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        
    
        T Get(Expression<Func<T, bool>> filter);

        List<T> GetList(Expression<Func<T, bool>> filter = null);
        //List<T> AddTask(Expression<Func<T, bool>> filter =null);
        T Add(T entity);

        T Delete(T entity);
        T Update(T entity);
      
    }
}
