using DentistryBusinessObjects;
using DentistryRepositories.Extensions;

namespace DentistryRepositories
{
  public interface IClinicScheduleRepository
  {
    Task<IEnumerable<ClinicSchedule>> GetAllClinicSchedulesAsync(ClinicScheduleParams queryParams);
    Task<ClinicSchedule> GetClinicScheduleByIdAsync(int id);
    Task AddClinicScheduleAsync(ClinicSchedule clinicSchedule);
    Task<bool> IsClinicScheduleAvailable(int clinicId, DateTime appointmentDate, DateTime appointmentTime);
    Task UpdateClinicScheduleAsync(ClinicSchedule clinicSchedule);
    Task DeleteClinicScheduleAsync(int id);
  }
}