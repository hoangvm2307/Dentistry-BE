using System.Linq.Expressions;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;
using Microsoft.EntityFrameworkCore;


namespace DentistryRepositories
{
  public class ClinicRepository : IClinicRepository
  {
    private readonly DBContext _context;

    public ClinicRepository(DBContext context)
    {
      _context = context;
    }

    public async Task AddClinicAsync(Clinic clinic)
    {
      await _context.Clinics.AddAsync(clinic);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteClinicAsync(int id)
    {
      var clinic = await _context.Clinics.FindAsync(id);
      if (clinic != null)
      {
        _context.Clinics.Remove(clinic);
        await _context.SaveChangesAsync();
        
      }
    }

    public async Task<PagedList<Clinic>> GetAllClinicsAsync(ClinicQueryParams queryParams)
    {
      var query = _context.Clinics
        .Sort(queryParams.OrderBy)
        .Search(queryParams.SearchTerm)
        .FilterByStatus(queryParams.Status)
        .AsQueryable();

      return await PagedList<Clinic>.ToPagedList(query, queryParams.PageNumber, queryParams.PageSize);

    }

    public async Task<PagedList<Clinic>> GetAllClinicsAsync(SearchParams searchParams)
    {
      var query = _context.Clinics
         .Sort(searchParams.OrderBy)
         .Search(searchParams.SearchTerm)
         .AsQueryable();

      return await PagedList<Clinic>.ToPagedList(query, searchParams.PageNumber, searchParams.PageSize);
    }

    public async Task<Clinic> GetClinicByIdAsync(int id)
    {
      return await _context.Clinics.FindAsync(id);
    }

    public async Task UpdateClinicAsync(Clinic clinic)
    {
      _context.Entry(clinic).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }
  }
}