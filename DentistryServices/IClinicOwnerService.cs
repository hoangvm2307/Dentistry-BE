
using DentistryRepositories;
using DTOs.ClinicOwnerDtos;

namespace DentistryServices
{
  public interface IClinicOwnerService
  {
    Task<IEnumerable<ClinicOwnerDto>> GetAllClinicOwnersAsync();
    Task<ClinicOwnerDto> GetClinicOwnerByIdAsync(int id);
    Task<PaginatedList<ClinicOwnerDto>> GetPagedClinicOwnersAsync(QueryParams queryParams);
    Task<IEnumerable<ClinicOwnerDto>> GetClinicOwnersByClinicIdAsync(int id);
    Task<ClinicOwnerDto> CreateClinicOwnerAsync(ClinicOwnerCreateDto clinicOwnerDto);
    Task<ClinicOwnerDto> UpdateClinicOwnerAsync(int id, ClinicOwnerCreateDto clinicOwnerDto);
    Task DeleteClinicOwnerAsync(int id);
  }
}