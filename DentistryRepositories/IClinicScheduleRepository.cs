using DentistryBusinessObjects;

namespace DentistryRepositories
{
  public interface IClinicScheduleRepository
  {
    Task<IEnumerable<ClinicSchedule>> GetAllClinicSchedulesAsync();
    Task<ClinicSchedule> GetClinicScheduleByIdAsync(int id);
    Task AddClinicScheduleAsync(ClinicSchedule clinicSchedule);
    Task UpdateClinicScheduleAsync(ClinicSchedule clinicSchedule);
    Task DeleteClinicScheduleAsync(int id);
  }
}