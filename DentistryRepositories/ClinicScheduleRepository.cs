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
        .Sort(queryParams.OrderBy)
        .Search(queryParams.SearchTerm)
        .FilterByClinicId(queryParams.ClinicID)
        .AsQueryable();

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
  }
}