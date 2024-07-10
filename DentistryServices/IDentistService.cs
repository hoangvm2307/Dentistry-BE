using DentistryRepositories.Extensions;
using DTOs.DentistDtos;

namespace DentistryServices
{
  public interface IDentistService
  {
    Task<PagedList<DentistDto>> GetAllDentistsAsync(DentistQueryParams queryParams);
    Task<DentistDto> GetDentistByIdAsync(int id);
    Task<DentistDto> AddDentistAsync(DentistCreateDto dentist);
    Task<DentistDto> UpdateDentistAsync(int id, DentistUpdateDto dentist);
    Task DeleteDentistAsync(int id);
  }
}