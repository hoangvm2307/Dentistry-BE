using DentistryRepositories;
using DentistryRepositories.Extensions;
using DTOs.ClinicDtos;

namespace DentistryServices
{
  public interface IClinicService
  {
    Task<PagedList<ClinicDto>> GetAllClinicsAsync(ClinicQueryParams queryParams);
    Task<ClinicDto> GetClinicByIdAsync(int id);
    Task<ClinicDto> AddClinicAsync(ClinicCreateDto clinic);
    Task<ClinicDto> UpdateClinicAsync(int id, ClinicCreateDto clinic);
    Task DeleteClinicAsync(int id);
  }
}