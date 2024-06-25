using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DentistryRepositories
{
  public interface IBaseRepository<T>
  {
    Task AddAsync(T entity);
    Task DeleteAsync(object id);
    Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
    Task<T> GetByIdAsync(object id, params Expression<Func<T, object>>[] includeProperties);
    Task<PaginatedList<T>> GetPagedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        params Expression<Func<T, object>>[] includeProperties);
    Task UpdateAsync(T entity);
  }
}