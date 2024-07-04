
using System.Linq.Expressions;
using DentistryBusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DentistryRepositories
{
  public class TreatmentPlanRepository : ITreatmentPlanRepository
    {
        private readonly DBContext _context;
    private readonly IBaseRepository<TreatmentPlan> _baseRepository;
        
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

        public async Task<IEnumerable<TreatmentPlan>> GetAllTreatmentPlansAsync()
        {
            return await _context.TreatmentPlans.ToListAsync();
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

        public Task<PaginatedList<TreatmentPlan>> GetPagedTreatmentPlansAsync(int pageIndex, int pageSize, Expression<Func<TreatmentPlan, bool>> filter, Func<IQueryable<TreatmentPlan>, IOrderedQueryable<TreatmentPlan>> orderBy)
        {
            return _baseRepository.GetPagedAsync(pageIndex, pageSize, filter, orderBy);
        }
    }
}
