
using DentistryBusinessObjects;

namespace DentistryRepositories
{
  public interface ITreatmentPlanRepository
  {
    Task<IEnumerable<TreatmentPlan>> GetAllTreatmentPlansAsync();
    Task<TreatmentPlan> GetTreatmentPlanByIdAsync(int id);
    Task AddTreatmentPlanAsync(TreatmentPlan appointment);
    Task UpdateTreatmentPlanAsync(TreatmentPlan appointment);
    Task DeleteTreatmentPlanAsync(int id);
  }
}