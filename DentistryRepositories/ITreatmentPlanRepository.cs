
using System.Linq.Expressions;
using DentistryBusinessObjects;
using DentistryRepositories.Extensions;

namespace DentistryRepositories
{
  public interface ITreatmentPlanRepository
  {
    Task<PagedList<TreatmentPlan>> GetAllTreatmentPlansAsync(QueryableParam queryParams);
    Task<TreatmentPlan> GetTreatmentPlanByIdAsync(int id);
    Task AddTreatmentPlanAsync(TreatmentPlan appointment);
    Task UpdateTreatmentPlanAsync(TreatmentPlan appointment);
    Task DeleteTreatmentPlanAsync(int id);

  }
}