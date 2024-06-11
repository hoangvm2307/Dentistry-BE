
using DTOs.ClinicOwnerDtos;

namespace DentistryServices
{
  public interface IClinicOwnerService
  {
    Task<IEnumerable<ClinicOwnerDto>> GetAllClinicOwnersAsync();
    Task<IEnumerable<ClinicOwnerDto>> GetClinicOwnersByClinicIdAndStatusAsync(List<int> clinicIds, List<bool> statues);
    Task<ClinicOwnerDto> GetClinicOwnerByIdAsync(int id);
    Task<ClinicOwnerDto> CreateClinicOwnerAsync(ClinicOwnerCreateDto clinicOwnerDto);
    Task<ClinicOwnerDto> UpdateClinicOwnerAsync(int id, ClinicOwnerCreateDto clinicOwnerDto);
    Task DeleteClinicOwnerAsync(int id);
  }
}