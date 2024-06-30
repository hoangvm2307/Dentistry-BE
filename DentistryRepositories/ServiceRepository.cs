using System.Linq.Expressions;
using DentistryBusinessObjects;
using Microsoft.EntityFrameworkCore;
 

namespace DentistryRepositories
{
  public class ServiceRepository : IServiceRepository
  {
    private readonly DBContext _context;
    private readonly IBaseRepository<Service> _baseRepository;

    public ServiceRepository(DBContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Service>> GetAllServicesAsync()
    {
      return await _context.Services.ToListAsync();
    }

    public async Task<Service> GetServiceByIdAsync(int id)
    {
      return await _context.Services.FindAsync(id);
    }

    public async Task AddServiceAsync(Service service)
    {
      await _context.Services.AddAsync(service);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateServiceAsync(Service service)
    {
      _context.Entry(service).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task DeleteServiceAsync(int id)
    {
      var service = await _context.Services.FindAsync(id);
      if (service != null)
      {
        _context.Services.Remove(service);
        await _context.SaveChangesAsync();
      }
    }

    public Task<PaginatedList<Service>> GetPagedServicesAsync(int pageIndex, int pageSize, Expression<Func<Service, bool>> filter, Func<IQueryable<Service>, IOrderedQueryable<Service>> orderBy)
    {
        return _baseRepository.GetPagedAsync(pageIndex, pageSize, filter, orderBy);
    }
  }
}