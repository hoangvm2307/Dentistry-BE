using DentistryRepositories.Extensions;
using DTOs.ClinicOwnerDtos;

namespace DentistryServices
{
  public interface IClinicOwnerService
  {
    Task<PagedList<ClinicOwnerDto>> GetAllClinicOwnersAsync(ClinicOwnerQueryParams queryParams);
    Task<ClinicOwnerDto> GetClinicOwnerByIdAsync(int id);
    Task<ClinicOwnerDto> CreateClinicOwnerAsync(ClinicOwnerCreateDto clinicOwnerDto);
    Task<ClinicOwnerDto> UpdateClinicOwnerAsync(int id, ClinicOwnerCreateDto clinicOwnerDto);
    Task DeleteClinicOwnerAsync(int id);
  }
}