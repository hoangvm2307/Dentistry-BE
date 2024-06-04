using DTOs.DentistDto;

namespace DentistryServices
{
    public interface IDentistService
  {
    Task<List<DentistDto>> GetAllDentistsAsync();
    Task<List<DentistDto>> GetDentistsByClinicIdAndStatusAsync(List<int> clinicIds, List<bool> statues);
    Task<DentistDto> GetDentistByIdAsync(int id);
    Task<DentistDto> AddDentistAsync(DentistCreateDto dentist);
    Task UpdateDentistAsync(int id, DentistCreateDto dentist);
    Task DeleteDentistAsync(int id);
  }
}