using System.Linq.Expressions;
using DentistryBusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DentistryRepositories
{
   public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
  {
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(DbContext context)
    {
      _context = context;
      _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
      await _dbSet.AddAsync(entity);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(object id)
    {
      var entity = await _dbSet.FindAsync(id);
      if (entity != null)
      {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
      }
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(
        params Expression<Func<T, object>>[] includeProperties)
    {
      IQueryable<T> query = _dbSet;
      query = IncludeProperties(query, includeProperties);
      return await query.ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(object id,
        params Expression<Func<T, object>>[] includeProperties)
    {
      IQueryable<T> query = _dbSet;
      query = IncludeProperties(query, includeProperties);
      return await query.SingleOrDefaultAsync(e => EF.Property<int>(e, "Id") == (int)id);
    }

    public async Task<PaginatedList<T>> GetPagedAsync(
        int pageIndex,
        int pageSize,
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        params Expression<Func<T, object>>[] includeProperties)
    {
      IQueryable<T> query = _dbSet;

      if (filter != null)
      {
        query = query.Where(filter);
      }

      if (includeProperties != null)
      {
        query = IncludeProperties(query, includeProperties);
      }

      if (orderBy != null)
      {
        query = orderBy(query);
      }

      return await PaginatedList<T>.CreateAsync(query, pageIndex, pageSize);
    }

    public async Task UpdateAsync(T entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    private IQueryable<T> IncludeProperties(IQueryable<T> query, params Expression<Func<T, object>>[] includeProperties)
    {
      if (includeProperties != null)
      {
        foreach (var includeProperty in includeProperties)
        {
          query = query.Include(includeProperty);
        }
      }
      return query;
    }
  }
}