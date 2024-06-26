
using DentistryRepositories;
using DTOs.ServiceDtos;

namespace DentistryServices
{
  public interface IServiceService
  {
    Task<IEnumerable<ServiceDto>> GetAllServicesAsync();
    Task<ServiceDto> GetServiceByIdAsync(int id);
    Task<PaginatedList<ServiceDto>> GetPagedServicesAsync(QueryParams queryParams);
    Task<ServiceDto> CreateServiceAsync(ServiceCreateDto serviceCreateDto);
    Task<ServiceDto> UpdateServiceAsync(int id, ServiceUpdateDto serviceUpdateDto);
    Task<bool> DeleteServiceAsync(int id);
  }
}