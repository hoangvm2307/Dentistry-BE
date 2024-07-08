using System.Linq.Expressions;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;

namespace DentistryRepositories
{
  public interface IServiceRepository
  {
    Task<PagedList<Service>> GetAllServicesAsync(ServiceQueryParams queryParams);
    Task<PagedList<Service>> GetAllServicesAsync(SearchParams searchParams);

    Task<Service> GetServiceByIdAsync(int id);
    Task AddServiceAsync(Service service);
    Task UpdateServiceAsync(Service service);
    Task DeleteServiceAsync(int id);
  }
}