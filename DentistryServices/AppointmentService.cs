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

    // public async Task<PaginatedList<AppointmentDto>> GetPagedAppointmentsAsync(QueryParams queryParams)
    // {
    //   Expression<Func<Appointment, bool>> filterExpression = null;
    //   if (!string.IsNullOrEmpty(queryParams.Filter))
    //   {
    //     filterExpression = e => e.Name.Contains(queryParams.Filter);
    //   }
    //   if (!string.IsNullOrEmpty(queryParams.Search))
    //   {
    //     string searchLower = queryParams.Search.ToLower();
    //     Expression<Func<Appointment, bool>> searchExpression = e => e.Name.ToLower().Contains(searchLower);
    //     if (filterExpression != null)
    //     {
    //       filterExpression = filterExpression.AndAlso(searchExpression);
    //     }
    //     else
    //     {
    //       filterExpression = searchExpression;
    //     }
    //   }
    //   Func<IQueryable<Appointment>, IOrderedQueryable<Appointment>> orderBy = null;
    //   if (queryParams.Sort != null)
    //   {
    //     switch (queryParams.Sort.Key)
    //     {
    //       case "name":
    //         orderBy = q => queryParams.Sort.Value == 1 ? q.OrderByDescending(e => e.Name) : q.OrderBy(e => e.Name);
    //         break;
    //       case "status":
    //         orderBy = q => queryParams.Sort.Value == 1 ? q.OrderByDescending(e => e.Status) : q.OrderBy(e => e.Status);
    //         break;
    //       default:
    //         orderBy = q => q.OrderBy(e => e.AppointmentID); // Default sort by AppointmentID
    //         break;
    //     }
    //   }
    //   else
    //   {
    //     orderBy = q => q.OrderBy(e => e.AppointmentID); // Default sort by AppointmentID
    //   }

    //   var pagedAppointments = await _AppointmentRepository.GetPagedAppointmentsAsync(queryParams.PageIndex, queryParams.PageSize, filterExpression, orderBy);
    //   return new PaginatedList<AppointmentDto>(
    //       _mapper.Map<List<AppointmentDto>>(pagedAppointments),
    //       pagedAppointments.Count,
    //       pagedAppointments.PageIndex,
    //       queryParams.PageSize
    //   );
    // }
  }
}