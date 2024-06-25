using System.Linq.Expressions;
using DentistryBusinessObjects;
using DentistryRepositories;
using DTOs.DentistDtos;

namespace DentistryServices
{
    public interface IDentistService
  {
    Task<IEnumerable<DentistDto>> GetAllDentistsAsync();
    Task<IEnumerable<DentistDto>> GetDentistsByClinicIdAsync(int id);
   Task<PaginatedList<DentistDto>> GetPagedDentistsAsync(DentistRequestQueryParams queryParams);
    Task<IEnumerable<DentistDto>> GetDentistsByClinicIdAndStatusAsync(List<int> clinicIds, List<bool> statues);
    Task<DentistDto> GetDentistByIdAsync(int id);
    Task<DentistDto> AddDentistAsync(DentistCreateDto dentist);
    Task<DentistDto> UpdateDentistAsync(int id, DentistCreateDto dentist);
    Task DeleteDentistAsync(int id);
  }
}