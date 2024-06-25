using System.Linq.Expressions;
using DentistryBusinessObjects;
using Microsoft.EntityFrameworkCore;


namespace DentistryRepositories
{
  public class DentistRepository : IDentistRepository
  {
    private readonly DBContext _context;

    public DentistRepository(DBContext context)
    {
      _context = context;
    }

    public async Task AddDentistAsync(Dentist dentist)
    {
      await _context.Dentists.AddAsync(dentist);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteDentistAsync(int id)
    {
      var dentist = await _context.Dentists.FindAsync(id);
      if (dentist != null)
      {
        _context.Dentists.Remove(dentist);
        await _context.SaveChangesAsync();
      }
    }

    public async Task<IEnumerable<Dentist>> GetAllDentistsAsync()
    {
      return await _context.Dentists
      .Include(e => e.Clinic)
      .ToListAsync();
    }

    public async Task<Dentist> GetDentistByIdAsync(int id)
    {
      return await _context.Dentists
      .Include(e => e.Clinic)
      .SingleOrDefaultAsync(e => e.DentistID == id);
    }

    public async Task<PaginatedList<Dentist>> GetPagedDentistsAsync(
          int pageIndex,
          int pageSize,
          Expression<Func<Dentist, bool>> filter = null,
          Func<IQueryable<Dentist>, IOrderedQueryable<Dentist>> orderBy = null)
    {
      IQueryable<Dentist> query = _context.Dentists.Include(e => e.Clinic);

      if (filter != null)
      {
        query = query.Where(filter);
      }

      if (orderBy != null)
      {
        query = orderBy(query);
      }

      return await PaginatedList<Dentist>.CreateAsync(query, pageIndex, pageSize);
    }

    public async Task UpdateDentistAsync(Dentist dentist)
    {
      _context.Entry(dentist).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }
  }
}