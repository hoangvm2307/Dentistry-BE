using DentistryBusinessObjects;
using Microsoft.EntityFrameworkCore;
 

namespace DentistryRepositories
{
  public class ClinicOwnerRepository : IClinicOwnerRepository
  {
    private readonly DBContext _context;

    public ClinicOwnerRepository(DBContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<ClinicOwner>> GetAllClinicOwnersAsync()
    {
      return await _context.ClinicOwners.ToListAsync();
    }

    public async Task<ClinicOwner> GetClinicOwnerByIdAsync(int id)
    {
      return await _context.ClinicOwners.FindAsync(id);
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
  }
}