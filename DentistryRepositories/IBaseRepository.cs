using System.Linq.Expressions;

namespace DentistryRepositories
{
    public interface IBaseRepository<T>
  {
    Task AddAsync(T entity);
    Task DeleteAsync(object id);
    Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
    Task<T> GetByIdAsync(object id, params Expression<Func<T, object>>[] includeProperties);
    
    Task UpdateAsync(T entity);
  }
}