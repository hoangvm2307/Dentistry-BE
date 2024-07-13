using DentistryBusinessObjects;
using DentistryRepositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DentistryRepositories
{
  public class TreatmentPlanRepository : ITreatmentPlanRepository
  {
    private readonly DBContext _context;

    public TreatmentPlanRepository(DBContext context)
    {
      _context = context;
    }

    public async Task AddTreatmentPlanAsync(TreatmentPlan treatmentPlan)
    {
      await _context.TreatmentPlans.AddAsync(treatmentPlan);
      await _context.SaveChangesAsync();
    }

    public async Task DeleteTreatmentPlanAsync(int id)
    {
      var treatmentPlanToDelete = await _context.TreatmentPlans.FindAsync(id);
      if (treatmentPlanToDelete != null)
      {
        _context.TreatmentPlans.Remove(treatmentPlanToDelete);
        await _context.SaveChangesAsync();
      }
    }

    public async Task<PagedList<TreatmentPlan>> GetAllTreatmentPlansAsync(TreatmentQueryParams queryParams)
    {
      var query = _context.TreatmentPlans
        .Include(c => c.Customer)
        .Include(c => c.Dentist)
        .Sort(queryParams.OrderBy)
        .Search(queryParams.SearchTerm)
        .FilterByClinic(queryParams.ClinicID)
        .FilterByCustomer(queryParams.CustomerID)
        .FilterByDentist(queryParams.DentistID)
        .AsQueryable();

      return await PagedList<TreatmentPlan>.ToPagedList(query, queryParams.PageNumber, queryParams.PageSize);
    }

    public async Task<TreatmentPlan> GetTreatmentPlanByIdAsync(int id)
    {
      return await _context.TreatmentPlans.FindAsync(id);
    }

    public async Task UpdateTreatmentPlanAsync(TreatmentPlan treatmentPlan)
    {
      _context.Entry(treatmentPlan).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }
  }
}
