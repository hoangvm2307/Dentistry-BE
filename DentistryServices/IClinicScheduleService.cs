using DentistryRepositories.Extensions;
using DTOs.ClinicScheduleDtos;

namespace DentistryServices
{
  public interface IClinicScheduleService
  {
    Task<PagedList<ClinicScheduleDto>> GetAllClinicSchedulesAsync(ClinicScheduleParams queryParams);
    Task<ClinicScheduleDto> GetClinicScheduleByIdAsync(int id);
    Task<ClinicScheduleDto> CreateClinicScheduleAsync(ClinicScheduleCreateDto clinicScheduleCreateDto);
    Task<ClinicScheduleDto> UpdateClinicScheduleAsync(int id, ClinicScheduleUpdateDto clinicScheduleUpdateDto);
    Task<bool> DeleteClinicScheduleAsync(int id);
  }
}