using System.Linq.Expressions;
using DentistryBusinessObjects;

namespace DentistryRepositories
{
  public interface IServiceRepository
  {
    Task<IEnumerable<Service>> GetAllServicesAsync();
    Task<Service> GetServiceByIdAsync(int id);
    Task AddServiceAsync(Service service);
    Task UpdateServiceAsync(Service service);
    Task DeleteServiceAsync(int id);
    Task<PaginatedList<Service>> GetPagedServicesAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<Service, bool>> filter,
            Func<IQueryable<Service>, IOrderedQueryable<Service>> orderBy);
  }
}