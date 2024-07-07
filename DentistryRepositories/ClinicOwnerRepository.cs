using System.Linq.Expressions;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;
using Microsoft.EntityFrameworkCore;


namespace DentistryRepositories
{
  public class ClinicOwnerRepository : IClinicOwnerRepository
  {
    private readonly DBContext _context;
    private readonly IBaseRepository<ClinicOwner> _baseRepository;

    public ClinicOwnerRepository(DBContext context)
    {
      _context = context;
    }

    public async Task<PagedList<ClinicOwner>> GetAllClinicOwnersAsync(QueryableParam queryParams)
    {
      var query = _context.ClinicOwners
      .Sort(queryParams.OrderBy)
      .Search(queryParams.SearchTerm)
      .Filter(queryParams.ClinicID)
      .Include(e => e.Clinic)
      .AsQueryable();

      return await PagedList<ClinicOwner>.ToPagedList(query, queryParams.PageNumber, queryParams.PageSize);
    }

    public async Task<ClinicOwner> GetClinicOwnerByIdAsync(int id)
    {
      return await _context.ClinicOwners
        .Include(e => e.Clinic)
        .SingleOrDefaultAsync(e => e.OwnerID == id);
    }

    public async Task AddClinicOwnerAsync(ClinicOwner clinicOwner)
    {
      await _context.ClinicOwners.AddAsync(clinicOwner);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateClinicOwnerAsync(ClinicOwner clinicOwner)
    {
      _context.Entry(clinicOwner).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task DeleteClinicOwnerAsync(int id)
    {
      var clinicOwner = await _context.ClinicOwners.FindAsync(id);
      if (clinicOwner != null)
      {
        _context.ClinicOwners.Remove(clinicOwner);
        await _context.SaveChangesAsync();
      }
    }

    public Task<PaginatedList<ClinicOwner>> GetPagedClinicOwnersAsync(int pageIndex, int pageSize, Expression<Func<ClinicOwner, bool>> filter, Func<IQueryable<ClinicOwner>, IOrderedQueryable<ClinicOwner>> orderBy)
    {
      return _baseRepository.GetPagedAsync(pageIndex, pageSize, filter, orderBy);
    }

  }
}