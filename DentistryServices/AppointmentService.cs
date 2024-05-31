using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories;
using DTOs.AppointmentDto;

namespace DentistryServices
{
  public class AppointmentService : IAppointmentService
  {
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IMapper _mapper;

    public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
    {
      _appointmentRepository = appointmentRepository;
      _mapper = mapper;
    }
    public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync()
    {
      var appointments = await _appointmentRepository.GetAllAppointmentsAsync();
      return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
    }

    public async Task<AppointmentDto> GetAppointmentByIdAsync(int id)
    {
      var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id);
      if (appointment == null)
        return null;

      return _mapper.Map<AppointmentDto>(appointment);
    }

    public async Task<AppointmentDto> CreateAppointmentAsync(AppointmentCreateDto appointmentCreateDto)
    {
      var appointment = _mapper.Map<Appointment>(appointmentCreateDto);
      await _appointmentRepository.AddAppointmentAsync(appointment);

      return _mapper.Map<AppointmentDto>(appointment);
    }

    public async Task<AppointmentDto> UpdateAppointmentAsync(int id, AppointmentUpdateDto appointmentUpdateDto)
    {
      var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id);
      if (appointment == null)
        return null;

      _mapper.Map(appointmentUpdateDto, appointment);
      await _appointmentRepository.UpdateAppointmentAsync(appointment);

      return _mapper.Map<AppointmentDto>(appointment);
    }

    public async Task<bool> DeleteAppointmentAsync(int id)
    {
      var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id);
      if (appointment == null)
        return false;

      await _appointmentRepository.DeleteAppointmentAsync(id);
      return true;
    }
  }
}