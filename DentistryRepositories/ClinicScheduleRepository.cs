using DentistryBusinessObjects;
using DentistryRepositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DentistryRepositories
{
  public class ClinicScheduleRepository : IClinicScheduleRepository
  {
    private readonly DBContext _context;

    public ClinicScheduleRepository(DBContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<ClinicSchedule>> GetAllClinicSchedulesAsync(ClinicScheduleParams queryParams)
    {

      var query = _context.ClinicSchedules
        .Include(cs => cs.Clinic)
        .ViewType(queryParams.ViewType)
        .Sort(queryParams.OrderBy)
        .Search(queryParams.SearchTerm)
        .FilterByDate(queryParams.Date)
        .FilterByClinicId(queryParams.ClinicID)
        .AsQueryable();

      var appointments = _context.Appointments.ToList();
      foreach(var a in appointments){
        Console.WriteLine($"===={a.AppointmentDate:yyyy-MM-dd}====");
      }
     
      return await PagedList<ClinicSchedule>.ToPagedList(query, queryParams.PageNumber, queryParams.PageSize);
    }

    public async Task<ClinicSchedule> GetClinicScheduleByIdAsync(int id)
    {
      return await _context.ClinicSchedules.FindAsync(id);
    }

    public async Task AddClinicScheduleAsync(ClinicSchedule clinicSchedule)
    {
      await _context.ClinicSchedules.AddAsync(clinicSchedule);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateClinicScheduleAsync(ClinicSchedule clinicSchedule)
    {
      _context.Entry(clinicSchedule).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task DeleteClinicScheduleAsync(int id)
    {
      var clinicSchedule = await _context.ClinicSchedules.FindAsync(id);
      if (clinicSchedule != null)
      {
        _context.ClinicSchedules.Remove(clinicSchedule);
        await _context.SaveChangesAsync();
      }
    }

    public async Task<bool> IsClinicScheduleAvailable(int clinicId, DateTime appointmentDate, DateTime appointmentTime)
    {
      var clinicSchedule = await _context.ClinicSchedules
               .FirstOrDefaultAsync(cs => cs.ClinicID == clinicId && cs.DayOfWeek.ToLower().Trim().Equals(appointmentDate.DayOfWeek.ToString().ToLower().Trim()));

      if (clinicSchedule == null)
        throw new Exception("Clinic schedule not found");

      var startTime = appointmentDate.Date.Add(appointmentTime.TimeOfDay);
      var endTime = startTime.AddMinutes(clinicSchedule.SlotDuration);

      var appointmentsCount = await _context.Appointments
          .CountAsync(a => a.Dentist.ClinicID == clinicId &&
                           a.AppointmentDate == appointmentDate.Date &&
                           a.AppointmentTime >= startTime &&
                           a.AppointmentTime < endTime);

      return appointmentsCount < clinicSchedule.MaxPatientsPerSlot;
    }
  }
}