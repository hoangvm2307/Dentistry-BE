using DentistryRepositories;
using DTOs.ClinicDtos;

namespace DentistryServices
{
    public interface IClinicService
  {
    Task<IEnumerable<ClinicDto>> GetAllClinicsAsync();
    Task<IEnumerable<ClinicDto>> GetClinicsByStatusAsync(List<bool> statuses);
    Task<PaginatedList<ClinicDto>> GetPagedClinicsAsync(QueryParams queryParams);
    Task<ClinicDto> GetClinicByIdAsync(int id);
    Task<ClinicDto> AddClinicAsync(ClinicCreateDto clinic);
    Task<ClinicDto> UpdateClinicAsync(int id, ClinicCreateDto clinic);
    Task DeleteClinicAsync(int id);
  }
}