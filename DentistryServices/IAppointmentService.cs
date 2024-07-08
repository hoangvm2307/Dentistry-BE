using DentistryRepositories.Extensions;
using DTOs.AppointmentDtos;

namespace DentistryServices
{
  public interface IAppointmentService
  {
    Task<PagedList<AppointmentDto>> GetAllAppointmentsAsync(AppointmentQueryParams queryParams);
    Task<AppointmentDto> GetAppointmentByIdAsync(int id);
    Task<AppointmentDto> CreateAppointmentAsync(AppointmentCreateDto appointmentCreateDto);
    Task<AppointmentDto> UpdateAppointmentAsync(int id, AppointmentUpdateDto appointmentUpdateDto);
    Task<bool> DeleteAppointmentAsync(int id);
  }
}