using System.Linq.Expressions;
using DentistryBusinessObjects;

namespace DentistryRepositories
{
  public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task AddAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(int id);
        Task<PaginatedList<Appointment>> GetPagedAppointmentsAsync(
            int pageIndex,
            int pageSize,
            Expression<Func<Appointment, bool>> filter,
            Func<IQueryable<Appointment>, IOrderedQueryable<Appointment>> orderBy);
    }
}