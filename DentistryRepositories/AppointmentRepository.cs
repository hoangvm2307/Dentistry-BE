using System.Linq.Expressions;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;
using Microsoft.EntityFrameworkCore;


namespace DentistryRepositories
{
  public class AppointmentRepository : IAppointmentRepository
  {
    private readonly DBContext _context;
    public AppointmentRepository(DBContext context)
    {
      _context = context;
    }
    public async Task<PagedList<Appointment>> GetAllAppointmentsAsync(AppointmentQueryParams queryParams)
    {
      var query = _context.Appointments
      .Sort(queryParams.OrderBy)
      .Search(queryParams.SearchTerm)
      .FilterByClinic(queryParams.ClinicID)
      .FilterByCustomer(queryParams.CustomerID)
      .FilterByDentist(queryParams.DentistID)
      .FilterByStatus(queryParams.Status)
      .Include(a => a.Customer)
      .Include(a => a.Dentist)
      .Include(a => a.Service)
      .AsQueryable();

      return await PagedList<Appointment>.ToPagedList(query, queryParams.PageNumber, queryParams.PageSize);
    }
    public async Task<Appointment> GetAppointmentByIdAsync(int id)
    {
      var appointment = await _context.Appointments
          .Include(a => a.Customer)
          .Include(a => a.Dentist)
          .Include(a => a.Service)
          .FirstOrDefaultAsync(a => a.AppointmentID == id);
      return appointment;
    }
    public async Task AddAppointmentAsync(Appointment appointment)
    {
      await _context.Appointments.AddAsync(appointment);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAppointmentAsync(int id)
    {
      var appointment = await _context.Appointments.FindAsync(id);
      if (appointment != null)
      {
        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();
      }
    }

    public async Task UpdateAppointmentAsync(Appointment appointment)
    {
      _context.Entry(appointment).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

  }
}