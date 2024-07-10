using DentistryRepositories.Extensions;
using DTOs.ClinicDtos;
using DTOs.ClinicOwnerDtos;

namespace DentistryServices
{
  public interface IClinicOwnerService
  {
    Task<PagedList<ClinicOwnerDto>> GetAllClinicOwnersAsync(ClinicOwnerQueryParams queryParams);
    Task<ClinicOwnerDto> GetClinicOwnerByIdAsync(int id);
    Task<ClinicOwnerDto> CreateClinicOwnerAsync(ClinicOwnerCreateDto clinicOwnerDto);
    Task<ClinicOwnerDto> UpdateClinicOwnerAsync(int id, ClinicOwnerUpdateDto clinicOwnerDto);
    Task DeleteClinicOwnerAsync(int id);
  }
}