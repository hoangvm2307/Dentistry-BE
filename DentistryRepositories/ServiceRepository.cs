using System.Linq.Expressions;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;
using Microsoft.EntityFrameworkCore;


namespace DentistryRepositories
{
  public class ServiceRepository : IServiceRepository
  {
    private readonly DBContext _context;

    public ServiceRepository(DBContext context)
    {
      _context = context;
    }

    public async Task<PagedList<Service>> GetAllServicesAsync(QueryableParam queryParams)
    {
      var query = _context.Services
          .Sort(queryParams.OrderBy)
          .Search(queryParams.SearchTerm)
          .Filter(queryParams.ClinicID)
          .Include(d => d.Clinic)
          .AsQueryable();

      return await PagedList<Service>.ToPagedList(query, queryParams.PageNumber, queryParams.PageSize);
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

  }
}