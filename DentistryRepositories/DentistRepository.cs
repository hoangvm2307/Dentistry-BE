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

    public async Task<List<Dentist>> GetAllDentistsAsync()
    {
        return await _context.Dentists.ToListAsync();
    }

    public async Task<Dentist> GetDentistByIdAsync(int id)
    {
        return await _context.Dentists.FindAsync(id);
    }

    public async Task UpdateDentistAsync(Dentist dentist)
    {
      _context.Entry(dentist).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }
    }
}