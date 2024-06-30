using System.Linq.Expressions;
using DentistryBusinessObjects;
using Microsoft.EntityFrameworkCore;


namespace DentistryRepositories
{
    public class ClinicRepository : BaseRepository<Clinic>, IClinicRepository
  {
    private readonly DBContext _context;
    private readonly IBaseRepository<Clinic> _baseRepository;

    public ClinicRepository(DBContext context) : base(context)
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

    public async Task<IEnumerable<Clinic>> GetAllClinicsAsync()
    {
        return await _context.Clinics.ToListAsync();
    }

    public async Task<Clinic> GetClinicByIdAsync(int id)
    {
        return await _context.Clinics.FindAsync(id);
    }

    public Task<PaginatedList<Clinic>> GetPagedClinicsAsync(int pageIndex, int pageSize, Expression<Func<Clinic, bool>> filter, Func<IQueryable<Clinic>, IOrderedQueryable<Clinic>> orderBy)
    {
        return _baseRepository.GetPagedAsync(pageIndex, pageSize, filter, orderBy);
    }

    public async Task UpdateClinicAsync(Clinic clinic)
    {
      _context.Entry(clinic).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }
    }
}