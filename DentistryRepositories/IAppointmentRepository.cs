using System.Linq.Expressions;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;

namespace DentistryRepositories
{
  public interface IAppointmentRepository
  {
    Task<PagedList<Appointment>> GetAllAppointmentsAsync(AppointmentQueryParams queryParams);
    Task<Appointment> GetAppointmentByIdAsync(int id);
    Task AddAppointmentAsync(Appointment appointment);
    Task UpdateAppointmentAsync(Appointment appointment);
    Task DeleteAppointmentAsync(int id);

  }
}