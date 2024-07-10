using System.Linq.Expressions;
using AutoMapper;
using DentistryBusinessObjects;
using DentistryRepositories;
using DentistryRepositories.Extensions;
using DTOs.AppointmentDtos;

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
    public async Task<PagedList<AppointmentDto>> GetAllAppointmentsAsync(AppointmentQueryParams queryParams)
    {
      var appointments = await _appointmentRepository.GetAllAppointmentsAsync(queryParams);
      return _mapper.Map<PagedList<AppointmentDto>>(appointments);
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
      if (await _appointmentRepository.IsScheduleAvailable(appointmentCreateDto.ClinicID,
        appointmentCreateDto.AppointmentDate, appointmentCreateDto.AppointmentTime, 45))
      {
        var appointment = _mapper.Map<Appointment>(appointmentCreateDto);
        await _appointmentRepository.AddAppointmentAsync(appointment);

        return _mapper.Map<AppointmentDto>(appointment);
      }
      else
      {
        throw new Exception("The schedule is not available for the selected time slot.");
      }
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