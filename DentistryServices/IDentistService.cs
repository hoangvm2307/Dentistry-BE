using DentistryRepositories;
using DTOs.DentistDtos;

namespace DentistryServices
{
  public interface IDentistService
  {
    Task<IEnumerable<DentistDto>> GetAllDentistsAsync();
    Task<PaginatedList<DentistDto>> GetDentistsByClinicIdAsync(int id, QueryParams queryParams);
    Task<PaginatedList<DentistDto>> GetPagedDentistsAsync(QueryParams queryParams);
    Task<IEnumerable<DentistDto>> GetDentistsByClinicIdAndStatusAsync(List<int> clinicIds, List<bool> statues);
    Task<DentistDto> GetDentistByIdAsync(int id);
    Task<DentistDto> AddDentistAsync(DentistCreateDto dentist);
    Task<DentistDto> UpdateDentistAsync(int id, DentistCreateDto dentist);
    Task DeleteDentistAsync(int id);
  }
}