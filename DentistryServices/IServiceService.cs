
using DentistryRepositories;
using DentistryRepositories.Extensions;
using DTOs.ServiceDtos;

namespace DentistryServices
{
  public interface IServiceService
  {
    Task<PagedList<ServiceDto>> GetAllServicesAsync(QueryableParam queryParams);
    Task<ServiceDto> GetServiceByIdAsync(int id);
    Task<ServiceDto> CreateServiceAsync(ServiceCreateDto serviceCreateDto);
    Task<ServiceDto> UpdateServiceAsync(int id, ServiceUpdateDto serviceUpdateDto);
    Task<bool> DeleteServiceAsync(int id);
  }
}