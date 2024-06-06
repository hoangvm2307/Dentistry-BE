using DTOs.ClinicDtos;
using DTOs.DentistDtos;

namespace DentistryServices
{
    public interface IClinicService
  {
    Task<List<ClinicDto>> GetAllClinicsAsync();
    Task<List<ClinicDto>> GetClinicsByStatusAsync(List<bool> statuses);
    Task<ClinicDto> GetClinicByIdAsync(int id);
    Task<ClinicDto> AddClinicAsync(ClinicCreateDto clinic);
    Task UpdateClinicAsync(int id, ClinicCreateDto clinic);
    Task DeleteClinicAsync(int id);
  }
}